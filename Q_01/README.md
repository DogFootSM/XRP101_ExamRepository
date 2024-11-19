# 1번 문제

주어진 프로젝트 내에서 CubeManager 객체는 다음의 책임을 가진다
- 해당 객체 생성 시 Cube프리팹의 인스턴스를 생성한다
- Cube 인스턴스의 컨트롤러를 참조해 위치를 변경한다.

제시된 소스코드에서는 큐브 인스턴스 생성 후 아래의 좌표로 이동시키는 것을 목표로 하였다
- x : 3
- y : 0
- z : 3

제시된 소스코드에서 문제가 발생하는 `원인을 모두 서술`하시오.

## 답안
- 1. CubeManager의 SetCubePosition 메서드에서 CubeController 의 SetPosition 메서드를 호출하는 오류
  2. 생성된 큐브가 이동할 위치 변수인 _cubeSetPoint 변수에 큐브의 Vector 프로퍼티 변수로 할당하고 있는 오류
  3. Controller의 Vector 프로퍼티 Set이 Private 으로 되어 있어 값 할당이 불가한 오류
