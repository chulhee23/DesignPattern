using System;
using System.Collections.Generic;

namespace Composite
{

  // 여러 클래스가 인터페이스를 구현해야하는 경우 인터페이스가 추상 클래스보다 낫습니다.
  // 인터페이스 멤버는 정적일 수 없으며, 추상 클래스의 유일한 완전한 멤버는 정적 일 수 있습니다.
  public interface IComponent
  {
    void Display();
  }

  public class Leaf : IComponent
  {
    private string _name;
    public Leaf(string name)
    {
      _name = name;
    }
    public void Display()
    {
      Console.WriteLine($"Leaf : {_name}");
    }
  }

  public class Composite : IComponent
  {
    private List<IComponent> _children; // private 멤버 변수 선언은 _camelCase;
    private string _name;
    public Composite(string name)
    {
      this._name = name;
      _children = new List<IComponent>(); // 빈 children 
    }

    public void Display()
    {
      Console.WriteLine($"Composite : {_name}");
      foreach (var child in _children)
      {
        Console.Write($"leaves of {this._name} - ");
        child.Display();
      }
    }

    public void Add(IComponent child)
    {
      if (child != null)
      {
        _children.Add(child);
      }
    }

  }


  class Program
  {
    static void Main(string[] args)
    {
      Composite root = new Composite("Root #1");
      root.Add(new Leaf("leaf #1"));
      root.Add(new Leaf("leaf #2"));
      root.Add(new Leaf("leaf #3"));
      Composite subRoot = new Composite("Root #2");
      subRoot.Add(new Leaf("leaf #4"));
      subRoot.Add(new Leaf("leaf #5"));

      Composite subSubRoot = new Composite("Root #3");
      subSubRoot.Add(new Leaf("leaf #6"));
      subSubRoot.Add(new Leaf("leaf #7"));

      root.Add(subRoot);
      subRoot.Add(subSubRoot);

      root.Display();

    }
  }
}
