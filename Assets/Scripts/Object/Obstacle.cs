using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] new SpriteRenderer renderer;
    [SerializeField] ObstacleData data;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 moveDirection;


    private void Awake()
    { 
        renderer.sprite = data.icon;
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
