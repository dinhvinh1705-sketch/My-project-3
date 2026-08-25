1. var
- var cho phép C# tự xác định kiểu dữ liệu của biến dựa trên giá trị được gán lúc khai báo.
- Cú pháp: var <tên biến> = <giá trị>;

2. const
- const dùng để tạo hằng số.
- Cú pháp: const <kiểu dữ liệu> <tên biến> = <giá trị>;
- Lưu ý: const phải được gán giá trị ngay khi khai báo;

3. readonly
- readonly cũng dùng để gán các giá trị không thể thay đổi, nhung khác với const.
- Cú pháp: readonly <kiểu dữ liệu> <tên biến> = <giá trị>;
- Lưu ý: Khác với const phải được gán ngay khi khai báo, readonly không cần như vậy và có thể được gán trong constructor và giá trị của readonly phụ thuộc vào object. 

4. ref
- ref sẽ truyền tham chiếu.
- Ví dụ: 
void Dec(ref int a)
{
a--;
}
int T = 10;
Dec(ref T);
Console.Writeline(T);
-> Thì giá trị sẽ trả về 9;
5. out
- out cũng cho phép thay đổi biến bên ngoài, điểm đặc biệt của out là biến truyền vào không cần có giá trị trước.
void Tinh(int a, int b, out int sum)
{
sum = a+b;
}
int sum;
Tinh(3, 5, out sum);
Console.Writeline(sum);
->Kết quả sẽ trả về 8 là tổng cả a+b.
 

class trong C# thuần
1. Class trong C#
Class là một khuôn mẫu (blueprint) dùng để tạo ra các đối tượng (object).
Ví dụ, ta muốn tạo một nhân vật:
class Player
{
    public double hp, atk;
    public void Attack()
    {
      Console.Writeline("Attack");
    }
}
Ở đây:

Player → tên class
hp, atk → thuộc tính/dữ liệu của Player
Attack() → phương thức/hành động của Player
2. Tạo object từ class

Class chỉ là khuôn mẫu. Muốn sử dụng nó, ta tạo object:
Ví dụ:
Player Player1 = new Player();
Player player2 = new Player();

3. Constructor trong class

Constructor là hàm đặc biệt được gọi tự động khi tạo object.

Ví dụ:
class Player
{
private double hp, atk;
public Player(double hp, double atk)
{
this.hp = hp;
this. atk = atk;
}
public void TakeDamage(int a)
{
hp-=a;
}
public void AttackPlayer(Player O)
{
O.TakeDamage(atk);
}
4. Field, Property và Method

Trong class C#, bạn sẽ gặp 3 thứ rất thường xuyên:

Field: Lưu dữ liệu bên trong object:

private double hp;
private double attack;

Property

Cho phép kiểm soát việc đọc/ghi dữ liệu:

public double Hp
{
    get { return hp; }
    set { hp = value; }
}

Method

Đại diện cho hành động:

public void Attack()
{
    Console.WriteLine("Attack!");
}

5. public và private

Đây là phần rất quan trọng khi học class.

private

Chỉ được truy cập bên trong class:

class Player
{
    private double hp;
}

public

Có thể truy cập từ bên ngoài:

class Player
{
    public double hp;
}

7. Class có thể kế thừa class khác

Ví dụ:

class Animal
{
    public void Eat()
    {
        Console.WriteLine("Eating...");
    }
}

class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Woof!");
    }
}

Ta có:

Dog dog = new Dog();

dog.Eat();
dog.Bark();

Dog kế thừa từ Animal.

Đây là Inheritance (kế thừa).


1. MonoBehaviour

MonoBehaviour là class cơ sở (base class) mà các script C# của Unity thường kế thừa.

Ví dụ:

using UnityEngine;

public class Player : MonoBehaviour
{
}

Có thể hiểu đơn giản:

MonoBehaviour giúp một class C# trở thành Unity Component, có thể gắn vào một GameObject trong Unity và sử dụng các chức năng/lifecycle của Unity.

2. Tại sao phải kế thừa MonoBehaviour?

Nếu bạn viết:

public class Player
{
}

thì đây chỉ là class C# thông thường.

Bạn không thể trực tiếp kéo nó vào một GameObject trong Unity như một Component.

Nhưng nếu viết:

public class Player : MonoBehaviour
{
}

thì Unity có thể nhận diện Player là một Component.

Bạn có thể:

Gắn script vào GameObject
Sử dụng Start()
Sử dụng Update()
Sử dụng FixedUpdate()
Sử dụng Awake()
Truy cập transform
Truy cập gameObject
Sử dụng nhiều API của Unity

3. Các hàm quan trọng của MonoBehaviour
Awake()

Được gọi khi object/script được khởi tạo.

void Awake()
{
    Debug.Log("Awake");
}

Thường dùng để khởi tạo dữ liệu.

Start()

Được gọi trước frame đầu tiên khi script được kích hoạt.

void Start()
{
    Debug.Log("Game bắt đầu");
}

Ví dụ:

public class Player : MonoBehaviour
{
    int hp = 100;
    void Start()
    {
        Debug.Log("HP = " + hp);
    }
}


Update()

Được gọi mỗi frame.

void Update()
{
Debug.Log("Đang chạy");
}

Thường dùng cho:

Input
Di chuyển
Kiểm tra trạng thái
Logic diễn ra liên tục

Ví dụ:

void Update()
{
    if (Input.GetKey(KeyCode.W))
    {
        transform.position += Vector3.forward * Time.deltaTime;
    }
}
FixedUpdate()

Được gọi theo khoảng thời gian cố định.

void FixedUpdate()
{
}

Thường dùng cho physics, đặc biệt khi làm việc với Rigidbody.

Ví dụ:

void FixedUpdate()
{
    rb.AddForce(Vector3.forward);
}
OnCollisionEnter()

Được gọi khi xảy ra va chạm vật lý.

void OnCollisionEnter(Collision collision)
{
    Debug.Log("Đã va chạm!");
}
OnTriggerEnter()

Được gọi khi object đi vào một Trigger.

void OnTriggerEnter(Collider other)
{
    Debug.Log("Đã đi vào vùng Trigger");
}