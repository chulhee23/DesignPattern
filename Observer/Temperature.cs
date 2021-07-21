using System;
using System.Windows.Forms;


namespace Observer2
{
  class Temperature{
    public event EventHandler Changed;

    private float _fahrenheit;
    public float Fahrenheit{
      get{ return this._fahrenheit;}
      set {
        this._fahrenheit = value;
        if(Changed != null){
          Changed(this, EventArgs.Empty);
        }
      }
    }

    public void StartMeasure(int times){
      Random r = new Random(DateTime.Now.Millisecond);

      for(int i = 0; i < times; i++){
        // 1초마다 임의의 수로 온도 재지정
        this.Fahrenheit = r.Next(60, 70);
        Thread.Sleep(1000);
      }
    }
  }

  public class Form1 : Form{
    internal static Temperature Temp = new Temperature();

    private TextBox textBox1;
    public Form1(){
      this.textBox1 = new TextBox();
      this.Controls.Add(this.textBox1);
      this.Load += new EventHandler(Form1_Load);
    }

    private void Form1_Load(object sender, EventArgs e){
      //changed 이벤트에 observer 로 등록
      // 메서드 대신 람다식도 사용해보자!
      Temp.Changed += (s, ex) => {
        this.Invoke(new Action(() => {
          textBox1.Text = Temp.Fahrenheit.ToString();
        }));
      };

      var f2 = new Form2();
      f2.Show();

      Task.Factory.StartNew(() => Temp.StartMeasure(10));
    }
  }
  
}