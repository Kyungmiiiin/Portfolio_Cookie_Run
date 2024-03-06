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
        // ������ Bool(������, ��)�� ����
        // ISGround�� true�϶� Enter�� ��
        animator.SetBool("IsGround", true);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        // ISGround�� false�϶� Exit�� ��
        animator.SetBool("IsGround", false);
    }
}


