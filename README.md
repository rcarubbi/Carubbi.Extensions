# Carubbi.Extensions
A simple library extension-method based to common tasks

* Datatype conversions:

Rather than 
```csharp
int? intVariable;
try
{
    intVariable = Convert.ToInt32(str);
}
catch(Exception ex)
{
    intVariable = defaultValue;
}
```

or 

```csharp
  if (!int.TryParse(str, out int intValue))
  {
      intValue = defaultValue;
  }
```

You just use

```csharp
int? intVariable = str.To<int>(defaultValue);
```
