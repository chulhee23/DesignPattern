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

