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

#### 핵심
- 생성자가 많고, 
- 변경 불가능한 객체를 만들고 싶을 때!
    - setter를 사용했다면, 변경이 가능하다!



- 레퍼런스
    - https://johngrib.github.io/wiki/builder-pattern/
    - https://devfunny.tistory.com/337