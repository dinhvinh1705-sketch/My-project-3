# Bài cũ
## 1. New input system
- New Input System là hệ thống xử lý input mới của Unity, dùng để nhận thao tác từ bàn phím, chuột, gamepad, joystick, touch screen... và liên kết chúng với hành động trong game như:
 + Di chuyển nhân vật
 + Nhảy
 + Tấn công
 + Tương tác
 + Mở Inventory
 + Pause game
 + Điều khiển UI
- Input Actions
 + New Input System thường sử dụng Input Actions.
 + Ví dụ tạo một Input Actions Asset: MoveTopDown.
- Action
 + Action đại diện cho hành động mà người chơi muốn thực hiện.
 + Ví dụ: Movve, Jump, Attack,...
- Binding
 + Binding là cách gán thiết bị input vào Action.
 +  Ví dụ: có Action Jump được gán với Keyboard Space.
- Control Type
 + Mỗi Action có thể có kiểu dữ liệu khác nhau.
 + Button dùng cho Jump, Attack, Interact.
 + Value dùng cho hành động liên tục như Move, Look.
- Tạo Input Actions
 + Vào Setting, chọn Input System_Actions -> Tạo Action -> Sau đó tạo các Action và gán vào các nút.
- Tạo Move bằng WASD
 + Với Move sẽ chọn Action Type: Value, Control Type: Vector2
 + Thêm 2D Vector Composite
 + Gán Up -> w, Down -> s, Left  -> a, Right -> d.
- Đọc Input trong C#
``` 
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    InputAction MoveAction;

    void Awake()
    {
        MoveAction = InputSystem.actions.FindAction("MoveTopDown");
    }
    void Update() 
    {
        Vector2 movement = MoveAction.ReadValue<Vector2>();
        Debug.Log(movement);
    }
}
``` 
- Kiểm tra nút
 + Sẽ có 3 trường họp: WasPressedThisFrame() (đã bấm), IsPress() (đang giữ), WasReleasedThisFrame() (đã thả).
 
   
## 2. Physic 2D
- Thành phần quan trọng của Physics 2D
 + Khi học Physics 2D, bạn nên nắm 4 thành phần chính: Rigidbody2D, Collider2D, Physics Material 2D, Collision/Trigger
- **Rigidbody 2D**
 + Rigidbody2D giúp GameObject tham gia vào hệ thống vật lý
 + Nếu có Rigidbody2D, Unity có thể xử lý: Gravity -> Player rơi -> Collider -> Va chạm Ground
- Các thuộc tính quan trọng
 + Body Type có 3 loại: Dynamic, Kinematic, Static.
 + Dynamic: Đối tượng chịu tác động của vật lý. 
 + Kinematic: Đối tượng chủ yếu được điều khiển bằng code hoặc chuyển động kinematic, thay vì được đẩy đi bởi lực vật lý thông thường.
 + Static: Dành cho vật thể gần như không di chuyển. 
- **Collider 2D**
 + Collider2D xác định vùng va chạm của GameObject.
 + Collider không nhất thiết phải nhìn thấy trong game. Nó giống như một "vùng vật lý" bao quanh object.
 + Một số Collider 2D phổ biến: Box Collider 2D, Circle Collider 2D, Capsule Collider 2D, Polygon Collider 2D, Edge Collider, Tilemap Collider 2D

- **Rigidbody2D + Collider2D**
 + Thông thường: Rigidboy2D + Collider2D mới tạo ra một đối tượng có thể tham gia va chạm vật lý đầy đủ.
- Gravity
 + Rigidbody2D có thuộc tính: Gravity Scale
 + Ví dụ: Gravity Scale = 1 → chịu trọng lực bình thường theo thiết lập Physics 2D của project.
 + Nếu Gravity Scale = 0 → Rigidbody2D không bị trọng lực tác động.
- Physics Material 2D
 + Physics Material 2D dùng để điều chỉnh:Friction, Bounciness.
- **Collision**
 + Collision xảy ra khi hai Collider tương tác vật lý.
 + Ví dụ: Player → Wall. 
 + Unity có thể gọi: 
```
void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log("Va chạm!");
}
```
 + OnCollisionEnter2D Được gọi khi bắt đầu va chạm.
``` 
void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log("Bắt đầu va chạm");
}
``` 
 + OnCollisionStay2D Được gọi trong khi vẫn đang va chạm.
``` 
void OnCollisionStay2D(Collision2D collision)
{
    Debug.Log("Đang va chạm");
}
``` 
 + OnCollisionExit2D Được gọi khi kết thúc va chạm.
``` 
void OnCollisionExit2D(Collision2D collision)
{
    Debug.Log("Không còn va chạm");
}
``` 
## 3.Di chuyển
linearVolocity
``` 
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    InputAction MoveAction;
    InputAction JumpAction;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jump;
    Vector2 movement;
    void Awake()
    {
        MoveAction = InputSystem.actions.FindAction("MoveTopDown");
        JumpAction = InputSystem.actions.FindAction("Jump");

        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movement = MoveAction.ReadValue<Vector2>();

        rb.linearVelocity = new Vector2(movement.x, rb.linearVelocity.y);

        if(JumpAction.WasPressedThisFrame())
        {
            rb.linearVelocityY = jump;
        }
    }
}
``` 

#Bài mới
## 1. Trigger
- Trigger là một Collider2D dùng để phát hiện khi các GameObject đi vào, đi ra hoặc đang ở bên trong vùng của nó mà không tạo va chạm vật lý.
- Ví dụ:
 + Player đi vào vùng nhận nhiệm vụ.
 + Player chạm vùng chuyển màn.
 + Enemy phát hiện Player đi vào phạm vi.
 + Coin phát hiện Player chạm vào để biến mất.
 + Vùng gây sát thương.
- **So sánh Trigger và Collision**

| Collision                 | Trigger                     |
| ------------------------- | --------------------------- |
| Tạo tương tác vật lý      | Không tạo tương tác vật lý  |
| Object có thể bị đẩy/chặn | Object đi xuyên qua nhau    |
| Dùng `OnCollision...`     | Dùng `OnTrigger...`         |
| Ví dụ: tường, sàn         | Ví dụ: vùng phát hiện, item |
| Có phản ứng vật lý        | Chủ yếu để phát hiện        |

- Ví dụ: 
``` 
Player ────────► Wall
                 │
                 │
              bị chặn
``` 
- Collision: 
``` 
void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log("Đã va chạm!");
}
``` 
- Còn Trigger: Player vẫn có thể đi xuyên qua vùng đó.
``` 
Player ────────► [ Trigger Zone ]
                       │
                       │
                    phát hiện
``` 
- **Cách tạo Trigger**
 + Chọn GameObject cần làm vùng Trigger.
 + Ví dụ: Player, Enemy, Coin, DamageZone
 + Sau đó: Inspector → Add Component → Collider 2D
 + Sau đó bật: ☑ Is Trigger
 + Khi đó Collider trở thành Trigger.
- **Các hàm Trigger quan trọng**
  + OnTriggerEnter2D() Được gọi một lần khi một Collider2D đi vào Trigger.
 ``` 
private void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Object đi vào!");
}
``` 
 + Ví dụ:
``` 
 Trigger
   ┌──────────────┐
   │              │
───►     Player   │
   │              │
   └──────────────┘
          ↑, 
   OnTriggerEnter2D()
 ``` 

 + OnTriggerStay2D() Được gọi liên tục khi Object đang ở bên trong Trigger.
 ```
private void OnTriggerStay2D(Collider2D other)
{
    Debug.Log("Object đang ở trong!");
}
 ```

 + Ví dụ dùng cho: Vùng độc, Vùng lửa, Vùng hồi máu, Vùng phát hiện Enemy.

 + OnTriggerExit2D() Được gọi khi Object rời khỏi Trigger.
 ```
private void OnTriggerExit2D(Collider2D other)
{
    Debug.Log("Object đã rời khỏi!");
}
```

- Ví dụ Player nhặt Coin:
```
using UnityEngine;
public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Nhặt được Coin!");

            Destroy(gameObject);
        }
    }
}
```

## 2. Raycast 2D
- Raycast 2D trong Unity là một phương thức vật lý dùng để bắn một tia thẳng (ray) từ một điểm trong không gian 2D theo một hướng nhất định nhằm phát hiện các đối tượng có chứa thành phần va chạm (Collider2D).

- Nguyên lý hoạt động:

 + Điểm xuất phát (Origin): Vị trí bắt đầu bắn tia (ví dụ: vị trí nhân vật).

 + Hướng (Direction): Hướng mà tia di chuyển tới (ví dụ: hướng nhìn của nhân vật).

 + Khoảng cách (Distance): Chiều dài tối đa của tia.

 + Kết quả: Trả về thông tin của đối tượng đầu tiên mà tia cắt qua (RaycastHit2D), giúp biết đối tượng đó là gì, vị trí va chạm ở đâu.

- Ứng dụng phổ biến:

 + Kiểm tra mặt đất (Grounded Check): Xem nhân vật đang đứng trên mặt đất hay đang nhảy trên không.

 + Bắn súng / Tấn công: Xác định viên đạn hoặc đòn đánh trúng kẻ địch nào.

 + Tương tác chuột (Click/Tap): Phát hiện người chơi bấm vào vật phẩm nào trên màn hình 2D.

 + Tầm nhìn của AI (Line of Sight): Kiểm tra xem kẻ địch có nhìn thấy người chơi hay bị vách ngăn che khuất.

- Ví dụ: Bắn một tia từ vị trí hiện tại sang bên phải, khoảng cách là 5 đơn vị
```
RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 5f);
if (hit.collider != null) {
    // Đã va chạm với đối tượng
    Debug.Log("Đã bắn trúng: " + hit.collider.name);
}
```

## 3. Layer mask

- Layer Mask trong Unity là một bộ lọc dùng để chọn hoặc loại trừ các Layer (lớp đối tượng) cụ thể khi thực hiện các tác vụ như render hình ảnh (Camera Culling Mask) hoặc kiểm tra va chạm (Raycast, Physics).

- Ý nghĩa và Công dụng:

 + Giới hạn Camera (Culling Mask): Quyết định xem Camera sẽ hiển thị (vẽ) những đối tượng thuộc Layer nào và bỏ qua Layer nào.

 + Lọc va chạm vật lý (Physics/Raycast): Giúp hàm kiểm tra va chạm chỉ quét các đối tượng ở Layer định sẵn (ví dụ: chỉ va chạm với môi trường, bỏ qua nhân vật) để tối ưu hiệu năng.

 + Cách hoạt động: Layer Mask hoạt động dưới dạng mặt nạ bit (bitmask) trong lập trình, cho phép gộp nhiều Layer lại với nhau trong một biến duy nhất.