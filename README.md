# EfCoreDeadlockTest

Ef Core 2.1 causes a Deadlock when using in a WPF Application and calling `.Wait()` on an async Operation.

```csharp
var query = context.Authors.Include(a => a.Books);

var t = query.ToListAsync();
t.Wait();           // Deadlock
return t.Result;
```
