using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MagnetItem : Item
{
    [SerializeField] float magnetForce;  // �ڷ�
    [SerializeField] float magnetRadius; // �ڷ� ����
    [SerializeField] float activationDuration = 2f; // �ڼ� ������ Ȱ��ȭ �Ⱓ

    [SerializeField] SpriteRenderer sprite;

    private void Update()
    {
        Move();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {    
        // �÷��̾�� �浹���� ��
        if (collision.CompareTag("Player"))
        {
            // �ڼ� ȿ���� ���������� sprite�� ������ �ʰ� 
            sprite.enabled = false;

            StartCoroutine(ActivateMagnetForDuration());
        }
    }

    // ���� �ð� ���� �ڼ� ������ Ȱ��ȭ
    private IEnumerator ActivateMagnetForDuration()
    {
        float time = 0;

        while(time <= activationDuration)
        {
            // �ڼ� �������� Ȱ��ȭ�� ��� ���� �ȿ� collider�� �ִ� ���ΰ� ������ ������
            Collider2D[] colliders = Physics2D.OverlapCircleAll(player.transform.position, magnetRadius);
            foreach (Collider2D collider in colliders)
            {
                // Point�±׸� ������ �ִ� collider
                if (collider.CompareTag("Point"))
                {        
                    // ������ ��
                    Vector3 direction = (player.transform.position - collider.transform.position).normalized;
                    // ���ΰ� ������ �ڼ� ���� �ð��� ���� �÷��̾� ������ �̵�
                    collider.transform.position += direction * magnetForce * Time.deltaTime;
                    
                }
            }
            time += Time.deltaTime;
            yield return null;
        }
        Release();
    }
}

