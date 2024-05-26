## Slender.Tools.VerifyGuards.GuardException :<br/> '_Param_' has been defined as nullable, but is a non-nullable value type.
This message occurs when the parameter '_Param_' has been defined as nullable in the Verify.Guards method, but is a non-nullable value type.

## Example
In the following example, the guard will fail because `int dependency` is a non-nullable value type and is declared as nullable in the Verify.
```csharp
public class Example
{

    public Example(int dependency) { }

}
```
```csharp
Verify.Guards(() => new Example(Is.Nullable<int>()));
```
## How To Fix
### When '_dependency_' is supposed to be nullable
```csharp
public Example(int dependency) { }

// Change to:

public Example(int? dependency) { }
```
### When '_dependency_' is supposed to be not nullable
```csharp
Verify.Guards(() => new Example(Is.Nullable<int>()));

// Change to:

Verify.Guards(() => new Example(Is.NotNullable<int>()));
```