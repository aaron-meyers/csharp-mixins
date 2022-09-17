// Note: this only works against ICounterMixin, not the ThingWithCounter class :(
// (default interface members are considered 'explicitly implemented')
ICounterMixin thing = new ThingWithCounter();

thing.Increment();
Console.WriteLine($"Value: {thing.CounterValue}");

var delegatedThing = new ThingWithCounterDelegation();

delegatedThing.Increment();
Console.WriteLine($"Value: {delegatedThing.CounterValue}");

public class ThingWithCounter : ICounterMixin {
    private readonly CounterMixin _counterMixin = new CounterMixin();
    CounterMixin ICounterMixin.MixinImpl => _counterMixin;
}

public class ThingWithCounterDelegation {
    private readonly CounterMixin _counterMixin = new CounterMixin();
    public void Increment() =>_counterMixin.Increment();
    public int CounterValue { get => _counterMixin.CounterValue; }
}

public class CounterMixin {
  private int _value;

  public void Increment() => _value++;
  public int CounterValue => _value;
}

public interface ICounterMixin {
  CounterMixin MixinImpl{get;}
  void Increment() => MixinImpl.Increment();
  int CounterValue{
    get => MixinImpl.CounterValue;
  }
}