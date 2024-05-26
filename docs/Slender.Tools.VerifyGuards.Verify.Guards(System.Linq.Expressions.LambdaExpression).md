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
Supports constructors, instance methods, and static methods.<br/><br/>  
Constructors:  
  
```csharp  
() => new Class(Is.Nullable<T>(), ...)  
```
Instance Methods:  
  
```csharp  
(Class c) => c.InstanceMethod(Is.Nullable<T>(), ...)  
```  
  
```csharp  
() => new Class(...).InstanceMethod(Is.Nullable<T>(), ...)  
```  
  
```csharp  
() => classParameter.InstanceMethod(Is.Nullable<T>(), ...)  
```  
  
```csharp  
() => _ClassVariable.InstanceMethod(Is.Nullable<T>(), ...)  
```  
  
```csharp  
() => this.m_ClassField.InstanceMethod(Is.Nullable<T>(), ...)  
``` 
Static Methods:  
  
```csharp  
() => Class.StaticMethod(Is.Nullable<T>(), ...)  
```

#### Exceptions

[GuardException](Slender.Tools.VerifyGuards.GuardException.md 'Slender.Tools.VerifyGuards.GuardException')  
Thrown when:  
 - The expression contains a parameter that has been defined as not nullable, but is a nullable value type.  
 - The expression contains a parameter that has been defined as not nullable, but is not guarded against null values.  
 - The expression contains a parameter that has been defined as nullable, but is a non-nullable value type.  
 - The expression contains a parameter that has been defined as nullable, but is guarded against null values.  
 - The expression is not supported.  
 - The expression requires resolving a value and the constructor for that value is throwing an exception.