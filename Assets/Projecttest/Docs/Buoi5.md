# Sự kiện (Event) trong C# & Unity

## 1. Tổng quan về Event

**Event (sự kiện)** là cơ chế cho phép một đối tượng thông báo cho các đối tượng khác biết rằng một hành động hoặc sự kiện nào đó đã xảy ra.

Ví dụ trong Unity:

- Player nhặt được vật phẩm → thông báo cho UI cập nhật số lượng.
- Player chết → thông báo cho GameManager xử lý Game Over.
- Nhấn nút → thông báo cho một hàm được đăng ký thực hiện.

Có thể hình dung:

```text
Event xảy ra
     ↓
Phát (Invoke)
     ↓
Các hàm đã đăng ký
     ↓
Được gọi
```

---

# 2. Delegate trong C#

## 2.1. Delegate là gì?

**Delegate** là một kiểu dữ liệu dùng để lưu tham chiếu đến một hoặc nhiều phương thức.

Nói đơn giản:

> Delegate giống như một biến có thể chứa một hàm.

### Ví dụ

```csharp
public delegate void MyDelegate();

void Hello()
{
    Debug.Log("Hello");
}
```

Có thể gán hàm `Hello()` vào delegate:

```csharp
MyDelegate myDelegate = Hello;
```

Sau đó gọi:

```csharp
myDelegate();
```

Kết quả:

```text
Hello
```

---

## 2.2. Đăng ký với Delegate

Delegate có thể dùng `+=` để đăng ký thêm hàm:

```csharp
myDelegate += Hello;
myDelegate += Goodbye;
```

Khi gọi:

```csharp
myDelegate();
```

Các hàm đã đăng ký sẽ lần lượt được gọi.

Có thể dùng `-=` để hủy đăng ký:

```csharp
myDelegate -= Hello;
```

---

# 3. Action trong C#

## 3.1. Action là gì?

`Action` là một delegate có sẵn trong C#.

Vì vậy, thay vì tự định nghĩa:

```csharp
public delegate void MyDelegate();
```

có thể sử dụng:

```csharp
Action myAction;
```

`Action` dùng cho các phương thức **không trả về giá trị** (`void`).

---

## 3.2. Ví dụ

```csharp
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    Action onPlayerDie;

    void Start()
    {
        onPlayerDie += PlayerDie;
    }

    void PlayerDie()
    {
        Debug.Log("Player đã chết!");
    }

    void Die()
    {
        onPlayerDie?.Invoke();
    }
}
```

Khi `Die()` được gọi:

```csharp
onPlayerDie?.Invoke();
```

thì `PlayerDie()` sẽ được thực hiện.

---

## 3.3. Đăng ký Action

Đăng ký:

```csharp
onPlayerDie += PlayerDie;
```

Hủy đăng ký:

```csharp
onPlayerDie -= PlayerDie;
```

Gọi (phát) Action:

```csharp
onPlayerDie?.Invoke();
```

Dấu `?.` giúp kiểm tra Action có đang chứa hàm hay không trước khi gọi.

---

# 4. UnityEvent trong Unity

## 4.1. UnityEvent là gì?

`UnityEvent` là hệ thống Event do Unity cung cấp.

Nó có ưu điểm lớn là có thể **đăng ký hàm trực tiếp trong Inspector**.

UnityEvent thường được sử dụng cho:

- Button
- UI
- Trigger
- Animation
- Các sự kiện gameplay
- Những sự kiện muốn thiết lập trực tiếp trong Inspector

Cần import:

```csharp
using UnityEngine.Events;
```

---

# 5. Tạo UnityEvent

Ví dụ:

```csharp
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent OnPlayerDie;

    public void Die()
    {
        OnPlayerDie.Invoke();
    }
}
```

Ở đây:

```csharp
public UnityEvent OnPlayerDie;
```

tạo ra một Event tên là `OnPlayerDie`.

Khi muốn phát Event:

```csharp
OnPlayerDie.Invoke();
```

---

# 6. Đăng ký UnityEvent trong Inspector

Nếu khai báo:

```csharp
public UnityEvent OnPlayerDie;
```

Unity sẽ hiển thị Event trong Inspector.

Có thể kéo một GameObject vào Event và chọn một hàm muốn thực hiện.

Ví dụ:

```text
Player
 └── On Player Die
       └── GameManager
             └── GameOver()
```

Khi code:

```csharp
OnPlayerDie.Invoke();
```

Unity sẽ gọi:

```csharp
GameOver();
```

---

# 7. Đăng ký UnityEvent bằng Code

Ngoài Inspector, UnityEvent cũng có thể đăng ký bằng code.

```csharp
void Start()
{
    OnPlayerDie.AddListener(PlayerDie);
}
```

Hủy đăng ký:

```csharp
OnPlayerDie.RemoveListener(PlayerDie);
```

Phát Event:

```csharp
OnPlayerDie.Invoke();
```

### Tóm tắt

| Công việc | UnityEvent |
|---|---|
| Đăng ký bằng code | `AddListener()` |
| Hủy đăng ký | `RemoveListener()` |
| Phát Event | `Invoke()` |

---

# 8. So sánh Delegate, Action và UnityEvent

| Đặc điểm | Delegate | Action | UnityEvent |
|---|---|---|---|
| Có sẵn trong C# | ❌ | ✅ | ❌ |
| Có trong Unity | Có thể dùng | Có thể dùng | ✅ |
| Dùng cho callback/event | ✅ | ✅ | ✅ |
| Đăng ký bằng `+=` | ✅ | ✅ | ❌ |
| Đăng ký bằng `AddListener()` | ❌ | ❌ | ✅ |
| Hủy bằng `-=` | ✅ | ✅ | ❌ |
| Hủy bằng `RemoveListener()` | ❌ | ❌ | ✅ |
| Gọi bằng `Invoke()` | Có thể | Có thể | Có |
| Đăng ký trong Inspector | ❌ | ❌ | ✅ |

---

# 9. Cách gọi (phát) Event thông qua Invoke()

`Invoke()` có nghĩa là **gọi / phát Event**.

Ví dụ với `Action`:

```csharp
Action onDie;

onDie += PlayerDie;

onDie.Invoke();
```

Ví dụ với `UnityEvent`:

```csharp
UnityEvent onDie = new UnityEvent();

onDie.AddListener(PlayerDie);

onDie.Invoke();
```

Luồng hoạt động:

```text
1. Tạo Event
       ↓
2. Đăng ký hàm
       ↓
3. Event xảy ra
       ↓
4. Invoke()
       ↓
5. Các hàm đã đăng ký được gọi
```

> Lưu ý: Với `Action`, thường nên dùng `?.Invoke()` để tránh lỗi khi chưa có hàm nào đăng ký.

---

# Coroutine trong Unity

## 10. Coroutine là gì?

**Coroutine** là cơ chế trong Unity cho phép một phương thức có thể **tạm dừng tại một thời điểm rồi tiếp tục chạy sau đó**.

Coroutine thường được dùng cho:

- Chờ một khoảng thời gian.
- Hiệu ứng.
- Animation đơn giản.
- Cooldown.
- Spawn vật thể theo thời gian.
- Thay đổi trạng thái sau vài giây.

Ví dụ:

```csharp
IEnumerator Example()
{
    Debug.Log("Bắt đầu");

    yield return new WaitForSeconds(2f);

    Debug.Log("Sau 2 giây");
}
```

---

# 11. Coroutine có phải là một Thread không?

**Không.**

Coroutine không tạo ra một thread mới như cách hiểu thông thường về đa luồng.

Coroutine chạy trên luồng chính của Unity và cho phép Unity **tạm dừng rồi tiếp tục một đoạn code** thông qua `yield`.

Có thể hình dung:

```text
Coroutine bắt đầu
      ↓
Chạy một đoạn code
      ↓
yield return
      ↓
Tạm dừng Coroutine
      ↓
Unity tiếp tục xử lý các công việc khác
      ↓
Đến thời điểm phù hợp
      ↓
Coroutine tiếp tục
```

---

# 12. `yield return null`

`yield return null` làm Coroutine tạm dừng và tiếp tục ở **frame tiếp theo**.

Ví dụ:

```csharp
IEnumerator Example()
{
    Debug.Log("Frame 1");

    yield return null;

    Debug.Log("Frame tiếp theo");
}
```

Có thể hiểu đơn giản:

```text
Chạy code
   ↓
yield return null
   ↓
Đợi frame tiếp theo
   ↓
Chạy tiếp
```

---

# 13. `yield return new WaitForSeconds()`

Dùng để tạm dừng Coroutine trong một khoảng thời gian.

Ví dụ:

```csharp
IEnumerator Example()
{
    Debug.Log("Bắt đầu");

    yield return new WaitForSeconds(2f);

    Debug.Log("Sau 2 giây");
}
```

Ở đây:

```csharp
new WaitForSeconds(2f)
```

có nghĩa là chờ khoảng **2 giây** trước khi Coroutine tiếp tục.

---

# 14. Bắt đầu Coroutine với StartCoroutine()

Để chạy Coroutine, sử dụng:

```csharp
StartCoroutine(Example());
```

Ví dụ hoàn chỉnh:

```csharp
using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        Debug.Log("Bắt đầu");

        yield return new WaitForSeconds(2f);

        Debug.Log("Sau 2 giây");
    }
}
```

Luồng:

```text
Start()
  ↓
StartCoroutine()
  ↓
Example()
  ↓
Debug.Log("Bắt đầu")
  ↓
WaitForSeconds(2s)
  ↓
Debug.Log("Sau 2 giây")
```

---

# 15. Dừng Coroutine với StopCoroutine()

Có thể dừng Coroutine bằng `StopCoroutine()`.

Một cách dễ quản lý là lưu Coroutine vào biến:

```csharp
Coroutine myCoroutine;
```

Bắt đầu:

```csharp
myCoroutine = StartCoroutine(Example());
```

Dừng:

```csharp
StopCoroutine(myCoroutine);
```

Ví dụ:

```csharp
using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    Coroutine myCoroutine;

    void Start()
    {
        myCoroutine = StartCoroutine(Example());
    }

    void StopMyCoroutine()
    {
        StopCoroutine(myCoroutine);
    }

    IEnumerator Example()
    {
        Debug.Log("Bắt đầu");

        yield return new WaitForSeconds(5f);

        Debug.Log("Sau 5 giây");
    }
}
```

Nếu `StopMyCoroutine()` được gọi trước khi đủ 5 giây, Coroutine sẽ bị dừng và đoạn code sau `yield` sẽ không được thực hiện.

---

# 16. Ví dụ thực tế trong Unity

## Player đi vào vùng → hiện UI trong vài giây

Ví dụ một UI được bật lên khi Player đi vào Trigger và tự tắt sau 3 giây:

```csharp
using System.Collections;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    [SerializeField] GameObject ui;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Show());
        }
    }

    IEnumerator Show()
    {
        ui.SetActive(true);

        yield return new WaitForSeconds(3f);

        ui.SetActive(false);
    }
}
```

Luồng:

```text
Player đi vào Trigger
        ↓
OnTriggerEnter2D()
        ↓
StartCoroutine(Show())
        ↓
UI.SetActive(true)
        ↓
WaitForSeconds(3s)
        ↓
UI.SetActive(false)
```

---

# 17. Tổng hợp nhanh

## Event

### Delegate

```csharp
public delegate void MyDelegate();

MyDelegate myEvent;

myEvent += MyFunction;
myEvent -= MyFunction;

myEvent?.Invoke();
```

### Action

```csharp
Action myEvent;

myEvent += MyFunction;
myEvent -= MyFunction;

myEvent?.Invoke();
```

### UnityEvent

```csharp
UnityEvent myEvent;

myEvent.AddListener(MyFunction);
myEvent.RemoveListener(MyFunction);

myEvent.Invoke();
```

### UnityEvent trong Inspector

```text
UnityEvent
    ↓
Inspector
    ↓
Add Listener
    ↓
Chọn GameObject
    ↓
Chọn Function
```

---

## Coroutine

### Tạo Coroutine

```csharp
IEnumerator Example()
{
    yield return null;

    yield return new WaitForSeconds(2f);
}
```

### Bắt đầu

```csharp
StartCoroutine(Example());
```

### Dừng

```csharp
StopCoroutine(myCoroutine);
```

---

# 18. Ghi nhớ

```text
EVENT
│
├── Delegate
│     ├── += đăng ký
│     ├── -= hủy
│     └── Invoke() gọi
│
├── Action
│     ├── Delegate có sẵn của C#
│     ├── += đăng ký
│     ├── -= hủy
│     └── Invoke() gọi
│
└── UnityEvent
      ├── AddListener() đăng ký
      ├── RemoveListener() hủy
      ├── Invoke() gọi
      └── Có thể đăng ký trong Inspector


COROUTINE
│
├── IEnumerator
├── yield return null
│     └── chờ đến frame tiếp theo
│
├── yield return new WaitForSeconds(2f)
│     └── chờ khoảng 2 giây
│
├── StartCoroutine()
│     └── bắt đầu
│
└── StopCoroutine()
      └── dừng
```
