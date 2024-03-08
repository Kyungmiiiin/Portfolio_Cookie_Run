using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour    
{

    [SerializeField] float moveSpeed;        // ����� �����̴� �ӵ�
    [SerializeField] Vector3 moveDirection;  // ����� �̵��ϴ� ��ġ�� ���� �ٸ��� ������ ���� ����

    private void Update()
    {
        // ����� ������ �������� moveSpeed�� �ӵ��� �̵�
        transform.position += moveDirection * moveSpeed *Time.deltaTime; 
    }
}
