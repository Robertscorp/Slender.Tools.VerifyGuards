## Slender.Tools.VerifyGuards.GuardException :<br/> Could not parse expression tree, the specified expression is not supported.
This message occurs when the expression passed into the Verify.Guards method is not supported.

## Example
In the following example, the guards will fail with the same message because the expressions are not supported.
```csharp
public class Example
{

    public Example(string str, int i, Dependency dependency) { }

}
```
```csharp
Verify.Guards(() => new Example(default, 1, Is.Nullable<Dependency>())); // All parameters must only be Is.Nullable<T> or Is.NotNullable<T>
Verify.Guards(() => 10 + 10);
Verify.Guards(() => (decimal)10);
Verify.Guards(() => string.Empty);
```
## How To Fix
To resolve this issue, you will need to re-write the expression in a way that is supported. <br/>Ensure that all invocation parameters are either Is.Nullable&lt;T&gt; or Is.NotNullable&lt;T&gt;.<br/>To see the list of supported expressions, refer to the [Usage](/README.md#Usage 'Usage') section of the readme.