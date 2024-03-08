using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour    
{

    [SerializeField] float moveSpeed;        // 배경이 움직이는 속도
    [SerializeField] Vector3 moveDirection;  // 배경이 이동하는 위치가 서로 다르기 때문에 변수 생성

    private void Update()
    {
        // 배경이 지정된 방향으로 moveSpeed의 속도로 이동
        transform.position += moveDirection * moveSpeed *Time.deltaTime; 
    }
}
