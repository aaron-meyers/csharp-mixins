# csharp-patterns
Various design patterns for C#

TODO: disciminated union pattern
```
public abstract class NamedUnion {
  // Private ctor with nested concrete types so the set of types is truly restricted
  private NamedUnion() {
  }
  
  // Access methods:
  // 1. as/switch on specific union types
  // 2. Map() method, e.g. Map<T>(Func<UnionType1, T> mapType1, Func<UnionType2, T> mapType2)
  // 3. Visitor pattern, e.g. INamedUnionVisitor with Visit methods for each UnionTypeN and types implement Accept method
  // (Map is basically just an object-less version of Visitor pattern)
  
  public sealed class UnionType1 : NamedUnion {
  }
  
  public sealed class UnionType2 : NamedUnion {
  }
}
```
