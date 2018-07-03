# Conan.Plugin.NullGuard  [![Build status](https://ci.appveyor.com/api/projects/status/ov3kvojeu4s5ymxc/branch/master?svg=true)](https://ci.appveyor.com/project/lecaillon/conan-plugin-nullguard)

<img align="right" width="256px" height="256px" src="https://raw.githubusercontent.com/conan-roslyn/Conan/master/img/conan.png">

Conan.Plugin.NullGuard adds null guard code for all methods and constructors parameters preceded by any `[NonNull]` attribute.

It is based on [Conan](https://github.com/conan-roslyn/Conan), a _lightweight_ fork of the [.NET Compiler Platform ("Roslyn")](https://github.com/dotnet/roslyn/) by adding a **compiler plugin infrastructure**. These plugins can be deployed and installed as regular Diagnostic Analyzers.

## Getting started

1. Add the package `Conan.Net.Compilers` to your project: This will make the Conan compiler as the default CSharp/VB compiler and replace the default Roslyn compiler (This package works for both Full framework and Core framework unlike the Roslyn packages)
2. Add the package `Conan.Plugin.NullGuard` only available on [AppVeyor](https://ci.appveyor.com/project/lecaillon/conan-plugin-nullguard/build/artifacts) for now.

## Example

