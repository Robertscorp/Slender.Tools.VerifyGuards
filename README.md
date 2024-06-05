<h3 align=center>
<img src="media/VerifyGuards.svg" width=50%>
</h3>

Slender.Tools.VerifyGaurds is a simple .NET library for easily writing tests for guard clauses.

[![NuGet](https://img.shields.io/nuget/v/Slender.Tools.VerifyGuards)](https://www.nuget.org/packages/Slender.Tools.VerifyGuards) [![NuGet](https://img.shields.io/nuget/dt/Slender.Tools.VerifyGuards)](https://www.nuget.org/packages/Slender.Tools.VerifyGuards)
### Usage
```c#
public class MyClass
{

    public MyClass(string notNullableValue, string nullableValue)
    {
        if (notNullableValue is null) throw new ArgumentNullException(nameof(notNullableValue));
    }
    
    public void InstanceMethod(string notNullableValue, string nullableValue)
    {
        if (notNullableValue is null) throw new ArgumentNullException(nameof(notNullableValue));
    }
    
    public static void StaticMethod(string notNullableValue, string nullableValue)
    {
        if (notNullableValue is null) throw new ArgumentNullException(nameof(notNullableValue));
    }

}
```
##### Verifying Guards for Constructors
```c#
Verify.Guards(() => new MyClass(Is.NotNullable<string>(), Is.Nullable<string>()));
```
##### Verifying Guards for Instance Methods
###### Accessing an instance through an expression parameter
```c#
Verify.Guards((MyClass c) => c.InstanceMethod(Is.NotNullable<string>(), Is.Nullable<string>()));
```
###### Accessing an instance through a field
```c#
private readonly MyClass m_MyClass = new MyClass(string.Empty, default);
Verify.Guards(() => this.m_MyClass.InstanceMethod(Is.NotNullable<string>(), Is.Nullable<string>()));
```
###### Accessing an instance through a variable
```c#
var _MyClass = new MyClass(string.Empty, default);
Verify.Guards(() => _MyClass.InstanceMethod(Is.NotNullable<string>(), Is.Nullable<string>()));
```
###### Accessing an instance through a contructor
```c#
Verify.Guards(() => new MyClass(string.Empty, default).InstanceMethod(Is.NotNullable<string>(), Is.Nullable<string>()));
```
###### Accessing an instance through a method parameter
```c#
public void VerifyGuardsForInstanceMethod(MyClass myClass)
    => Verify.Guards(() => myClass.InstanceMethod(Is.NotNullable<string>(), Is.Nullable<string>()));
```
##### Verifying Guards for Static Methods
```c#
Verify.Guards(() => MyClass.StaticMethod(Is.NotNullable<string>(), Is.Nullable<string>()));
```
### Resolving Guard Exceptions
Need some help resolving a GuardException? Check out the links below.
- ['_Param_' has been defined as not nullable, but is a nullable value type.](docs/README.GuardException.NotNullableNullValueType.md 'Click for help')
- ['_Param_' has been defined as not nullable, but is not guarded against null values.](docs/README.GuardException.UnguardedNotNullable.md 'Click for help')
- ['_Param_' has been defined as nullable, but is a non-nullable value type.](docs/README.GuardException.NullableNotNullValueType.md 'Click for help')
- ['_Param_' has been defined as nullable, but is guarded against null values.](docs/README.GuardException.GuardedNullable.md 'Click for help')
- [Could not get an instance of '_Dependency_'. If possible, manually provide an instance of '_Dependency_' to resolve this issue.](docs/README.GuardException.InstanceResolutionFailure.md 'Click for help')
- [Could not parse expression tree, the specified expression is not supported.](docs/README.GuardException.UnsupportedExpression.md 'Click for help')
### Docs
Interested in learning more? Check out the [docs](docs/Slender.Tools.VerifyGuards.md 'Slender.Tools.VerifyGuards').
### Leave a Star :star:
Like the project? Please leave a star!