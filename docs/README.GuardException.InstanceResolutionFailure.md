## Guard Exception
### Could not get an instance of '_Dependency_'. If possible, manually provide an instance of '_Dependency_' to resolve this issue.
This message occurs when the package is unable to create an instance of '_Dependency_'.

This means that somewhere in the constructor dependency tree, a constructor is throwing an exception because it does not accept the default value provided by the package.

## Example
In the following example, both tests will fail with the same message, because the value provided to `int i` by the package will be 0.
```csharp
public class Dependency
{

    public Dependency(int i)
        => ArgumentOutOfRangeException.ThrowIfNegativeOrZero(i);

    public void InstanceMethod(string s) { }

}

public class Example
{

    public Example(Dependency dependency) { }

}

public class UnitTests
{

    [Fact]
    public void CannotConstructDependency()
        => Verify.Guards(() => new Example(Is.Nullable<Dependency>()));

    [Fact]
    public void CannotConstructDependency()
        => Verify.Guards((Dependency d) => d.InstanceMethod(Is.Nullable<string>())));

}
```
## How To Fix
### When '_Dependency_' is an invocation parameter (Example Test 1)
```csharp
() => new Example(Is.Nullable<Dependency>())

// Change to any of:

() => new Example(Is.Nullable(new Dependency(1)))   // Constructor
() => new Example(Is.Nullable(this.m_Dependency))   // Field
() => new Example(Is.Nullable(dependency))          // Parameter
() => new Example(Is.Nullable(_Dependency))         // Variable
```
### When '_Dependency_' is an expression parameter (Example Test 2)
```csharp
(Dependency d) => d.InstanceMethod(Is.Nullable<string>())

// Change to any of:

() => new Dependency(1).InstanceMethod(Is.Nullable<string>())   // Constructor
() => this.m_Dependency.InstanceMethod(Is.Nullable<string>())   // Field
() => dependency.InstanceMethod(Is.Nullable<string>())          // Parameter
() => _Dependency.InstanceMethod(Is.Nullable<string>())         // Variable
```