#bài cũ

Trong ngành game, “vòng đời” thường được gọi là Game Life Cycle – quá trình một game đi từ lúc hình thành ý tưởng cho đến khi phát hành, vận hành và cuối cùng được ngừng hỗ trợ.

Có thể hiểu đơn giản:

Ý tưởng → Phát triển → Phát hành → Vận hành → Cập nhật → Suy giảm → Kết thúc

1. Concept – Ý tưởng

Đây là giai đoạn hình thành game.

Ý tưởng gameplay
Thể loại game
Đối tượng người chơi
Core loop
Art style
Platform: PC, Mobile, Console...
Nghiên cứu thị trường và đối thủ
Xây dựng concept/GDD ban đầu

Ví dụ: Nhóm quyết định làm một game puzzle mobile theo cơ chế điều khiển các mũi tên.

2. Pre-production – Tiền sản xuất

Biến ý tưởng thành kế hoạch có thể thực hiện.

Các công việc chính:

Game Design
Level Design
Art Direction
Technical Design
Prototype
Xác định công nghệ/engine
Lập kế hoạch nhân sự và thời gian
Xây dựng GDD

Ở cuối giai đoạn này thường cần có prototype/playable build để chứng minh game có thể chơi được.

3. Production – Sản xuất

Đây thường là giai đoạn tốn nhiều thời gian và nhân lực nhất.

Team bắt đầu sản xuất nội dung thật:

Programming
Character
Environment
Animation
VFX
UI/UX
Sound/Music
Level
System
Optimization

Ví dụ với Arrows - Puzzle Escape, đây là lúc team xây dựng hàng loạt level, hệ thống Undo, Locked Area, Magnet, Sync Movement...

4. Testing / QA – Kiểm thử

Game được kiểm tra để tìm lỗi và vấn đề về trải nghiệm.

Có thể kiểm tra:

Bug
Crash
Performance
Difficulty
Balance
UX
Compatibility
Loading time
Tutorial
Retention

Ví dụ:

Level 20 có tỷ lệ fail quá cao → Designer phân tích dữ liệu → điều chỉnh level → test lại.

5. Launch – Phát hành

Game chính thức đến tay người chơi.

Thường bao gồm:

Soft Launch / Beta
Marketing
Store submission
Global Launch
Server preparation
Community management

Đây cũng là lúc marketing thường tăng mạnh để thu hút người chơi.

6. Live Ops – Vận hành

Đối với game online/mobile, đây là một giai đoạn rất quan trọng.

Game không kết thúc khi launch mà tiếp tục được vận hành:

Update → Event → Content → Balance → Analytics → Update tiếp

Ví dụ:

Thêm level mới
Event theo mùa
Battle Pass
Character mới
Item mới
Cân bằng gameplay
Sửa bug
Cải thiện retention

Dữ liệu người chơi được sử dụng để quyết định update tiếp theo.

7. Growth / Maturity – Tăng trưởng & ổn định

Nếu game thành công:

Lượng người chơi tăng
Community phát triển
Doanh thu tăng
Nội dung mới liên tục
Marketing mở rộng
Có thể phát triển esports hoặc cộng đồng

Đây thường là giai đoạn game đạt đỉnh về lượng người chơi/doanh thu.

8. Decline – Suy giảm

Sau một thời gian, game có thể bắt đầu giảm:

DAU/MAU giảm
Người chơi mới giảm
Retention giảm
Doanh thu giảm
Community hoạt động ít hơn

Nguyên nhân có thể là:

Game mới xuất hiện
Người chơi mất hứng thú
Content không còn hấp dẫn
Cạnh tranh tăng
Marketing giảm
Update không đáp ứng nhu cầu người chơi

9. Sunset – Kết thúc vòng đời

Khi chi phí vận hành lớn hơn giá trị mà game tạo ra, nhà phát hành có thể quyết định sunset game.

Có thể bao gồm:

Ngừng update
Ngừng bán một số nội dung
Đóng đăng ký/tải game
Đóng server
Ngừng hỗ trợ

Trong Unity, Gizmos là các hình ảnh/đường vẽ hỗ trợ hiển thị trong Scene View để lập trình viên và designer dễ quan sát, debug và chỉnh sửa game.

Bạn có một vùng phát hiện của enemy:

Enemy
         👾
      ┌───────┐
      │       │
      │ Detect│
      │ Area  │
      └───────┘


Vùng Detect Area có thể được vẽ bằng Gizmo. Nó giúp bạn nhìn thấy vùng này trong Scene, nhưng không nhất thiết xuất hiện trong game khi người chơi chạy game.

Một số trường hợp phổ biến:

👁️ Hiển thị đường raycast
📦 Hiển thị Collider / vùng va chạm
🎯 Hiển thị vùng phát hiện của enemy
📍 Hiển thị điểm spawn
🔭 Hiển thị phạm vi của camera
🧭 Hiển thị hướng di chuyển
📏 Hiển thị khoảng cách
🗺️ Hiển thị vùng hoạt động của một object
🐛 Debug logic trong game

Asset là bất kỳ tài nguyên nào được dùng để xây dựng game, ví dụ:

🖼️ Image / Sprite – hình ảnh nhân vật, background, icon
🎵 Audio – nhạc, hiệu ứng âm thanh
🎬 Animation – animation nhân vật
🧱 3D Model – model nhân vật, nhà cửa, vật thể
✨ Material / Shader – vật liệu và hiệu ứng hiển thị
📜 Script C# – code điều khiển game
🗺️ Scene – màn chơi
🎨 Prefab – object đã được cấu hình sẵn

Trong Unity, Transform là một Component rất quan trọng, dùng để xác định vị trí, góc xoay và kích thước của một GameObject trong không gian.

Transform cho Unity biết GameObject đang ở đâu, xoay như thế nào và có kích thước bao nhiêu.

1. Position – Vị trí

Xác định GameObject nằm ở đâu.

X: trái ↔ phải
Y: dưới ↔ trên
Z: trước ↔ sau

2. Rotation – Góc xoay

Xác định GameObject xoay theo hướng nào.

3. Scale – Kích thước

Xác định kích thước của GameObject.

Một số lệnh Transform rất hay dùng

// Lấy vị trí
Vector3 pos = transform.position;

// Thay đổi vị trí
transform.position = new Vector3(10, 0, 0);

// Di chuyển
transform.Translate(Vector3.forward * 5f * Time.deltaTime);

// Xoay
transform.Rotate(0, 90, 0);

// Thay đổi kích thước
transform.localScale = new Vector3(2, 2, 2);

position và localPosition

Đây là phần khá quan trọng khi làm Unity.

transform.position = vị trí so với World

transform.localPosition = vị trí so với Parent

#time và các hàm của time

Trong Unity, Time là một class dùng để lấy và xử lý thời gian trong game. Nó rất quan trọng khi làm movement, animation, cooldown, timer, spawn, attack speed...

1. Time.deltaTime

Time.deltaTime = thời gian giữa frame hiện tại và frame trước.

transform.Translate(Vector3.forward * 5f * Time.deltaTime);

2. Time.time

Trả về số giây đã trôi qua kể từ khi game bắt đầu.

Debug.Log(Time.time);

Có thể dùng để tạo cooldown:

if (Time.time >= nextAttackTime)
{
    Attack();
    nextAttackTime = Time.time + 2f;
}

→ Nhân vật có thể attack mỗi 2 giây.

3. Time.timeScale

Điều chỉnh tốc độ thời gian trong game.

Time.timeScale = 1f;

Các giá trị thường dùng

timeScale = 1    → thời gian bình thường
timeScale = 0.5  → chậm 50%
timeScale = 0    → game gần như dừng
timeScale = 2    → nhanh gấp đôi

4. Time.unscaledDeltaTime

Tương tự deltaTime nhưng không bị ảnh hưởng bởi Time.timeScale.

Time.unscaledDeltaTime

Thường dùng cho:

UI animation
Pause menu
Timer UI
Animation không muốn bị pause

5. Time.fixedDeltaTime

Khoảng thời gian giữa các lần chạy của FixedUpdate.

Giá trị mặc định thường là: 0.02 giây

tương đương khoảng: 50 lần/giây

Thường liên quan đến Physics:

void FixedUpdate()
{
    rb.AddForce(Vector3.forward * 10f);
}

6. Time.realtimeSinceStartup

Số giây đã trôi qua kể từ khi Unity bắt đầu chạy, không phụ thuộc Time.timeScale.

Debug.Log(Time.realtimeSinceStartup);

7. Time.frameCount

Số frame đã được render kể từ khi game bắt đầu.

Debug.Log(Time.frameCount);

8. Time.timeSinceLevelLoad

Số giây kể từ khi Scene hiện tại được load.

Debug.Log(Time.timeSinceLevelLoad);

#Mathf

Trong Unity C#, Mathf là một class chứa các hàm toán học tiện dụng được Unity cung cấp. Nó được sử dụng rất nhiều khi làm movement, rotation, khoảng cách, animation, AI, gameplay, damage...

Mathf = bộ công cụ toán học dành cho game.

1. Mathf.Abs() – Giá trị tuyệt đối

Trả về giá trị không âm.

float x = Mathf.Abs(-10);
Debug.Log(x);

2. Mathf.Max() và Mathf.Min()

Lấy lớn nhất và nhỏ nhất.

float x = Mathf.Max(10, 20);
float x = Mathf.Min(10, 20);

3. Mathf.Clamp()

Đây là hàm rất hay dùng trong game.

Dùng để giới hạn một giá trị trong khoảng.

float hp = Mathf.Clamp(120, 0, 100);

4. Mathf.Clamp01() 

Giống Clamp, nhưng giới hạn trong: 0 → 1

float value = Mathf.Clamp01(1.5f); → 1

Mathf.Clamp01(-0.5f); → 0

5. Mathf.Round()

Làm tròn số.

float x = Mathf.Round(3.6f);

6. Mathf.Floor() và Mathf.Ceil()
Floor() – làm tròn xuống

Ceil() – làm tròn lên

7. Mathf.Lerp()

Đây là một trong những hàm quan trọng nhất khi làm Unity.

Lerp = Linear Interpolation – nội suy tuyến tính.

Mathf.Lerp(a, b, t);

Trong đó:

a: giá trị bắt đầu
b: giá trị kết thúc
t: tỷ lệ từ 0 → 1

8. Mathf.MoveTowards()

Dùng để di chuyển một giá trị từng bước đến mục tiêu.

float current = 0;
float target = 100;

current = Mathf.MoveTowards(
    current,
    target,
    5f
);

9. Mathf.Sin() và Mathf.Cos()

Dùng để tính sin/cos.

float x = Mathf.Sin(Time.time);
float y = Mathf.Cos(Time.time);

10. Mathf.Sqrt()

Tính căn bậc hai.

float x = Mathf.Sqrt(25);

11. Mathf.Pow()

Tính lũy thừa.

float x = Mathf.Pow(2, 3);

12. Mathf.PI

Hằng số π:

Debug.Log(Mathf.PI);

13. Đổi độ ↔ radian
Mathf.Deg2Rad

Đổi degree → radian

float rad = 90 * Mathf.Deg2Rad;

14. Mathf.Repeat()

Lặp một giá trị trong một khoảng.

float x = Mathf.Repeat(12, 10); → 2

15. Mathf.PingPong()

Tạo giá trị chạy qua lại giữa 0 và một giá trị.

float x = Mathf.PingPong(Time.time, 10);


#Bài mới

1. Va chạm (Collision) trong Unity

Collision là khi hai đối tượng trong game tiếp xúc/đụng vào nhau và hệ thống vật lý xử lý sự va chạm.

Các thành phần cần có

Collider2D

Collider2D xác định vùng hình học dùng để phát hiện va chạm.

Một số Collider2D thường gặp:

Box Collider 2D

Circle Collider 2D

Capsule Collider 2D

Polygon Collider 2D

Composite Collider 2D

Ví dụ:

Player
├── Transform
├── Sprite Renderer
├── Rigidbody 2D
└── Box Collider 2D

Rigidbody2D

Rigidbody2D đưa GameObject vào hệ thống vật lý 2D, cho phép Unity xử lý gravity, lực, vận tốc và va chạm.

Điều kiện cơ bản để Collision hoạt động

Thông thường cần:

Collider2D
    +
Collider2D
    +
ít nhất một Rigidbody2D
    ↓
Collision có thể được phát hiện

Ngoài ra, Collider phải có:

Is Trigger = OFF

nếu muốn sử dụng Collision.

2. Các hàm Collision 2D

OnCollisionEnter2D()

Được gọi khi bắt đầu va chạm.

private void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log("Đã va chạm!");
}

OnCollisionStay2D()

Được gọi trong thời gian hai vật thể vẫn đang va chạm.

private void OnCollisionStay2D(Collision2D collision)
{
    Debug.Log("Đang va chạm!");
}

OnCollisionExit2D()

Được gọi khi hai vật thể không còn va chạm.

private void OnCollisionExit2D(Collision2D collision)
{
    Debug.Log("Đã rời khỏi vật thể!");
}

Luồng hoạt động

Bắt đầu đụng
     ↓
OnCollisionEnter2D()
     ↓
Đang đụng
     ↓
OnCollisionStay2D()
     ↓
Không còn đụng
     ↓
OnCollisionExit2D()

3. Rigidbody2D

Rigidbody2D là component dùng để đưa GameObject 2D vào hệ thống vật lý của Unity.

Rigidbody2D có 3 loại chính:

Dynamic

Kinematic

Static

3.1 Dynamic

Dynamic là loại Rigidbody2D phổ biến nhất.

Vật thể Dynamic được Unity điều khiển bằng hệ thống vật lý và có thể chịu tác động của:

Gravity

Force

Velocity

Collision

Friction

Mass

Ví dụ:

Player
├── Rigidbody 2D → Dynamic
└── Collider 2D

Ví dụ dùng lực:

public Rigidbody2D rb;

void FixedUpdate()
{
    rb.AddForce(Vector2.right * 10f);
}

Thường dùng cho

Player

Enemy

Quả bóng

Vật thể rơi

Thùng gỗ

Một số vật thể vật lý

3.2 Kinematic

Kinematic thường dùng cho vật thể được điều khiển chủ động bằng code thay vì để hệ thống vật lý tự điều khiển như Dynamic.

Ví dụ:

Platform
├── Rigidbody 2D → Kinematic
└── Collider 2D

Có thể di chuyển bằng:

rb.MovePosition(
    rb.position + Vector2.right * speed * Time.fixedDeltaTime
);

Thường dùng cho

Platform di chuyển

Cửa

Thang máy

Vật thể chuyển động theo script

Một số Enemy có chuyển động được lập trình

3.3 Static

Static dùng cho những vật thể không di chuyển trong hệ thống vật lý.

Ví dụ:

Ground
├── Rigidbody 2D → Static
└── Box Collider 2D

Thường dùng cho

Ground

Wall

Trần

Địa hình

Chướng ngại vật cố định

3.4 So sánh Dynamic, Kinematic và Static

Loại

Gravity

Vật lý

Điều khiển bằng code

Thường dùng

Dynamic

Có

Có

Có thể

Player, Enemy, Ball

Kinematic

Không theo cách Dynamic

Hạn chế/được kiểm soát chủ động

Có

Platform, Door

Static

Không

Không di chuyển

Không nên di chuyển

Ground, Wall

Cách nhớ

Dynamic: Unity điều khiển tôi bằng vật lý.

Kinematic: Code chủ động điều khiển tôi.

Static: Tôi đứng yên.

4. Trigger

Trigger là một vùng dùng để phát hiện khi một vật thể đi vào, ở trong hoặc đi ra, nhưng không tạo va chạm vật lý để chặn vật thể.

Có thể hiểu:

Collider thường = đụng vào thì bị chặn.

Trigger = đi vào vùng này thì tôi biết.

Bật Trigger

Trong Collider2D:

Is Trigger = ON

Ví dụ:

┌──────────────────────┐
│                      │
│      Trigger Area    │
│                      │
└──────────────────────┘

Player có thể đi qua vùng này và sự kiện Trigger được gọi.

4.1 Trigger dùng để làm gì?

Trigger thường dùng để:

Nhặt vật phẩm

Vùng gây sát thương

Phát hiện Player

Cửa

Checkpoint

Vùng phát hiện Enemy

Kích hoạt sự kiện

Kích hoạt hội thoại

Chuyển khu vực

4.2 Các hàm Trigger 2D

OnTriggerEnter2D()

Được gọi khi vật thể bắt đầu đi vào Trigger.

private void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Có vật thể đi vào!");
}

OnTriggerStay2D()

Được gọi khi vật thể đang ở trong Trigger.

private void OnTriggerStay2D(Collider2D other)
{
    Debug.Log("Đang ở trong Trigger!");
}

OnTriggerExit2D()

Được gọi khi vật thể đi ra khỏi Trigger.

private void OnTriggerExit2D(Collider2D other)
{
    Debug.Log("Đã đi ra!");
}

Luồng hoạt động

Đi vào
  ↓
OnTriggerEnter2D()
  ↓
Ở bên trong
  ↓
OnTriggerStay2D()
  ↓
Đi ra
  ↓
OnTriggerExit2D()

4.3 Điều kiện để Trigger hoạt động

Với Unity 2D, cần:

Collider2D
    +
Collider2D
    +
ít nhất một Rigidbody2D
    ↓
Trigger Event

Và ít nhất một Collider phải có:

Is Trigger = ON

Ví dụ:

Player
├── Rigidbody 2D
└── Collider 2D

Coin
└── Circle Collider 2D
    └── Is Trigger = ON

4.4 Ví dụ nhặt Coin

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

Player cần có:

Tag = Player

5. Collision và Trigger khác nhau

Collision

Trigger

Va chạm vật lý

Phát hiện vùng

Có thể chặn vật thể

Không chặn vật thể

Is Trigger = OFF

Is Trigger = ON

OnCollisionEnter2D()

OnTriggerEnter2D()

OnCollisionStay2D()

OnTriggerStay2D()

OnCollisionExit2D()

OnTriggerExit2D()

Cách nhớ

Collision: Tôi đụng vào cái gì?

Trigger: Có ai đi vào vùng của tôi không?

6. Raycast 2D

Raycast2D là một tia được bắn từ một vị trí theo một hướng để kiểm tra xem tia có chạm vào Collider2D nào hay không.

Ví dụ:

Player ● ─────────────────→ █ Wall
              Raycast

Raycast không phải là vật thể, mà là một phép kiểm tra.

6.1 Raycast2D dùng để làm gì?

Kiểm tra Player có đứng trên mặt đất không.

Kiểm tra phía trước có tường không.

Enemy kiểm tra có nhìn thấy Player không.

Kiểm tra khoảng cách đến vật thể.

Phát hiện vật thể để tương tác.

Kiểm tra đường đi.

Xác định vật thể bị bắn trúng.

6.2 Cú pháp cơ bản

RaycastHit2D hit = Physics2D.Raycast(
    transform.position,
    Vector2.down,
    1f
);

Ý nghĩa:

Physics2D.Raycast(
    vị trí bắt đầu,
    hướng,
    độ dài
)

Trong đó:

transform.position: điểm bắt đầu.

Vector2.down: hướng tia.

1f: độ dài tia.

6.3 Kiểm tra Raycast có trúng hay không

RaycastHit2D hit = Physics2D.Raycast(
    transform.position,
    Vector2.down,
    1f
);

if (hit.collider != null)
{
    Debug.Log("Đã phát hiện vật thể!");
}

Nếu:

hit.collider == null

→ Không phát hiện Collider2D.

Nếu:

hit.collider != null

→ Raycast đã chạm một Collider2D.

6.4 Lấy GameObject bị phát hiện

RaycastHit2D hit = Physics2D.Raycast(
    transform.position,
    Vector2.right,
    5f
);

if (hit.collider != null)
{
    Debug.Log(hit.collider.gameObject.name);
}

6.5 Raycast kết hợp Tag

RaycastHit2D hit = Physics2D.Raycast(
    transform.position,
    Vector2.right,
    5f
);

if (hit.collider != null)
{
    if (hit.collider.CompareTag("Player"))
    {
        Debug.Log("Đã nhìn thấy Player!");
    }
}

6.6 Raycast có thể bị chặn

Ví dụ:

Enemy ● ─────→ █ Wall █ ─────→ Player ●
                ↑
              Raycast

Nếu Raycast gặp Wall trước, nó sẽ phát hiện Wall thay vì Player.

Điều này rất hữu ích khi làm AI phát hiện Player.

6.7 Vẽ Raycast

Raycast không tự hiển thị rõ trong Game View. Có thể dùng:

Debug.DrawRay(
    transform.position,
    Vector2.down * 1f
);

để nhìn thấy tia trong Scene View khi chạy game.

6.8 Raycast kiểm tra Player có đứng trên đất

using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask groundLayer;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            Vector2.down,
            1f,
            groundLayer
        );

        if (hit.collider != null)
        {
            Debug.Log("Đang ở trên mặt đất!");
        }
    }
}

7. Layer và LayerMask

7.1 Layer

Layer dùng để phân loại GameObject.

Ví dụ:

Player → Layer Player
Enemy  → Layer Enemy
Ground → Layer Ground
Coin   → Layer Item

Layer có thể tạo trong:

Inspector
→ Layer
→ Add Layer

7.2 LayerMask

LayerMask là một bộ lọc Layer.

Ví dụ bạn muốn Raycast chỉ kiểm tra Ground:

public LayerMask groundLayer;

Trong Inspector:

Ground Layer

☐ Player
☐ Enemy
☑ Ground
☐ Item

Raycast chỉ kiểm tra những Layer được chọn.

7.3 LayerMask với Raycast

public LayerMask groundLayer;

void Update()
{
    RaycastHit2D hit = Physics2D.Raycast(
        transform.position,
        Vector2.down,
        1f,
        groundLayer
    );

    if (hit.collider != null)
    {
        Debug.Log("Đang đứng trên đất!");
    }
}

LayerMask giúp Raycast không phải kiểm tra tất cả Collider2D.

7.4 Layer và LayerMask khác nhau

Layer

Trả lời:

GameObject này thuộc nhóm nào?

Player → Player
Enemy → Enemy
Ground → Ground

LayerMask

Trả lời:

Tôi muốn kiểm tra những nhóm nào?

Raycast
   ↓
LayerMask
   ↓
☑ Ground
☑ Wall
☐ Enemy
☐ Player

Cách nhớ

Layer = Tôi thuộc nhóm nào?

LayerMask = Tôi muốn kiểm tra nhóm nào?

8. LayerMask và Collision

LayerMask thường được dùng để lọc Raycast, còn việc Layer nào được phép va chạm với Layer nào có thể thiết lập bằng Layer Collision Matrix.

Vào:

Edit
→ Project Settings
→ Physics 2D
→ Layer Collision Matrix

Ví dụ:
      Player Enemy Ground Item
Player	✅	  ✅	 ✅	   ❌
Enemy	✅	  ❌	 ✅   ❌
Ground	✅	  ✅	 ✅	   ❌
Item	❌	  ❌	 ❌	   ❌
Ví dụ:

Player + Ground → Có Collision
Player + Enemy  → Có Collision
Enemy + Enemy   → Không Collision

9. Các cách di chuyển nhân vật

Có nhiều cách di chuyển nhân vật trong Unity. Với game 2D, các cách quan trọng gồm:

Transform

Rigidbody2D velocity/linearVelocity

Rigidbody2D.MovePosition()

Rigidbody2D.AddForce()

Character Controller (chủ yếu cho 3D)

NavMesh (thường dùng cho AI/NPC)

9.1 Di chuyển bằng Transform

Đây là cách đơn giản nhất.

public float speed = 5f;

void Update()
{
    transform.position += Vector3.right * speed * Time.deltaTime;
}

Vector3.right tương đương:

(1, 0, 0)

Ưu điểm

Dễ hiểu.

Code đơn giản.

Phù hợp với vật thể không cần vật lý.

Nhược điểm

Không nên dùng Transform để điều khiển trực tiếp một Rigidbody2D nếu muốn hệ thống vật lý xử lý chuyển động, vì có thể gây ra vấn đề với collision/physics.

10. Di chuyển bằng Rigidbody2D velocity / linearVelocity

Đây là cách phổ biến khi làm Player 2D có vật lý.

Unity phiên bản sử dụng velocity

public Rigidbody2D rb;
public float speed = 5f;

void Update()
{
    float x = Input.GetAxisRaw("Horizontal");

    rb.velocity = new Vector2(
        x * speed,
        rb.velocity.y
    );
}

Unity 6

Unity 6 sử dụng linearVelocity:

public Rigidbody2D rb;
public float speed = 5f;

void Update()
{
    float x = Input.GetAxisRaw("Horizontal");

    rb.linearVelocity = new Vector2(
        x * speed,
        rb.linearVelocity.y
    );
}

Ý tưởng:

A / ← → D / →
     ↓
Input
     ↓
Tính x
     ↓
Thay đổi vận tốc X
     ↓
Rigidbody2D di chuyển

Giữ nguyên vận tốc Y giúp Gravity vẫn hoạt động.

11. Di chuyển bằng Rigidbody2D.MovePosition()

MovePosition() cho phép chủ động đưa Rigidbody2D đến vị trí mới.

Ví dụ:

public Rigidbody2D rb;
public float speed = 5f;

void FixedUpdate()
{
    float x = Input.GetAxisRaw("Horizontal");

    Vector2 movement = new Vector2(x, 0);

    rb.MovePosition(
        rb.position + movement * speed * Time.fixedDeltaTime
    );
}

Luồng:

Input
  ↓
Tính hướng
  ↓
Tính vị trí mới
  ↓
MovePosition()
  ↓
Rigidbody2D di chuyển

Thường phù hợp với chuyển động được điều khiển chủ động bằng code, đặc biệt với Rigidbody2D Kinematic.

12. Di chuyển bằng AddForce()

AddForce() tạo lực tác động lên Rigidbody2D.

public Rigidbody2D rb;

void FixedUpdate()
{
    rb.AddForce(Vector2.right * 10f);
}

Luồng:

AddForce()
    ↓
   Lực
    ↓
Rigidbody2D
    ↓
Di chuyển

Thường dùng cho

Quả bóng.

Vật thể bị đẩy.

Vật lý.

Một số chuyển động có quán tính.

Nếu dùng AddForce liên tục cho Player, cần kiểm soát tốc độ để tránh nhân vật tăng tốc quá nhiều.

13. Character Controller

CharacterController chủ yếu được dùng trong game 3D.

Ví dụ:

CharacterController controller;

void Update()
{
    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(x, 0, z);

    controller.Move(
        movement * speed * Time.deltaTime
    );
}

Với game 2D, thường dùng:

Rigidbody2D
+
Collider2D

thay vì CharacterController 3D.

14. NavMesh

NavMesh được dùng nhiều cho nhân vật AI/NPC tự tìm đường.

Ví dụ:

Enemy
  ●
  │
  │ Tự tìm đường
  ↓
████████
      ↓
Player

Enemy có thể tìm đường tránh chướng ngại vật để đến vị trí mục tiêu.

Thường dùng cho:

Enemy AI

NPC

Quái vật đuổi Player

NPC đi đến một vị trí