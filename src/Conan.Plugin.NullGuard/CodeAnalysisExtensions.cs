namespace Conan.Plugin.NullGuard
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    ///     Convienient extension methods to manipulate a SyntaxTree.
    /// </summary>
    /// <remarks>
    ///     Not sure it is the most optimal way to manipulate it efficiently. :)
    /// </remarks>
    internal static class CodeAnalysisExtensions
    {
        private static readonly DiagnosticDescriptor ThisDescriptor = new DiagnosticDescriptor("NG0001", "NullGuard", "{0}", "Conan", DiagnosticSeverity.Warning, true);

        /// <summary>
        ///     Returns methods and constructors that have at least one [NotNull] attribute parameter for a given source document.
        /// </summary>
        public static IEnumerable<BaseMethodDeclarationSyntax> FindMethodsAndCtors(this SyntaxTree syntaxTree)
        {
            foreach (var method in syntaxTree.GetRoot()
                                             .DescendantNodes()
                                             .OfType<MethodDeclarationSyntax, ConstructorDeclarationSyntax>()
                                             .Cast<BaseMethodDeclarationSyntax>()
                                             .Where(m => m.FindParametersWithNonNullAttribute().Any()))
            {
                yield return method;
            }
        }

        /// <summary>
        ///     Returns the name of all parameters of a given <paramref name="method"/> preceded by a [NonNull] attribute.
        /// </summary>
        public static IEnumerable<string> FindParametersWithNonNullAttribute(this BaseMethodDeclarationSyntax method)
        {
            foreach (var item in method.ParameterList
                                       .DescendantNodes()
                                       .OfType<AttributeSyntax>()
                                       .Where(x => x.Name.ToFullString() == "NonNull"))
            {
                yield return item.FirstAncestorOrSelf<ParameterSyntax>().Identifier.ValueText;
            }
        }

        /// <summary>
        ///     Store the rewritten document on the disk for debugging purpose only, 
        ///     as we are directly working on the original file.
        /// </summary>
        public static void ExportRewrittenDocument(this CompilationRewriterContext context, SyntaxTree syntaxTree, SyntaxNode rootNode)
        {
            var newMainFile = context.GetOutputFilePath("Conan." + Path.GetFileNameWithoutExtension(syntaxTree.FilePath));
            File.WriteAllText(newMainFile, rootNode.ToFullString());
        }

        /// <summary>
        ///     Convienient method used to log information in the output window.
        /// </summary>
        public static void ReportDiagnostic(this CompilationRewriterContext context, object message) =>
            context.ReportDiagnostic(Diagnostic.Create(ThisDescriptor, Location.None, message));
    }
}
