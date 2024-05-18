## Guard Exception
### '_Param_' has been defined as not nullable, but is a nullable value type.
This message occurs when the parameter '_Param_' has been defined as not nullable in the Verify.Guards method, but is a nullable value type.

## Example
In the following example, the test will fail because `int? dependency` is a nullable value type and is declared as not nullable in the Verify.
```csharp
public class Example
{

    public Example(int? dependency) { }

}

public class UnitTests
{

    [Fact]
    public void DependecyIsNotNullable()
        => Verify.Guards(() => new Example(Is.NotNullable<int?>()));

}
```
## How To Fix
### When '_dependency_' is supposed to be not nullable
```csharp
public Example(int? dependency) { }

// Change to:

public Example(int dependency) { }
```
### When '_dependency_' is supposed to be nullable
```csharp
Verify.Guards(() => new Example(Is.NotNullable<int?>()));

// Change to:

Verify.Guards(() => new Example(Is.Nullable<int?>()));
```