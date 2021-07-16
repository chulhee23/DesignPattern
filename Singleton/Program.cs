using System;

namespace Singleton
{
  public sealed class Singleton
  {
    public static readonly Singleton Instance = new Singleton();

    private Singleton() { }

    public void Method()
    {
      Console.WriteLine("...");
    }
  }

  class Client
  {
    public static void HowToTest()
    {
      Singleton.Instance.Method();
    }
  }

  class MainClass
  {
    public static void Main(string[] args)
    {
      Client.HowToTest();

    }
  }

}
