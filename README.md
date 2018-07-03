# Conan.Plugin.NullGuard  [![Build status](https://ci.appveyor.com/api/projects/status/ov3kvojeu4s5ymxc/branch/master?svg=true)](https://ci.appveyor.com/project/lecaillon/conan-plugin-nullguard)

<img align="right" width="256px" height="256px" src="https://raw.githubusercontent.com/conan-roslyn/Conan/master/img/conan.png">

Conan.Plugin.NullGuard adds null guard code for all methods and constructors parameters preceded by any `[NonNull]` attribute.

It is based on [Conan](https://github.com/conan-roslyn/Conan), a _lightweight_ fork of the [.NET Compiler Platform ("Roslyn")](https://github.com/dotnet/roslyn/) by adding a **compiler plugin infrastructure**. These plugins can be deployed and installed as regular Diagnostic Analyzers.

## Notice

> This plugin is an alpha version, whose purpose is to see where the very promising Conan compiler plugin infrastructure can bring us.

## Getting started

1. Add the package `Conan.Net.Compilers` to your project: This will make the Conan compiler as the default CSharp/VB compiler and replace the default Roslyn compiler (This package works for both Full framework and Core framework unlike the Roslyn packages)
2. Add the package `Conan.Plugin.NullGuard` only available on [AppVeyor](https://ci.appveyor.com/project/lecaillon/conan-plugin-nullguard/build/artifacts) for now.

## Example

1. Add a `[NonNull]` attribute to any constructor or method reference type parameter you want to check.

```c#
public class Person
{
  private readonly string _name;
  private readonly int _age;

  public Person([NonNull] string name, int age)
  {
    _name = name;
    _age = age;
  }
}
```

2. At build time the Conan Compiler will automatically insert at the beginning of the constructor the statement needed to ensure the parameter `name` is not null.

```c#
public class Person
{
  private readonly string _name;
  private readonly int _age;

  public Person([NonNull] string name, int age)
  {
    if (name == null)
    {
      throw new ArgumentNullException("name");
    }

    _name = name;
    _age = age;
  }
}
```

You can see rewritten documents on the disk in a sub directory of the obj folder or using ILSpy.

## Licensing

Same license than Roslyn: [Apache-2.0](roslyn/License.txt)

## Credits

Alexandre MUTEL aka [xoofx](http://xoofx.com)
