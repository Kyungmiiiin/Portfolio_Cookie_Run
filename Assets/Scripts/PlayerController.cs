using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Unity.Collections;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;
using JetBrains.Annotations;


public class PlayerController : MonoBehaviour, IScore
{
    [Header("Components")]
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D collider;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] ObstacleData[] obstacleDatas;
    [SerializeField] public int jellyScore;
    [SerializeField] public int coinScore;

    [Header("Space")]
    [SerializeField] public float hp;
    [SerializeField] public int MaxHp;
    [SerializeField] float jumpPower;
    [SerializeField] public float moveSpeed;
    [SerializeField] int jumpCount;
    [SerializeField] bool isGround;
    public float decreaseRate;   // 시간당 체력 감소량
    private float currentHealth; // 현재 체력
    float curYSize;
    float halfSize;
    float offset;
    float halfoffset;

    [Header("Events")]
    public UnityEvent OnDied;


    private void Start()
    {
        curYSize = collider.size.y;
        halfSize = curYSize / 2;
        offset = collider.offset.y;
        halfoffset = collider.offset.y / 2;

        hp = MaxHp; // 현재 체력을 시작 체력으로 초기화
        // 1초마다 DecreaseHealthOverTime 메소드를 호출하여 시간당 체력 감소
        InvokeRepeating("DecreaseHealthOverTime", 1f, 1f);
    }
    private void Jump()
    {
        // jumpspeed만큼 up
        rigid.velocity = Vector2.up * jumpPower;

        // jump를 실행했을때 jumpCount가 1로 바뀌면서 DoubleJump 가능
        jumpCount++;
    }

    private void OnJump(InputValue value)
    {
        // jumpcount가 0일때는 그냥 Jump만 가능
        if (jumpCount == 0)
        {
            Jump();
        }
        // jumpcount가 1일때만 DoubleJump 가능
        else if (jumpCount == 1)
        {
            DoubleJump();
        }
    }

    private void DoubleJump()
    {
        // jump한 상태에서 jumpspeed만큼 up
        rigid.velocity = Vector2.up * jumpPower;

        // DoubleJump를 실행했을때 jumpCount가 2로 바뀌면서 어떤 Jump도 실행하지않음
        jumpCount++;

        animator.SetBool("DoubleJump", true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {

            animator.SetBool("Damaged", true);

            // 충돌 시 무적상태가 됨
            gameObject.layer = 12;

            // Player의 투명도를 낮춰 무적상태임을 나타냄
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);

            // 무적 상태의 시간
            Invoke("OnTriggerExit", 3);

            if (this.hp != 0)
            {
                // 충돌한 Obstacle의 dmg만큼 Player의 hp가 깎임
                this.hp -= collision.gameObject.GetComponent<Obstacle>().data.dmg;
            }
            else if (this.hp <= 0)
            {
                OnDie();
            }

        }
        else
        {
            animator.SetBool("Damaged", false);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 무적상태 해제
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }


    // Ground와 Player의 Collider가 서로 충돌 할 때
    public void OnCollisionEnter2D(Collision2D collision)
    {

        // Gorund에 닿으면서 JumpCount 초기화
        isGround = true;
        jumpCount = 0;

        // 설정한 Bool(변수명, 값)을 넣음
        // ISGround가 true일때 Enter가 됨
        animator.SetBool("IsGround", isGround);
        animator.SetBool("DoubleJump", false);
    }

    // Ground와 Player의 Collider가 서로 충돌하지 않을때
    public void OnCollisionExit2D(Collision2D collision)
    {

        // ISGround가 false일때 Exit가 됨
        isGround = false;
        animator.SetBool("IsGround", isGround);
    }



    private void Slide()
    {
        animator.SetBool("IsSlide", true);

        // Slide Animation을 할때 Collider의 size와 offset을 줄여서 충돌범위를 줄임   
        collider.size = new Vector2(collider.size.x, halfSize);
        collider.offset = new Vector2(collider.offset.x, halfoffset);
    }

    private void OnSlide(InputValue value)
    {
        if (value.isPressed && isGround)
        {
            Slide();
        }
        else
        {
            animator.SetBool("IsSlide", false);

            // Slide Animation이 끝나면 Collider의 size와 offset을 원래의 상태로 복구시킴
            collider.size = new Vector2(collider.size.x, curYSize);
            collider.offset = new Vector2(collider.offset.x, offset);
        }
    }
    private void DecreaseHealthOverTime()
    {
        hp -= decreaseRate; // 현재 체력을 시간당 감소량만큼 감소

        if (hp <= 0)
        {
            OnDie(); // 체력이 0 이하이면 Die 메소드 호출
        }
    }

    public void OnDie()
    {
        animator.SetBool("Die", true);
        OnDied?.Invoke();
    }

    private void DisableInputSystem()
    {
        // 현재 사용 중인 InputSystem을 비활성화합니다.
        GetComponent<PlayerInput>().enabled = false;
    }


    // bool 변수로 type을 나눠서 Jelly(true)와 Coin(false)를 구분함
    public void GetScore(int score, bool type)
    {
        if (type)
        {
            jellyScore += score;
        }
        else
        {
            coinScore += score;
        }
    }

}




