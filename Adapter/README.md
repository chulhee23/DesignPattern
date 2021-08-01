# Adapter
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


