using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : PooledObject
{
    [SerializeField] Animator animator;
    [SerializeField] ItemData data;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 moveDirection;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Release();
    }

    public void Move()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void Update()
    {
        Move();
    }
}

