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
        // jumpspeed만큼 up
        rigid.velocity = Vector2.up * jumpSpeed;

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
        rigid.velocity = Vector2.up * jumpSpeed;

        // DoubleJump를 실행했을때 jumpCount가 2로 바뀌면서 어떤 Jump도 실행하지않음
        jumpCount++;

        animator.SetBool("DoubleJump", true);
    }

    // Ground와 Player의 Collider가 서로 충돌 할 때 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // 설정한 Bool(변수명, 값)을 넣음
        // ISGround가 true일때 Enter가 됨
        animator.SetBool("IsGround", isGround);
        animator.SetBool("DoubleJump", false);

        // Gorund에 닿으면서 JumpCount 초기화
        isGround = true;
        jumpCount = 0;
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
            // Slide Animation이 끝나면 Collider의 size와 offset을 원래의 상태로 복구시킴
            float curYSize = collider.size.y;
            collider.size = new Vector2(collider.size.x, curYSize);
            float offset = collider.offset.y;
            collider.offset = new Vector2(collider.offset.x, offset);
        }
    }
}


