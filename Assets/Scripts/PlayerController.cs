using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Animator animator;

    [Header("Space")]
    [SerializeField] float jumpSpeed;
    [SerializeField] float moveSpeed;

    // [Header("Events")]
    //public UnityEvent OnDied;
    private void Jump()
    {
        rigid.velocity = Vector2.up * jumpSpeed;
    }

    private void OnJump(InputValue value)
    {
        if(value.isPressed)
        {
            Jump();
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        // 설정한 Bool(변수명, 값)을 넣음
        // ISGround가 true일때 Enter가 됨
        animator.SetBool("IsGround", true);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        // ISGround가 false일때 Exit가 됨
        animator.SetBool("IsGround", false);
    }
}


