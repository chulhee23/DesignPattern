using System;

namespace Builder
{
    public interface IBedBuilder
    {
      void MakeFrame();
      void MakeMattress();
      void MakeSheet(string sheet);
      void MakePillow(int size);
      Bed Build();
    }

    public class Simons : IBedBuilder
    {
      private Builder _bed = new Bed();
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
        _bed.Mattresss = "Simons Mattress";
      }

      public void MakePillow(int size){
        pillowSize = size;
      }

      public void MakeSheet(string sheet){
        sheetName = sheet;
      }
    }

    public class Bed
    {
      public string Frame{get; set;}
      public string Mattresss{get; set;}
      public string Pillow{get; set;}
      public string Sheet{ get; set; }
      public override string ToString(){
        return string.Format("{0} {1} {2} {3}", Frame, Mattresss, Pillow, Sheet);
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
      void HowToTest(){
        IBedBuilder builder = new Simons();
        var director = new Director();
        var bed = director.Construct(builder);
        Console.WriteLine(bed.ToString());
      }
    }
}
