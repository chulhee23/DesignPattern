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
