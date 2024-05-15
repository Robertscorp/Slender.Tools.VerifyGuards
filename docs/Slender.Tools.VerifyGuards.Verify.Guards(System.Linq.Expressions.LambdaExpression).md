### [Slender.Tools.VerifyGuards](Slender.Tools.VerifyGuards.md 'Slender.Tools.VerifyGuards').[Verify](Slender.Tools.VerifyGuards.Verify.md 'Slender.Tools.VerifyGuards.Verify')

## Verify.Guards(LambdaExpression) Method

Verifies that the parameters of an invocation are being correctly guarded.

```csharp
public static void Guards(System.Linq.Expressions.LambdaExpression expression);
```
#### Parameters

<a name='Slender.Tools.VerifyGuards.Verify.Guards(System.Linq.Expressions.LambdaExpression).expression'></a>

`expression` [System.Linq.Expressions.LambdaExpression](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.LambdaExpression 'System.Linq.Expressions.LambdaExpression')

An expression which represents an invocation, and the expected guards for the parameters of the invocation.<br/><br/>  
Supports constructors, and instance and static methods.<br/><br/>  
  
```csharp  
() => new Class(Is.Nullable<T>(), ...)  
```  
  
```csharp  
() => Class.StaticMethod(Is.Nullable<T>(), ...)  
```  
  
```csharp  
(Class c) => c.InstanceMethod(Is.Nullable<T>(), ...)  
```

#### Exceptions

[GuardException](Slender.Tools.VerifyGuards.GuardException.md 'Slender.Tools.VerifyGuards.GuardException')  
Thrown when the actual guards within the invocation do not match the expected guards defined in the specified [expression](Slender.Tools.VerifyGuards.Verify.Guards(System.Linq.Expressions.LambdaExpression).md#Slender.Tools.VerifyGuards.Verify.Guards(System.Linq.Expressions.LambdaExpression).expression 'Slender.Tools.VerifyGuards.Verify.Guards(System.Linq.Expressions.LambdaExpression).expression').