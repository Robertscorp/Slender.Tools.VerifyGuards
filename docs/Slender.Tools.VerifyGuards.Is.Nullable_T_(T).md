### [Slender.Tools.VerifyGuards](Slender.Tools.VerifyGuards.md 'Slender.Tools.VerifyGuards').[Is](Slender.Tools.VerifyGuards.Is.md 'Slender.Tools.VerifyGuards.Is')

## Is.Nullable<T>(T) Method

Declares that a parameter will not be guarded against null values.

```csharp
public static T Nullable<T>(T value);
```
#### Type parameters

<a name='Slender.Tools.VerifyGuards.Is.Nullable_T_(T).T'></a>

`T`

The type of parameter.
#### Parameters

<a name='Slender.Tools.VerifyGuards.Is.Nullable_T_(T).value'></a>

`value` [T](Slender.Tools.VerifyGuards.Is.Nullable_T_(T).md#Slender.Tools.VerifyGuards.Is.Nullable_T_(T).T 'Slender.Tools.VerifyGuards.Is.Nullable<T>(T).T')

The value for the parameter when verifying other parameters. Must pass all guards.

#### Returns
[T](Slender.Tools.VerifyGuards.Is.Nullable_T_(T).md#Slender.Tools.VerifyGuards.Is.Nullable_T_(T).T 'Slender.Tools.VerifyGuards.Is.Nullable<T>(T).T')

### Remarks
This method represents a parameter within an Expression; it should not be used outside an Expression.