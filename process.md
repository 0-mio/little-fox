# 卷

----

## week02

----

### day01

##### 生命周期

>Awake ->OnEable-> Start -> -> FixedUpdate-> Update  -> LateUpdate ->OnGUI ->Reset -> OnDisable ->OnDestroy

##### Rigidbody刚体

>重力，阻力等

##### Box Collider2D碰撞体

##### Tilemap

>配合Collider可让角色站在地面上

----

### day02

##### 最小单位Gameobject

> this.gameobject.name
>
> this.gameobject.activeSelf

##### 基本规则

>1. 创建规则
>2. MonoBehavior基类
>3. 不继承MonoBehavior的类

![基础](C:\Users\Mio\Pictures\微信图片_20211105133101.jpg)

----

### day03

##### Inspector窗口可编辑的变量

>dictionary
>
>struct                      哒咩

##### Vector基础

>可以将Rigidbody依附在其上

eg：

```c#
public Rigidbody2D rb;

rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y); 
```

>Vector2(x,y)

##### transform

>transform.xxx == xxx
>
>可改变其的变量

eg:

```c#
float facedirection = Input.GetAxisRaw("Horizontal");

if(facedirection!=0)
    transform.localScale = new Vector3(facedirection,1,1)
```

>GetAxisRaw 取值为[-1,1] &&为整数
>
>GetAxis 包含小数
>
>Horizontal为按键设置，可修改

### day04

##### Input

>可控制鼠标，键盘

##### Animator

>控制动画极其顺序，转化条件

```c#
public Animator animator;

animator.Set类型("条件名称",改变为什么)；
```

##### **图层**

```c#
public LayerMask grand;
public Collider2D coll;

if(coll.IsTouchingLayers(grand))
```

----

### day05

##### cinemamachine

>打造属于自己的镜头风格

##### isTrigger触发器

>配合collider可制作取得物品的动画

```c#
public float cherry；
    ......

void OnTriggerEnter2D(Collider2D collision)//(被碰撞物体的参数)
    {
        if(collision.tag == "collections")//tag知识点
        {
            Destroy(collision.gameObject);
            Cherry++;
        }
    }
```

>关于OnCollisionEnter2D和OnTriggerEnter2D两种碰撞触发
>
>一：产生碰撞的条件
>
>1：若要产生碰撞，必须双方都要有碰撞器。
>
>2：运动的一方一定要有刚体，另一方有无刚体无所谓，但需要注意的是如果是静止的物体带刚体，一开始效果跟运动的物体带刚体一样，但由于刚体放在静止的物体上会休眠，所以一般要将刚体放在运动的物体身上。简而言之就是至少要有一方有刚体，一般为运动方。
>
>注：如果运动的一方无刚体，它去碰撞静止的不带刚体的物体，相当于没有撞上，即使双方带碰撞体也会相互穿过。
>
>       如果运动的一方有刚体，它去碰静止的不带刚体的物体（即没有物理演算），则该物体不会因为被碰撞而发生移动。
>
>总的来说，如果想要两个物体碰撞后都有因为物理演算而发生位移，则双方都要有刚体和碰撞器。
>
>二：接触的两种方式
>
>1：Collision碰撞，造成物理碰撞，可以在碰撞时执行OnCollision事件。
>
>2：Trigger触发，取消所有的物理碰撞，可以在触发时执行OnTrigger事件。
>
>注：两个物体接触不可能同时产生碰撞+接触，最多产生一种。但是可以AB产生碰撞，AC产生触发。
>
> 
>
>三：产生不同方式接触的条件
>
>1：Collision碰撞
>
>     （1）：双方都有碰撞体
>    
>     （2）：运动的一方必须有刚体
>    
>     （3）：双方不可同时勾选Kinematic运动学。
>    
>     （4）：双方都不可勾选Trigger触发器。
>
>2：Trigger触发
>
>     （1）：双方都有碰撞体
>    
>     （2）：运动的一方必须是刚体
>    
>     （3）：至少一方勾选Trigger触发器
>
> 
>
>
>四：接触后事件细分为Enter,Stay,Exit三种（以Trigger为例，分别为OnTriggerEnter、OnTriggerStay、OnTriggerExit）
>
>1：Enter事件表示两物体接触瞬间，会执行一次。
>
>2：Stay事件表示两物体持续接触，会不断执行。
>
>3：Exit事件当两物体分开瞬间，会执行一次。
>
> 
>
>五：OnTriggerEnter这类的属于Trigger触发，OnCollisionEnter这类的属于Collision碰撞
>
>
>
>总结：OnTriggerEnter和OnCollisionEnter的选择。
>
>如果想实现两个刚体物理的实际碰撞效果时候用OnCollisionEnter，Unity引擎会自动处理刚体碰撞的效果。
>
>如果想在两个物体碰撞后自己处理碰撞事件用OnTriggerEnter。

##### private

>可用private前缀隐藏不会改变的量
>
>再在void Start中调用

```c#
private Rigidbody2D rb;

void Start
{
    rb = GetComponent<Rigidbody>();
}
```
