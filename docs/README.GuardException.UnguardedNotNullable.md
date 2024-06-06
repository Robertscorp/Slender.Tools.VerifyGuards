## Slender.Tools.VerifyGuards.GuardException :<br/> '_Param_' has been defined as not nullable, but is not guarded against null values.
This message occurs when the parameter '_Param_' has been defined as not nullable in the Verify.Guards method, but an ArgumentNullException is not thrown if the value of '_Param_' is null.

## Example
In the following example, the guard will fail because `Dependency dependency` is not guarded against null values and is declared as not nullable in the Verify.
```csharp
public class Dependency { }

public class Example
{

    public Example(Dependency dependency) { }

}
```
```csharp
Verify.Guards(() => new Example(Is.NotNullable<Dependency>()));
```
## How To Fix
### When '_dependency_' is supposed to be not nullable
```csharp
public Example(Dependency dependency) { }

// Change to:

public Example(Dependency dependency)
    => ArgumentNullException.ThrowIfNull(dependency, nameof(dependency));
```
### When '_dependency_' is supposed to be nullable
```csharp
Verify.Guards(() => new Example(Is.NotNullable<Dependency>()));

// Change to:

Verify.Guards(() => new Example(Is.Nullable<Dependency>()));
```