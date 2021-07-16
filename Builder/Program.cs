using System;

namespace Builder
{
    interface IBedBuilder
    {
      void MakeFrame();
      void MakeMattress();
      void MakeSheet(string sheet);
      void MakePillow(int size);
      Bed Build();
    }

    class Ace : IBedBuilder
    {
      private Bed _bed = new Bed();
      private int pillowSize = 1;
      private string sheetName;
      public Bed Build(){
        _bed.Pillow = "Pillow size #" + pillowSize;
        _bed.Sheet = "Sheet " + sheetName;
        return _bed;
      }

      public void MakeFrame(){
        _bed.Frame = (DateTime.Now.Month > 5 && DateTime.Now.Month < 9) ? "Ace Summer Frame" : "Ace Wood Frame";
      }

      public void MakeMattress(){
        _bed.Mattress = "Ace Mattress";
      }

      public void MakePillow(int size){
        pillowSize = size;
      }

      public void MakeSheet(string sheet){
        sheetName = sheet;
      }
    }
    class Simons : IBedBuilder
    {
      private Bed _bed = new Bed();
      private int pillowSize = 0;
      private string sheetName;
      public Bed Build(){
        _bed.Pillow = "Pillow size #" + pillowSize;
        _bed.Sheet = "Sheet " + sheetName;
        return _bed;
      }

      public void MakeFrame(){
        _bed.Frame = (DateTime.Now.Month > 5 && DateTime.Now.Month < 9) ? "Simons Summer Frame" : "Simons Wood Frame";
      }

      public void MakeMattress(){
        _bed.Mattress = "Simons Mattress";
      }

      public void MakePillow(int size){
        pillowSize = size;
      }

      public void MakeSheet(string sheet){
        sheetName = sheet;
      }
    }

    class Bed
    {
      public string Frame{get; set;}
      public string Mattress{get; set;}
      public string Pillow{get; set;}
      public string Sheet{ get; set; }
      public override string ToString(){
        return string.Format("{0} {1} {2} {3}", Frame, Mattress, Pillow, Sheet);
      }
    }

    // Director
    class Director{
      public Bed Construct(IBedBuilder builder)
      {
        builder.MakeFrame();
        builder.MakeMattress();
        builder.MakeSheet("White");
        Bed bed = builder.Build();
        return bed;
      }
    }

    class Client
    {
      public static void HowToTest(){
        IBedBuilder builder = new Simons();
        var director = new Director();
        var bed = director.Construct(builder);
        Console.WriteLine(bed.ToString());
        
        IBedBuilder aceBuilder = new Ace();
        var aceDirector = new Director();
        var aceBed = director.Construct(aceBuilder);
        Console.WriteLine(aceBed.ToString());

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

