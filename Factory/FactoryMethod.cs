/*
객체를 생성하는 메서드가 하나의 팩토리 인터페이스에 정의,
인터페이스를 구현하는 하나 이상의 팩토리 서브 클래스로 구성

-> 객체를 생성하는 팩토리 서브 클래스가 여러 개일 때 유용
*/

namespace FactoryMethod {
  interface ILog{
    void Write(string s);
  } 

  class XmlLog : ILog 
  {
    private string xmlFile;
    public XmlLog(string xmlfile){
      this.xmlFile = xmlfile;
    }
    public void Write(string s)
    {
      return;
    }

  }

  class DbLog : ILog
  {
    private string connString;
    public DbLog(string connString){this.connString = connString;}
    public void Write(string s){}
  }

  abstract class LogFactory
  {
    protected abstract ILog GetLog();
    public void Log(string message)
    {
      // 아직 어떤 로그 타입을 사용할지 모름
      var logger = GetLog();
      logger.Write($"{DateTime.Now}: {message}");
    }

    public static LogFactory GetLogger(){
      string logType = ConfigurationManage.AppSettings["LogType"];
      switch(logType)
      {
        case "DB":
          return new XmlLogFactory();
        case "XML":
          return new DbLogFactory();
        default:
          return new ApplicationException();
      }
    }
  }

  class XmlLogFactory : LogFactory
  {
    // Factory Method 패턴 : Override
    protected override ILog GetLog()
    {
      string logfile = ConfigurationManager.AppSettings["XmlFile"];
      var xmlLog = new XmlLog(logfile);
      return xmlLog;
    }
  }

  class DbLogFactory : LogFactory
  {
    protected override ILog GetLog()
    {
      string connString = ConfigurationManager.AppSettings["DBConn"];
      return new DbLog(connString);
    }
  }

  class Client
  {
    public void HowToTest1()
    {
      LogFactory logger = new XmlLogFactory();
      logger.Log("Log something");
    }

    /*
    public void HowToTest2()
    {
      LogFactory logger = LogFactory.GetLogger();
      logger.Log("Log something");
    }
    */
  }
}