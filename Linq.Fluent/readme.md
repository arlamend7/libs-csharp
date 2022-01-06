This lib was create to help code`s reads.

examples:

```csharp 
 var listComplexValue = new List<Complex>();

 listComplexValue.WhereParam(x => x.Boolean).IsTrue();
 listComplexValue.WhereParam(x => x.Boolean).IsFalse();
 listComplexValue.WhereParam(x => x.Int).IsBetween(0, 2);
 listComplexValue.WhereParam(x => x.Int).In(1,2,3);
 listComplexValue.WhereParam(x => x.Int).Like('2');

```

## Open source code.
For anyone who wants to code for comunity.

Repository: https://github.com/arlamend7/libs-csharp
