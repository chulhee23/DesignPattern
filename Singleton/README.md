# Singleton 패턴
일반적인 싱글톤을 사용하는 방법을 Program.cs 파일에 작성했다.
문제는 이렇게 작성하면 thread-safe 하지 않다.

그렇기에 lock 을 사용하여 thread-safe 하게 작성해보자.
## Thread safe
```C#
public class Singleton
    {
        private static Singleton _instance;
        private static readonly object _lock = new object();
 
        private Singleton() { }
 
        public static Singleton Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                    return _instance;
                }
            }
        }
    }
```

### 문제점
lock 인스턴스를 항상 요구하기 때문에, 성능이 다소 떨어지는 문제 발생.
-> lazy implementation을 사용하자!
쓰기 전까지 생성하지말자!

## Lazy Implementation(Thread-safe & 성능 향상)
```c#
public class Singleton
    {
        private static readonly Lazy<Singleton> instance =
        new Lazy<Singleton>(() => new Singleton());
 
        public static Singleton Instance
        {
            get
            {
                return instance.Value;
            }
        }
 
        private Singleton()
        {
        }
    }
```
사용하기 전까지 인스턴스 생성도 하지 않으며, 스레드에도 안전하다.
