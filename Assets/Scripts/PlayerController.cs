using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Unity.Collections;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D collider;

    [Header("Space")]
    [SerializeField] float jumpSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] int jumpCount;
    [SerializeField] bool isGround;

    // [Header("Events")]
    //public UnityEvent OnDied;
    private void Jump()
    {
        // jumpspeed��ŭ up
        rigid.velocity = Vector2.up * jumpSpeed;

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
        rigid.velocity = Vector2.up * jumpSpeed;

        // DoubleJump�� ���������� jumpCount�� 2�� �ٲ�鼭 � Jump�� ������������
        jumpCount++;

        animator.SetBool("DoubleJump", true);
    }

    // Ground�� Player�� Collider�� ���� �浹 �� �� 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // ������ Bool(������, ��)�� ����
        // ISGround�� true�϶� Enter�� ��
        animator.SetBool("IsGround", isGround);
        animator.SetBool("DoubleJump", false);

        // Gorund�� �����鼭 JumpCount �ʱ�ȭ
        isGround = true;
        jumpCount = 0;
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
}


