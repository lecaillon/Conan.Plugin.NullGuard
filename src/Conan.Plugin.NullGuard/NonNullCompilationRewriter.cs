namespace Conan.Plugin.NullGuard
{
    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Diagnostics;
    using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    /// <summary>
    ///     This Conan plugin will add null guard code for all methods and constructors parameters preceded by a [NonNull] attribute.
    /// </summary>
    /// <example>
    ///     Below the code that will be added at the beginning of the method or ctor body for a non nullable args parameter:
    ///     <code>
    ///     
    ///         if (args == null)
    ///         {
    ///     	    throw new System.ArgumentNullException("args");
    ///         }
    ///     
    ///     </code>
    /// </example>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class NonNullCompilationRewriter : CompilationRewriter
    {
        public override Compilation Rewrite(CompilationRewriterContext context)
        {
            var compilation = context.Compilation;

            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                var methods = syntaxTree.FindMethodsAndCtors().ToList();
                if (methods.Count > 0)
                {
                    var newRoot = syntaxTree.GetRoot().ReplaceNodes(syntaxTree.FindMethodsAndCtors(), (originalNode, _) => RewriteMethodWithNullGuard(originalNode));
                    context.ExportRewrittenDocument(syntaxTree, newRoot);

                    compilation = compilation.ReplaceSyntaxTree(syntaxTree, newRoot.SyntaxTree);
                }
            }

            return compilation;
        }

        private static BaseMethodDeclarationSyntax RewriteMethodWithNullGuard(BaseMethodDeclarationSyntax baseMethod)
        {
            var statements = baseMethod.Body.Statements;
            foreach (var parameter in baseMethod.FindParametersWithNonNullAttribute())
            {
                statements = statements.Insert(0, BuildNullGuardStatement(parameter));
            }

            if (baseMethod is MethodDeclarationSyntax method)
            {
                return method.WithBody(baseMethod.Body.WithStatements(statements));
            }
            if (baseMethod is ConstructorDeclarationSyntax ctor)
            {
                return ctor.WithBody(baseMethod.Body.WithStatements(statements));
            }

            throw new NotSupportedException("Conan.Plugin.NullGuard only supports methods and constructors.");
        }

        private static StatementSyntax BuildNullGuardStatement(string parameter) =>
            IfStatement(
                BinaryExpression(
                    SyntaxKind.EqualsExpression,
                    IdentifierName(parameter),
                    LiteralExpression(
                        SyntaxKind.NullLiteralExpression)),
                Block(
                    SingletonList<StatementSyntax>(
                        ThrowStatement(
                            ObjectCreationExpression(
                                QualifiedName(
                                    IdentifierName("System"),
                                    IdentifierName("ArgumentNullException")))
                            .WithArgumentList(
                                ArgumentList(
                                    SingletonSeparatedList<ArgumentSyntax>(
                                        Argument(
                                            LiteralExpression(
                                                SyntaxKind.StringLiteralExpression,
                                                Literal(parameter))))))))))
            .NormalizeWhitespace();
    }
}