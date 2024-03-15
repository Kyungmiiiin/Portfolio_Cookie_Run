using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PooledObject
{
    [SerializeField] Animator animator;
    [SerializeField] CoinData data;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 moveDirection;

    private void Awake()
    {  
        // Coin은 Animation으로 만들었기 때문에 renderer사용x
       animator.runtimeAnimatorController = data.controller;
    }

     
    public void OnTriggerEnter2D(Collider2D collision)
    {
        IScore player = collision.GetComponent<IScore>();
        player.GetScore(data.coin, false);
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
