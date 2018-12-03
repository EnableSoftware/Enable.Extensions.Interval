# Enable.Extensions.Interval

`Enable.Extensions.Interval` provides a simple implementation of
[intervals](https://en.wikipedia.org/wiki/Interval_(mathematics)) in C#.

# Examples

An `Interval<T>` is created by specifying the *inclusive* lower and upper
bounds for the interval. For example, for integer values, we can create an 
interval that represents the numbers zero to ten:

```csharp
var interval = new Interval<int>(0, 10);
```

We can now test whether other integers fall within this range:

```csharp
interval.Contains(-1); // returns `false`.
interval.Contains(0); // returns `true`.
interval.Contains(1); // returns `true`.
…
interval.Contains(10); // returns `true`.
interval.Contains(11); // returns `false`.
```

Intervals can be used with any type that implements
[`IComparable`](https://docs.microsoft.com/dotnet/api/system.icomparable),
for example, integer types like `byte`, `char` and `long`, floating point
types like `float`, `double` and `decimal` and date/time types like `TimeSpan`
and `DateTimeOffset`.
