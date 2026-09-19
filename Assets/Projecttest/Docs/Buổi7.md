# Bài mới -- FSM và Animation trong Unity

## 1. FSM -- Finite State Machine

### 1.1. FSM là gì?

**Finite State Machine (FSM -- máy trạng thái hữu hạn)** là mô hình dùng
để quản lý một đối tượng khi nó có một tập hữu hạn các trạng thái và các
quy tắc chuyển từ trạng thái này sang trạng thái khác.

Ví dụ một nhân vật:

``` text
             ┌───────────┐
             │   Idle    │
             └─────┬─────┘
                   │ Có input di chuyển
                   ↓
             ┌───────────┐
             │    Run    │
             └─────┬─────┘
                   │ Nhấn Jump
                   ↓
             ┌───────────┐
             │   Jump    │
             └─────┬─────┘
                   │ Chạm đất
                   ↓
                 Idle
```

Unity sử dụng State Machine để quản lý các state và transition trong hệ
thống animation.

## 2. Các thành phần của FSM

Một FSM cơ bản có thể hiểu qua 4 thành phần:

### 2.1. State -- Trạng thái

Là trạng thái mà đối tượng đang ở.

Ví dụ:

``` text
Idle
Run
Jump
Attack
Dead
```

### 2.2. Current State -- Trạng thái hiện tại

Tại một thời điểm, nhân vật đang ở một state nào đó.

``` csharp
CurrentState = Run;
```

### 2.3. Transition -- Chuyển trạng thái

Quy định khi nào được chuyển từ State A sang State B.

Ví dụ:

``` text
Idle → Run
```

khi người chơi nhấn phím di chuyển.

### 2.4. Condition -- Điều kiện

Điều kiện quyết định transition có xảy ra hay không.

Ví dụ:

``` text
speed > 0  → Run
speed == 0 → Idle
Jump = true → Jump
```

# 3. Cách 1: FSM bằng `enum` + `switch-case`

Đây là cách đơn giản, phù hợp khi mới học FSM.

Trong C#, `enum` là kiểu dữ liệu biểu diễn một tập các hằng số được đặt
tên.

``` csharp
enum FSM
{
    Idle,
    Run,
    Jump,
    Attack
}
```

Tạo biến lưu trạng thái hiện tại:

``` csharp
FSM currentState = FSM.Idle;
```

Sau đó dùng `switch-case` để xử lý:

``` csharp
switch (currentState)
{
    case FSM.Idle:
        Debug.Log("Đang đứng yên");
        break;

    case FSM.Run:
        Debug.Log("Đang chạy");
        break;

    case FSM.Jump:
        Debug.Log("Đang nhảy");
        break;

    case FSM.Attack:
        Debug.Log("Đang tấn công");
        break;
}
```

### Ví dụ FSM nhân vật Unity

``` csharp
using UnityEngine;

public class Player : MonoBehaviour
{
    enum FSM
    {
        Idle,
        Run,
        Jump,
        Attack
    }

    FSM currentState = FSM.Idle;

    void Update()
    {
        switch (currentState)
        {
            case FSM.Idle:
                Idle();
                break;

            case FSM.Run:
                Run();
                break;

            case FSM.Jump:
                Jump();
                break;

            case FSM.Attack:
                Attack();
                break;
        }
    }

    void Idle()
    {
        Debug.Log("Idle");
    }

    void Run()
    {
        Debug.Log("Run");
    }

    void Jump()
    {
        Debug.Log("Jump");
    }

    void Attack()
    {
        Debug.Log("Attack");
    }
}
```

### Chuyển State

Ví dụ:

``` csharp
if (Input.GetKey(KeyCode.D))
{
    currentState = FSM.Run;
}
else
{
    currentState = FSM.Idle;
}
```

Sơ đồ:

``` text
                 Nhấn D
Idle ─────────────────────→ Run
 ↑                           │
 │                           │ Thả D
 └───────────────────────────┘
```

### Ưu điểm

-   Dễ học.
-   Dễ viết.
-   Dễ debug.
-   Phù hợp FSM nhỏ.
-   Phù hợp với bài tập Unity cơ bản.

### Hạn chế

Khi có quá nhiều State, `switch-case` có thể trở nên dài và khó quản lý:

``` text
Idle
Run
Jump
Attack
Hit
Dead
Patrol
Chase
Flee
Stun
...
```


# 4. Cách 2: FSM -- Interface / Abstract Class

Đây là cách tiếp cận hướng đối tượng hơn.

Thay vì:

``` text
enum → switch → xử lý tất cả State
```

ta tách từng State thành một class riêng:

``` text
             Player FSM
                 │
       ┌─────────┼─────────┐
       ↓         ↓         ↓
     Idle       Run       Jump
     class      class      class
```

Cách này liên quan đến **State Pattern**.


# 5. FSM với `interface`

Trong C#, interface có thể hiểu là một contract (hợp đồng) mà class
triển khai phải tuân theo.

Ví dụ:

``` csharp
interface IState
{
    void Enter();
    void Update();
    void Exit();
}
```

Điều này có nghĩa các State cần cung cấp:

``` text
Enter()
Update()
Exit()
```

Ví dụ:

``` csharp
class IdleState : IState
{
    public void Enter()
    {
        Debug.Log("Enter Idle");
    }

    public void Update()
    {
        Debug.Log("Idle...");
    }

    public void Exit()
    {
        Debug.Log("Exit Idle");
    }
}
```


# 6. Ý nghĩa của `Enter()`, `Update()`, `Exit()`

### `Enter()`

Được gọi khi bắt đầu vào State.

Ví dụ:

``` text
Run → Attack
```

khi vào Attack:

``` csharp
Enter()
{
    animator.Play("Attack");
}
```

### `Update()`

Được gọi trong khi đang ở State.

Có thể dùng để:

-   Kiểm tra input.
-   Kiểm tra điều kiện.
-   Xử lý hành vi.
-   Kiểm tra thời gian hoặc animation.

### `Exit()`

Được gọi khi rời khỏi State.

Ví dụ:

``` text
Attack → Idle
```

``` csharp
Exit()
{
    Debug.Log("End Attack");
}
```


# 7. FSM với `abstract class`

Ngoài `interface`, có thể sử dụng `abstract class`:

``` csharp
abstract class State
{
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
```

State con:

``` csharp
class IdleState : State
{
    public override void Enter()
    {
        Debug.Log("Enter Idle");
    }

    public override void Update()
    {
        Debug.Log("Idle");
    }

    public override void Exit()
    {
        Debug.Log("Exit Idle");
    }
}
```

Abstract class không thể được tạo instance trực tiếp và có thể yêu cầu
class con triển khai các thành phần `abstract`.


# 8. So sánh `interface` và `abstract class`

  -----------------------------------------------------------------------
  `interface`                         `abstract class`
  ----------------------------------- -----------------------------------
  Là một contract                     Là lớp cơ sở

  Không dùng để tạo object trực tiếp  Không thể tạo instance trực tiếp

  Một class có thể implement nhiều    Class chỉ kế thừa một base class
  interface                           

  Phù hợp mô tả hành vi               Phù hợp chia sẻ logic/state chung

  Ví dụ: `IState`                     Ví dụ: `State`
  -----------------------------------------------------------------------


# 9. So sánh hai cách triển khai FSM

  Tiêu chí        `enum + switch`   `interface / abstract`
  --------------- ----------------- ------------------------
  Độ khó          Dễ                Khó hơn
  Cách tổ chức    Tập trung         Phân tách
  State           `enum`            Class riêng
  Xử lý           `switch-case`     Method của State
  Code ít         Có                Thường nhiều hơn
  FSM nhỏ         Phù hợp           Có thể hơi dư
  FSM lớn         Khó quản lý hơn   Dễ mở rộng
  OOP             Ít                Nhiều
  State Pattern   Không             Có

------------------------------------------------------------------------

# 10. Animation trong Unity

## 10.1. Animation là gì?

Animation trong Unity được dùng để tạo ra sự thay đổi theo thời gian,
chẳng hạn:

-   Vị trí.
-   Rotation.
-   Scale.
-   Sprite.
-   Các thuộc tính của GameObject.

**Animation Clip** là một đơn vị cơ bản của hệ thống animation.

Ví dụ:

``` text
Player_Idle.anim
Player_Run.anim
Player_Attack.anim
Player_Jump.anim
```

# 11. Ba Animation cơ bản cho nhân vật

Một nhân vật cơ bản thường có thể bắt đầu với:

``` text
1. Idle
2. Run / Walk
3. Attack
```

Hoặc:

``` text
1. Idle
2. Run / Walk
3. Jump
```

Trong game hoàn chỉnh có thể có nhiều animation hơn:

``` text
Idle
Walk
Run
Jump
Fall
Attack
Hit
Death
Dash
Skill
...
```


# 12. Animation Clip

Animation Clip có thể coi là một chuyển động riêng:

``` text
Player_Idle.anim
       ↓
   Idle Clip

Player_Run.anim
       ↓
   Run Clip

Player_Attack.anim
       ↓
 Attack Clip
```

Các clip này có thể được tổ chức và chuyển đổi thông qua Animator
Controller.


# 13. Animator Controller

**Animator Controller** là nơi tổ chức Animation Clip, Animation State
và Transition.

Có thể hình dung:

``` text
             Animator Controller
                     │
       ┌─────────────┼─────────────┐
       ↓             ↓             ↓
     Idle           Run          Attack
     Clip           Clip           Clip
```

Unity mô tả Animator Controller là thành phần quản lý các Animation Clip
và Animation Transition bằng State Machine.


# 14. Animator Component

Trong Player thường có:

``` text
Player
 ├── Transform
 ├── Rigidbody2D
 ├── Collider2D
 └── Animator
```

Animator Component dùng để kết nối GameObject với Animator Controller và
điều khiển animation.

Có thể hiểu:

``` text
Animation Clip
       ↓
Animator Controller
       ↓
Animator Component
       ↓
Player
```


# 15. Animation State

Trong Animator Controller, mỗi node như:

``` text
Idle
Run
Attack
Jump
```

là một **Animation State**.

Một Animation State chứa một animation sequence hoặc Blend Tree.

Ví dụ:

``` text
┌───────────────┐
│      Idle     │
│ Motion:       │
│ Idle.anim     │
└───────────────┘
```


# 16. Animation Transition

Transition là đường nối giữa các Animation State.

Ví dụ:

``` text
Idle ─────────→ Run
```

Điều kiện:

``` text
Speed > 0
```

Và:

``` text
Run ─────────→ Idle
```

Điều kiện:

``` text
Speed == 0
```

Transition xác định khi nào và trong bao lâu hệ thống chuyển/blend từ
Animation State này sang State khác.


# 17. Animator Parameters

Animator có 4 loại Parameter cơ bản:

``` text
Float
Int
Bool
Trigger
```


## 17.1. Float

Ví dụ:

``` text
Speed
```

C#:

``` csharp
animator.SetFloat("Speed", movement.magnitude);
```

Có thể sử dụng:

``` text
Speed = 0
    ↓
  Idle

Speed > 0
    ↓
  Run
```


## 17.2. Bool

Ví dụ:

``` text
IsGrounded
```

C#:

``` csharp
animator.SetBool("IsGrounded", isGrounded);
```

Có thể dùng:

``` text
IsGrounded = true
        ↓
      Idle
```

và:

``` text
IsGrounded = false
        ↓
      Jump
```


## 17.3. Trigger

Trigger thường phù hợp với những hành động xảy ra theo sự kiện, ví dụ
Attack.

``` csharp
animator.SetTrigger("Attack");
```

Animator:

``` text
Idle
  │
  │ Attack Trigger
  ↓
Attack
```

## 17.4. Int

Có thể sử dụng Int khi cần nhiều lựa chọn dạng số.

Ví dụ:

``` text
WeaponType

0 → Sword
1 → Gun
2 → Bow
```


# 18. Khi nào dùng Float, Int, Bool, Trigger?

  Parameter   Ví dụ          Công dụng
  ----------- -------------- ------------------------
  Float       `Speed`        Giá trị liên tục
  Int         `WeaponType`   Nhiều lựa chọn dạng số
  Bool        `IsGrounded`   Trạng thái có/không
  Trigger     `Attack`       Sự kiện xảy ra

Ví dụ:

``` text
Speed       → Idle / Run
IsGrounded  → Ground / Air
Attack      → Attack animation
```


# 19. Blend Tree

**Blend Tree** dùng để pha trộn nhiều animation dựa trên một hoặc nhiều
giá trị.

Ví dụ:

``` text
Speed = 0
    ↓
 Idle

Speed = 0.5
    ↓
 Walk

Speed = 1
    ↓
 Run
```

Có thể hình dung:

``` text
             Speed
               │
               ↓
          Blend Tree
          /    |    \
       Idle   Walk   Run
```

Khác với Transition:

``` text
Transition
→ chuyển từ State này sang State khác
```

Trong khi:

``` text
Blend Tree
→ pha trộn nhiều animation dựa trên parameter
```


# 20. FSM và Animation liên quan với nhau như thế nào?

Có thể hình dung:

``` text
              GAMEPLAY FSM
                   │
                   ↓
             Player State
                   │
        ┌──────────┼──────────┐
        ↓          ↓          ↓
       Idle       Run        Attack
        │          │          │
        ↓          ↓          ↓
    Idle.anim   Run.anim   Attack.anim
        │          │          │
        └──────────┼──────────┘
                   ↓
                Animator
```

Ví dụ:

``` text
Player đang chạy
       ↓
FSM = Run
       ↓
Animator.SetFloat("Speed", 1)
       ↓
Animator Controller
       ↓
Run Animation
```


# 21. Gameplay FSM và Animator FSM không hoàn toàn giống nhau

Đây là điểm rất dễ nhầm.

Có thể có **Gameplay FSM**:

``` text
Idle
Run
Attack
Dead
```

và **Animation State Machine**:

``` text
Idle Animation
Run Animation
Attack Animation
Death Animation
```

Hai hệ thống có thể phối hợp với nhau nhưng không nhất thiết phải là một
hệ thống duy nhất.

Ví dụ:

``` text
Gameplay
   ↓
Player đang Attack
   ↓
animator.SetTrigger("Attack")
   ↓
Animator
   ↓
Attack Animation
```


# 22. Ví dụ kết hợp C# với Animation

Giả sử Animator có:

``` text
Speed       Float
IsGrounded  Bool
Attack      Trigger
```

C#:

``` csharp
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float speed = Mathf.Abs(Input.GetAxisRaw("Horizontal"));

        animator.SetFloat("Speed", speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
    }
}
```

Luồng hoạt động:

``` text
Input
  │
  ↓
C# Player
  │
  ├── Speed ──────→ Animator
  │
  └── Attack ─────→ Animator
                       │
                       ↓
                 State Machine
                       │
              ┌────────┼────────┐
              ↓        ↓        ↓
            Idle      Run     Attack
```


# 23. Tóm tắt FSM

**FSM = Finite State Machine**

Là mô hình quản lý đối tượng dựa trên một tập hữu hạn các trạng thái và
các quy tắc chuyển trạng thái.

### Thành phần

``` text
State
Current State
Transition
Condition
```

### Cách 1

``` text
enum + switch-case
```

-   `enum`: định nghĩa các trạng thái.
-   `switch-case`: xử lý hành vi của từng trạng thái.
-   Phù hợp FSM nhỏ, dễ triển khai.

### Cách 2

``` text
Interface / Abstract Class
```

-   Mỗi State là một class riêng.
-   Thường có:

``` text
Enter()
Update()
Exit()
```

-   Phù hợp hệ thống lớn và dễ mở rộng.
-   Liên quan đến State Pattern.


# 24. Tóm tắt Animation

### Các thành phần chính

``` text
Animation Clip
       ↓
Animation State
       ↓
Transition
       ↓
Animator Controller
       ↓
Animator Component
       ↓
GameObject
```

### Animation Clip

Một đoạn animation riêng:

``` text
Idle
Run
Jump
Attack
```

### Animator Controller

Quản lý:

``` text
Animation States
Transitions
Parameters
Blend Trees
```

### Animator Parameters

``` text
Float
Int
Bool
Trigger
```

### Transition

Quy định:

``` text
State A → State B
```

dựa trên điều kiện.

### Blend Tree

Dùng để blend nhiều animation dựa trên parameter:

``` text
Speed = 0     → Idle
Speed = 0.5   → Walk
Speed = 1     → Run
```
