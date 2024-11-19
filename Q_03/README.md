# 3번 문제

주어진 프로젝트 는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 1. Turret
- Trigger 범위 내로 플레이어가 들어왔을 때 1.5초에 한번씩 플레이어를 바라보면서 총알을 발사한다
- Trigger 범위 바깥으로 플레이어가 나가면 발사를 중지한다.
- 오브젝트 풀을 사용해 총알을 관리한다.

### 2. Bullet :
- 20만큼의 힘으로 전방을 향해 발사된다
- 발사 후 5초 경과 시 비활성화 처리된다
- 플레이어를 가격했을 경우 2의 데미지를 준다

### 3. Player
- 총알과 충돌했을 때, 데미지를 입는다
- 체력이 0 이하가 될 경우 효과음을 재생하며 비활성화된다.
- 플레이어의 이동은 씬 뷰를 사용해 이동하도록 한다.

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
- 1. Player Body > rigidBody가 없어서 터렛이 인식하지 못하는 오류
    - Body 오브젝트에 Rigidbody 추가
  2. Player 가 범위 밖으로 벗어나도 계속 쏘는 오류
    - TurretController 컴포넌트 TriggerExit 추가
  3. Bullet Prefab > Bullet Controller 컴포넌트가 있는 오브젝트에 Rigidbody 가 없는 상태에서 Rigidbody 참조
   - Bullet Body 에 있는 Collider를 부모 오브젝트로 옮긴 후 부모 오브젝트에 Rigidbody 추가
  4. Player가 죽었을 때 audio가 재생되지 않음
    - 오브젝트 비활성화 시 audiosource도 비활성화 되어 SoundManager 추가 후 SoundManager에 클립 전달하여 재생
  5. Player가 죽어도 총알 계속 발사
    - Player.Hp가 1보다 클 동안 while문 수행하도록 수정
  6. Bullet이 Pool로 복귀 후 재활성화 시 Velocity 값이 초기화 되지 않는 오류
    - Bullet Pool로 복귀 시 Velocity 0으로 초기화
