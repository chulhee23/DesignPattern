/*
공식적인 디자인 패턴은 아니지만, 
하나의 메서드에서 특정 객체를 생성하는 단순한 팩토리 기능

new 를 사용하여 단순히 객체만을 얻어오는 것이 아닌, 복잡한 절차를 필요로 할 때
객체 생성 작업이 코드의 여러 곳에서 사용될 때 중복을 피하기 위해
*/

namespace SimpleFactory
{
  class DbLogger{}
  class LoggerFactory{
    public DbLogger CreateDbLogger(){
      string connStr = Configuration.Settings["DBConn"].ToString();
      var db = new DbLogger();
      db.TimeOut = 60;
      // db.Error += () => {/* ~~~ */}
      return db;

    }
  }

}