# Animation trong Unity

## 1. Tổng quan

Hệ thống Animation trong Unity có thể hình dung như sau:

```text
Animation Clip
      ↓
Animator Controller
      ↓
Finite State Machine (State Machine)
      ↓
   ┌───────────────┐
   │ Idle          │
   │ Run           │
   │ Jump          │
   │ Attack        │
   └───────────────┘
      ↓
Animator Component
      ↓
GameObject / Player
```

**Blend Tree** nằm bên trong Animator Controller và được dùng để chuyển/trộn giữa nhiều Animation Clip dựa trên một hoặc nhiều giá trị.

---

# 2. Animation Clip

## 2.1. Animation Clip là gì?

**Animation Clip** là một đoạn Animation cụ thể.

Ví dụ:

```text
Idle.anim
Run.anim
Jump.anim
Attack.anim
Death.anim
```

Mỗi Clip chứa thông tin về sự thay đổi của các thuộc tính theo thời gian.

Ví dụ:

```text
Thời gian

0s       0.2s      0.4s      0.6s
 │         │         │         │
 ↓         ↓         ↓         ↓
Chân 1   Chân 2    Chân 1    Chân 2
```

Unity sẽ nội suy chuyển động giữa các frame để tạo thành Animation.

## 2.2. Animation Clip có thể thay đổi gì?

Animation Clip có thể lưu sự thay đổi của:

- Transform Position
- Transform Rotation
- Transform Scale
- Sprite
- Một số thuộc tính khác của Component

Đối với game 2D, Animation Clip thường thay đổi Sprite:

```text
Idle:
Sprite 1 → Sprite 2 → Sprite 3 → Sprite 2 → ...
```

## 2.3. Ví dụ

Một Player có các Sprite:

```text
player_idle_1
player_idle_2
player_idle_3

player_run_1
player_run_2
player_run_3
```

Có thể tạo:

```text
Idle.anim
Run.anim
```

### Ghi nhớ

> **Animation Clip = một đoạn Animation cụ thể.**

Ví dụ: "Player chạy" có thể là một Animation Clip.

---

# 3. Animator Component

## 3.1. Animator Component là gì?

**Animator** là Component được gắn vào GameObject để điều khiển Animation.

Ví dụ:

```text
Player
 ├── Transform
 ├── Sprite Renderer
 ├── Rigidbody2D
 ├── Player Script
 └── Animator
```

Animator sử dụng một **Animator Controller** để quyết định Animation nào cần được phát.

## 3.2. Animator Component có gì?

Khi chọn Player trong Inspector, có thể thấy:

```text
Animator

Controller: PlayerAnimator
Avatar:
Apply Root Motion
Update Mode
Culling Mode
```

Trong đó, thuộc tính quan trọng với người mới là:

```text
Controller
```

Ví dụ:

```text
Animator Component
       ↓
PlayerAnimator.controller
```

## 3.3. Ví dụ

Animator Controller có thể quy định:

```text
Player đang đứng
→ Idle

Player đang chạy
→ Run

Player nhảy
→ Jump

Player tấn công
→ Attack
```

Animator Component thực hiện việc chạy Animation tương ứng trên Player.

### Ghi nhớ

> **Animator Component = Component trên GameObject dùng để chạy và điều khiển Animator Controller.**

---

# 4. Animator Controller

## 4.1. Animator Controller là gì?

**Animator Controller** là nơi thiết kế logic điều khiển và chuyển đổi giữa các Animation.

Có thể mở Animator Window bằng:

```text
Window
→ Animation
→ Animator
```

Trong Animator Window, có thể thấy các State:

```text
Entry

   ↓

Idle
 │
 ├────→ Run
 │
 ├────→ Jump
 │
 └────→ Attack
```

## 4.2. State là gì?

Mỗi ô trong Animator Controller thường đại diện cho một **State**.

Ví dụ:

```text
Idle
Run
Jump
Attack
```

Một State có thể chứa một Animation Clip.

Ví dụ:

```text
Idle
 ↓
Idle.anim
```

```text
Run
 ↓
Run.anim
```

```text
Jump
 ↓
Jump.anim
```

---

# 5. Transition

Các mũi tên giữa các State được gọi là **Transition**.

Ví dụ:

```text
Idle ─────→ Run
```

Có nghĩa là:

> Khi điều kiện phù hợp, Animator chuyển từ Idle sang Run.

Ví dụ:

```text
Idle → Run

Condition:
speed > 0.1
```

Sau đó:

```text
Run → Idle

Condition:
speed < 0.1
```

---

# 6. Parameters

Để Animator biết khi nào cần chuyển Animation, chúng ta sử dụng **Parameters**.

Có 4 loại Parameter phổ biến:

```text
Float
Int
Bool
Trigger
```

Ví dụ:

```text
speed : Float
isGrounded : Bool
attack : Trigger
```

## 6.1. Float

Dùng cho các giá trị số thực.

Ví dụ:

```text
speed = 0
speed = 0.5
speed = 1
```

Có thể dùng để điều khiển tốc độ hoặc Blend Tree.

## 6.2. Int

Dùng cho số nguyên.

Ví dụ:

```text
weaponType = 0
weaponType = 1
weaponType = 2
```

## 6.3. Bool

Dùng cho trạng thái đúng/sai.

Ví dụ:

```text
isGrounded = true
```

hoặc:

```text
isGrounded = false
```

## 6.4. Trigger

Trigger thường được sử dụng cho hành động xảy ra trong một thời điểm cụ thể.

Ví dụ:

```text
Attack
Jump
Hit
```

---

# 7. Điều khiển Animator bằng C#

Ví dụ khai báo Animator:

```csharp
[SerializeField] Animator animator;
```

## 7.1. SetFloat

```csharp
animator.SetFloat("speed", movement.x);
```

Animator nhận giá trị của `speed` và sử dụng nó để điều khiển Animation.

## 7.2. SetBool

```csharp
animator.SetBool("isGrounded", true);
```

Hoặc:

```csharp
animator.SetBool("isGrounded", false);
```

## 7.3. SetTrigger

Khi Player tấn công:

```csharp
animator.SetTrigger("Attack");
```

Có thể tạo:

```text
Attack button
      ↓
SetTrigger("Attack")
      ↓
Idle → Attack
```

---

# 8. Finite State Machine (FSM)

## 8.1. FSM là gì?

**FSM = Finite State Machine**

Có thể hiểu là:

> **Máy trạng thái hữu hạn**

FSM mô tả một hệ thống gồm:

```text
State
Transition
Condition
```

Ví dụ Player có các trạng thái:

```text
Idle
Run
Jump
Attack
Death
```

Player tại một thời điểm sẽ ở trong một trạng thái cụ thể.

## 8.2. Ví dụ FSM

```text
          Jump
           ↑
           │
Idle ←─── Run
 │         │
 │         │
 └──→ Attack
```

Ví dụ:

```text
Idle → Run
Condition: speed > 0.1
```

```text
Run → Idle
Condition: speed < 0.1
```

```text
Idle → Jump
Condition: Jump = true
```

```text
Run → Attack
Condition: Attack = true
```

## 8.3. FSM trong Animator

Animator Controller sử dụng State Machine để quản lý các trạng thái Animation.

Có thể hình dung:

```text
Animator Controller
        ↓
State Machine
        ↓
┌─────────────────────────┐
│ Idle                    │
│ Run                     │
│ Jump                    │
│ Attack                  │
│ Death                   │
└─────────────────────────┘
        ↓
Animation Clips
```

### Ghi nhớ

> **FSM = cách tổ chức các trạng thái và điều kiện chuyển đổi giữa các trạng thái.**

---

# 9. Blend Tree

## 9.1. Blend Tree là gì?

**Blend Tree** dùng để kết hợp/chuyển đổi giữa nhiều Animation Clip dựa trên một hoặc nhiều giá trị.

Ví dụ:

```text
Idle
  │
  │ speed
  ↓
Walk
  │
  ↓
Run
```

Thay vì tạo nhiều Transition riêng biệt, có thể sử dụng Blend Tree.

## 9.2. Ví dụ Blend Tree

Giả sử:

```text
speed = 0
```

→ Idle

```text
speed = 0.5
```

→ Walk

```text
speed = 1
```

→ Run

Có thể hình dung:

```text
Idle ───── Walk ───── Run
 0         0.5        1
```

Blend Tree giúp quá trình chuyển đổi giữa các Animation trở nên mượt hơn.

---

# 10. Blend Tree 2D cho game 2D

Blend Tree đặc biệt hữu ích với game 2D có nhân vật di chuyển nhiều hướng.

Ví dụ:

```text
        Up
        ↑
        │
Left ← Player → Right
        │
        ↓
       Down
```

Có thể sử dụng **2D Blend Tree** với:

```text
Move X
Move Y
```

Ví dụ:

```text
        (0,1)
          Up

(-1,0)          (1,0)
 Left            Right

        (0,-1)
         Down
```

Trong C#:

```csharp
animator.SetFloat("MoveX", movement.x);
animator.SetFloat("MoveY", movement.y);
```

Blend Tree sẽ sử dụng hai giá trị này để lựa chọn hoặc trộn Animation phù hợp với hướng di chuyển.

---

# 11. Blend Tree và Transition khác nhau như thế nào?

## Transition

Transition dùng để chuyển từ State này sang State khác:

```text
Idle
 ↓
Run
```

Có thể hiểu:

> **Transition = chuyển State.**

## Blend Tree

Blend Tree dùng để trộn nhiều Animation trong một State dựa trên giá trị:

```text
Idle ─── Walk ─── Run
 0      0.5       1
```

Có thể hiểu:

> **Blend Tree = trộn/chuyển giữa nhiều Animation dựa trên giá trị.**

---

# 12. Any State

Trong Animator Controller thường có State:

```text
Any State
```

**Any State** cho phép chuyển đến một State khác từ nhiều State khác nhau khi điều kiện phù hợp.

Ví dụ Attack:

```text
Any State
     │
     │ Attack Trigger
     ↓
   Attack
```

Player có thể đang:

```text
Idle
Run
Jump
```

và khi Trigger `Attack` được kích hoạt, Animator có thể chuyển sang:

```text
Attack
```

---

# 13. Ví dụ hoàn chỉnh cho Player 2D

Giả sử Player có các Animation Clip:

```text
Idle.anim
Walk.anim
Run.anim
Jump.anim
Attack.anim
```

Tạo Animator Controller:

```text
PlayerAnimator.controller
```

Trong Controller có thể xây dựng:

```text
                 ┌─────────┐
                 │  Idle   │
                 └────┬────┘
                      │
                  speed > 0
                      ↓
                 ┌─────────┐
                 │   Run   │
                 └────┬────┘
                      │
                Jump Trigger
                      ↓
                 ┌─────────┐
                 │  Jump   │
                 └─────────┘
```

Attack có thể sử dụng:

```text
Any State
    │
    │ Attack Trigger
    ↓
 Attack
```

---

# 14. Ví dụ C# điều khiển Animation

Một đoạn code đơn giản:

```csharp
public class Player : MonoBehaviour
{
    [SerializeField] Animator animator;

    Vector2 movement;

    void Update()
    {
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
    }
}
```

Khi Attack:

```csharp
animator.SetTrigger("Attack");
```

Khi Jump:

```csharp
animator.SetTrigger("Jump");
```

Animator Controller sẽ nhận các Parameter và quyết định Animation cần chạy.

---

# 15. Mối quan hệ giữa 5 khái niệm

Có thể hiểu theo chuỗi:

```text
Animation Clip
      ↓
"Animation là gì?"
      ↓
Animator Controller
      ↓
"Animation nào được chạy?"
      ↓
Finite State Machine
      ↓
"Khi nào chuyển Animation?"
      ↓
Blend Tree
      ↓
"Trộn/chuyển Animation mượt như thế nào?"
      ↓
Animator Component
      ↓
"GameObject thực sự chạy hệ thống đó"
```

---

# 16. Bảng tổng hợp

| Khái niệm | Hiểu đơn giản | Ví dụ |
|---|---|---|
| **Animation Clip** | Một đoạn Animation | `Run.anim` |
| **Animator Component** | Component chạy Animation | Animator trên Player |
| **Animator Controller** | Bộ điều khiển Animation | `PlayerAnimator.controller` |
| **FSM** | Logic các trạng thái và chuyển trạng thái | Idle → Run → Jump |
| **Blend Tree** | Trộn nhiều Animation theo giá trị | Idle → Walk → Run |

---

# 17. Cách ghi nhớ nhanh

```text
Animation Clip
→ Idle, Run, Jump, Attack

Animator Controller
→ Quản lý các Animation

FSM
→ Idle → Run → Jump → Attack

Blend Tree
→ Chuyển/trộn Animation mượt

Animator Component
→ Gắn lên Player để chạy Controller
```

---

# 18. Thứ tự nên học

Nếu đang học Unity và làm game 2D, nên học theo thứ tự:

```text
1. Animation Clip
        ↓
2. Animator Component
        ↓
3. Animator Controller
        ↓
4. Parameter
        ↓
5. Transition
        ↓
6. Finite State Machine
        ↓
7. Blend Tree
        ↓
8. Điều khiển Animator bằng C#
```

Sau khi nắm được các phần này, có thể áp dụng vào Player:

```text
Idle
  ↓
Walk / Run
  ↓
Jump
  ↓
Attack
  ↓
Hit
  ↓
Death
```

Đây là nền tảng để xây dựng hệ thống Animation hoàn chỉnh cho nhân vật trong Unity.
