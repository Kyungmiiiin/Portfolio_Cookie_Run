using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : PooledObject
{
    [SerializeField] Animator animator;
    [SerializeField] public ItemData data;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] public PlayerController player;

    private void Awake()
    {
        // Tag·Î Ã£±â
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
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

