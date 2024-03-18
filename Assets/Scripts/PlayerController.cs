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
    public float decreaseRate;   // �ð��� ü�� ���ҷ�
    private float currentHealth; // ���� ü��
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

        hp = MaxHp; // ���� ü���� ���� ü������ �ʱ�ȭ
        // 1�ʸ��� DecreaseHealthOverTime �޼ҵ带 ȣ���Ͽ� �ð��� ü�� ����
        InvokeRepeating("DecreaseHealthOverTime", 1f, 1f);
    }
    private void Jump()
    {
        // jumpspeed��ŭ up
        rigid.velocity = Vector2.up * jumpPower;

        // jump�� ���������� jumpCount�� 1�� �ٲ�鼭 DoubleJump ����
        jumpCount++;
    }

    private void OnJump(InputValue value)
    {
        // jumpcount�� 0�϶��� �׳� Jump�� ����
        if (jumpCount == 0)
        {
            Jump();
        }
        // jumpcount�� 1�϶��� DoubleJump ����
        else if (jumpCount == 1)
        {
            DoubleJump();
        }
    }

    private void DoubleJump()
    {
        // jump�� ���¿��� jumpspeed��ŭ up
        rigid.velocity = Vector2.up * jumpPower;

        // DoubleJump�� ���������� jumpCount�� 2�� �ٲ�鼭 � Jump�� ������������
        jumpCount++;

        animator.SetBool("DoubleJump", true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {

            animator.SetBool("Damaged", true);

            // �浹 �� �������°� ��
            gameObject.layer = 12;

            // Player�� ������ ���� ������������ ��Ÿ��
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);

            // ���� ������ �ð�
            Invoke("OnTriggerExit", 3);

            if (this.hp != 0)
            {
                // �浹�� Obstacle�� dmg��ŭ Player�� hp�� ����
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
        // �������� ����
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }


    // Ground�� Player�� Collider�� ���� �浹 �� ��
    public void OnCollisionEnter2D(Collision2D collision)
    {

        // Gorund�� �����鼭 JumpCount �ʱ�ȭ
        isGround = true;
        jumpCount = 0;

        // ������ Bool(������, ��)�� ����
        // ISGround�� true�϶� Enter�� ��
        animator.SetBool("IsGround", isGround);
        animator.SetBool("DoubleJump", false);
    }

    // Ground�� Player�� Collider�� ���� �浹���� ������
    public void OnCollisionExit2D(Collision2D collision)
    {

        // ISGround�� false�϶� Exit�� ��
        isGround = false;
        animator.SetBool("IsGround", isGround);
    }



    private void Slide()
    {
        animator.SetBool("IsSlide", true);

        // Slide Animation�� �Ҷ� Collider�� size�� offset�� �ٿ��� �浹������ ����   
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

            // Slide Animation�� ������ Collider�� size�� offset�� ������ ���·� ������Ŵ
            collider.size = new Vector2(collider.size.x, curYSize);
            collider.offset = new Vector2(collider.offset.x, offset);
        }
    }
    private void DecreaseHealthOverTime()
    {
        hp -= decreaseRate; // ���� ü���� �ð��� ���ҷ���ŭ ����

        if (hp <= 0)
        {
            OnDie(); // ü���� 0 �����̸� Die �޼ҵ� ȣ��
        }
    }

    public void OnDie()
    {
        animator.SetBool("Die", true);
        OnDied?.Invoke();
    }

    private void DisableInputSystem()
    {
        // ���� ��� ���� InputSystem�� ��Ȱ��ȭ�մϴ�.
        GetComponent<PlayerInput>().enabled = false;
    }


    // bool ������ type�� ������ Jelly(true)�� Coin(false)�� ������
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




