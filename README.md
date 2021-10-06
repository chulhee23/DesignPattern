# 목차 

- [Observer 패턴](#Observer-패턴) 
- [Adapter 패턴](#Adapter-패턴) 
- [Composite 패턴](#Composite-패턴) 
- [Singleton 패턴](#Singleton-패턴) 
- [Builder 패턴](#Builder-패턴) 
- [Factory 패턴](#Factory-패턴) 
- [Strategy 패턴](#Strategy-패턴) 


# Observer 패턴
- 하나의 객체가 변화하면, 그 객체에 의존하는 다른 모든 객체에게 변화를 자동으로 통지하는 패턴

- Subject 클래스와 Observer 클래스로 구성
Subject 객체의 변화에 따라, Observer 객체들이 자동으로 변화해야 하는 곳에 사용된다.
일대다의 관계이면서, 서로 긴밀하지 않는 관계를 갖는다.

Observer 패턴에서 Subject 클래스는 통지를 보내야하는 Observer 객체들에 대한 리스트를 관리,
상태변화시 Observer에게 통지를 보내는 일을 수행한다.

- Subject
    - observers (컬렉션 필드)
    - Observer 등록 메서드
    - 통지 보내는 메서드

- Observer
    - Subject로부터 통지 받은 후 필요한 동작 수행하기 위한 메서드를 구현

C#에서는 event를 사용해서 Observer 패턴을 조금 더 쉽게 구현할 수 있다.
Subject 클래스에서 C# event를 public으로 정의하고, 
외부에서 Observer 가 이 event에 직접 가입할 수 있도록 한다.
Observer 객체가 event에 관찰자로서 가입(subscribe)하면 
이벤트 통지시 실행할 메서드를 이벤트 핸들러로 바로 등록한다.



# Adapter 패턴
기존 라이브러리, 시스템의 기능을 사용하고자 하나, 
그 인터페이스가 현재 시스템과 맞지 않을 때, 
혹은 중간 어댑터 인터페이스를 통해 여러 다양한 시스템들을 바꿔가며 사용하고자 할 때 흔히 사용.
현재 시스템과 사용하고자 하는 시스템 간의 호환되지 않는 인터페이스를 중간에 Adapter 인터페이스를 사용하여 연결해주는 디자인 방식.

어댑터 인터페이스를 구현해서 사용하면 기존 클래스들을 그대로 사용할 수 있으며,
**클라이언트는 자신이 Adapter를 통하는지, 직접 타겟 클래스 사용하는지 알 필요가 없다!**


- **Object Adpater Pattern**
    - Adapter 클래스가 Adaptee 객체를 자신의 멤버로 내포하는 Composition 방식 사용
- **Class Adapter Pattern**
    - Adapter 클래스가 상속을 통해 클라이언트와 Adaptee 간의 불일치 문제를 해결
    - C#은 다중 상속을 지원하지 않으므로 클라이언트가 호출하는 ITarget 인터페이스를 만들고,
    Adapter 클래스가 Adaptee 클래스를 상속하면서 ITarget 인터페이스를 구현하여 작성

Program.cs 파일은 HDMI 가진 컴퓨터에서 기존 VGA 모니터에 출력하기 위해
HDMI-VGA 변환을 수행하는 어댑터를 사용하는 가상의 시나리오이다!

## .NET Framework 에서의 Adapter 패턴 사례
.NET 개발 이전 COM 컴포넌트가 여전히 사용되기도 하는데,
Runtime Callable Wrapper 라는 중간 어댑터 클래스가 사용된다.





# Composite 패턴
구조 패턴
- 개별 객체나 객체들의 그룹을 클라이언트 입장에서 동일하게 취급하고 사용할 수 있게 하는 구조를 갖는 패턴
- 이를 위해 객체, 객체 그룹을 트리 구조로 만들어 계층을 표현

개별 객체(Leaf)나, 객체 그룹(Composite)에 공통적으로 적용되는 인터페이스(Component)를 정의하여 사용한다.

- Leaf
    - Component 인터페이스에 정의된 행위를 직접 구현
- Composite 
    - Component 인터페이스 구현할 때,
    Composite 안에 포함된 개별 객체에게 Component 인터페이스 요청을 전달하는 방식




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



# Builder 패턴
> 생성자가 많다면? 빌더 패턴을 고려해보자!
- 생성 패턴
주로 복잡한 객체를 생성할 때 사용

- Builder 클래스에 객체를 생성하기 위한 여러 스텝을 정의
- Director 라는 클래스에서 Builder의 스텝(기능)을 필요에 따라 선택하여 빌드한다.
-> 부품을 조합하여 복합 객체를 반드는 방식
- 생성자가 많고, 변경 불가능한 객체를 만들고 싶을 때!
    - setter를 사용하지 않으므로 가능하다

## 구성
- Product 클래스
    - Build 하는 대상
- Builder 인터페이스
    - Product 객체를 빌드하는데 사용되는 여러 개의 스텝을 만든느 과정을 추상화함
- Director 클래스
    - Builder/ConcreteBuilder 를 사용하여 어떤 스텝들 혹은 부분기능을 사용할 지 결정

## 예제
시몬스 침대를 만드는 Concrete Builder (Simons 클래스) 작성

Director 클래스는 IBedBuilder 메서드 중, 3개만 선택하여 침대를 만들고 있음.
- MakeFrame
- MakeMattress
- MakeSheet

## Fluent Builder
빌더 패턴을 약간 변형하여 빌드 스텝 메서드가 void 대신 builder 인터페이스를 리턴하여 메서드를 연달아 호출.

```C#
public interface IBedBuilder
{
    IBedBuilder MakeFrame();
    IBedBuilder MakeMattress();
    IBedBuilder MakeSheet(string sheet);
    IBedBuilder MakePillow(int size);
    Bed Build();
}
```
와 같이 사용한다면,
```C#
var bed = builder.MakeFrame().MakeMattress().MakePillow().Build();
```
로 사용할 수 있다.

### 왜 등장했을까?
생성자로 단순히 만드는 것과 차이가 있는데, 
생성자에는 제약이 하나 있는데, 선택적 매개변수가 많을 경우에 대응이 어렵다. 
예를 들어, 받아오는 매개변수에 따라 계속해서 생성되는 생성자의 코드를 보았을때 
매개변수의 개수에 따라 호출되는 생성자를 짐작하기가 매우 혼잡해진다. 
또는 생성자 호출을 위해서 설정하길 원하지 않는 매개변수의 값까지 지정해줘야하는 불편함이 있다. 
한 두개 정도는 괜찮을 수 있겠지만, 
매개변수의 수가 늘어나게되면 걷잡을 수 없을정도가 된다.

### 핵심
- 생성자가 많고, 
- 변경 불가능한 객체를 만들고 싶을 때!
    - setter를 사용했다면, 변경이 가능하다!



## 레퍼런스
    - https://johngrib.github.io/wiki/builder-pattern/
    - https://devfunny.tistory.com/337


# Factory 패턴


# Strategy 패턴

전략 패턴은 하나의 문제를 해결하기 위해 여러가지 알고리즘 방식들이 있을 대, 
하나의 공통 인터페이스와 이를 구현하는 여러 알고리즘 클래스들을 구현하고, 
이러한 알고리즘을 사용하는 클라이언트가 자신게게 맞는 알고리즘을 쉽게 선택해서 사용할 수 있게 한 디자인 패턴

> 클라이언트가 런타임 시, 전략 하나를 선택해 사용한다!
> 알고리즘의 공통 인터페이스를 하나 정의하고,
> 그 인터페이스를 구현하는 여러 알고리즘을 만들어 사용한다!

**다양한 알고리즘이나 행위가 가능한 상황에서 switch 나 if 분기 없이 행위를 구현할 수 있다!**

## 구현 
- 복수의 알고리즘 구현을 위한 IAlgorithm 인터페이스
- IAlgorithm 인터페이스를 구현한 알고리즘 클래스
- 어떤 알고리즘 선택할 지 Context 클래스
크게 3가지 분류로 정의하여 사용

- IAlogorithm, Algorithm
  - 알고리즘 실행하는 메서드를 정의 및 구현
- Context
  - IAlgorithm 타입의 필드, 속성을 정의하여 Context 클래스 메서드에서 사용
  - 혹은, IAlgorithm 필드, 속성을 정의하지 않고, 메서드의 입력 파라미터로 IAlgorithm 객체를 받아 사용

### 예시
구매 지불 시, 지불 수단에는 신용카드, 비트코인 2가지가 가능

- 지불수단 구현 인터페이스 `IPayment`
  - `Pay()` 지불 메서드 구현
- 지불 방법
  - `CardPayment`
  - `BitcoinPayment`
- `Checkout` 클래스 (Context 클래스에 해당)
  - `IPayment` 속성 가짐
  - 생성자 or 속성 재지정으로 **외부에서 지불 수단 지정**
  - `Charge()` 메서드 : 실제 지불
    - `IPayment` 객체 사용하여 지불 메서드 사용





