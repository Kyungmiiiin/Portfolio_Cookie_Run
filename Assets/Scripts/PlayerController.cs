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

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D collider;
    [SerializeField] SpriteRenderer spriteRenderer;

    [Header("Space")]
    [SerializeField] int hp;
    [SerializeField] float jumpPower;
    [SerializeField] float moveSpeed;
    [SerializeField] int jumpCount;
    [SerializeField] bool isGround;

    // [Header("Events")]
    //public UnityEvent OnDied;
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

    // Ground�� Player�� Collider�� ���� �浹 �� �� 
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {
            
            // obstacle layer�� ������ damage�� ����
            Debug.Log("�浹!");
        }
        
        

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
        float curYSize = collider.size.y;
        collider.size = new Vector2(collider.size.x, curYSize / 2);
        float offset = collider.offset.y;
        collider.offset = new Vector2(collider.offset.x, offset / 2);
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
            float curYSize = collider.size.y;
            collider.size = new Vector2(collider.size.x, curYSize);
            float offset = collider.offset.y;
            collider.offset = new Vector2(collider.offset.x, offset);
        }
    }
    
    private void OnDamaged(Vector2 tagetPos)
    {
        // �浹 �� ��������
        gameObject.layer = 12;

        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        // ���� ������ �ð�
        Invoke("OffDamaged", 2);
    }
    private void OffDamaged()
    {
        // �������� ����
        gameObject.layer = 10;

        spriteRenderer.color = new Color(1, 1, 1, 1);

    }
}


