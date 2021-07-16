// Static Factory Method
// 하나의 정적 메소드가 클래스 혹은 서브 클래스의 객체를 리턴하는 일종의 팩토리 패턴
namespace StaticFactory
{
  interface ILogger{}
  class DbLogger : ILogger{}
  class XmlLogger : ILogger{}
  class JsonLogger : ILogger{}

  class LoggerFactory
  {
    // static factory method
    // loggerType 을 enum 으로 하는 것이 일반적
    public static ILogger Create(string loggerType)
    {
      ILogger logger = null;
      switch(loggerType)
      {
        case "DB":
          logger = new DbLogger();
          break;
        case "XML":
          logger = new XmlLogger();
          break;
        case "JSON":
          logger = new JsonLogger();
          break;
        default:
          throw new InvalidOperationException();
      }
      return logger;
    }
  }

  class Client
  {
    void HowToTest(){
      ILogger dbLogger = LoggerFactory.Create("DB");
      ILogger xmlLogger = LoggerFactory.Create("XML");
    }
  }
}