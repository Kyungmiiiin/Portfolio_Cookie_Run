using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MagnetItem : Item
{
    [SerializeField] float magnetForce;  // 자력
    [SerializeField] float magnetRadius; // 자력 범위
    [SerializeField] float activationDuration = 2f; // 자석 아이템 활성화 기간

    [SerializeField] SpriteRenderer sprite;

    private void Update()
    {
        Move();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {    
        // 플레이어와 충돌했을 때
        if (collision.CompareTag("Player"))
        {
            // 자석 효과는 유지하지만 sprite만 보이지 않게 
            sprite.enabled = false;

            StartCoroutine(ActivateMagnetForDuration());
        }
    }

    // 일정 시간 동안 자석 아이템 활성화
    private IEnumerator ActivateMagnetForDuration()
    {
        float time = 0;

        while(time <= activationDuration)
        {
            // 자석 아이템이 활성화된 경우 범위 안에 collider가 있는 코인과 젤리를 끌어당김
            Collider2D[] colliders = Physics2D.OverlapCircleAll(player.transform.position, magnetRadius);
            foreach (Collider2D collider in colliders)
            {
                // Point태그를 가지고 있는 collider
                if (collider.CompareTag("Point"))
                {        
                    // 방향계산 후
                    Vector3 direction = (player.transform.position - collider.transform.position).normalized;
                    // 코인과 젤리를 자석 힘과 시간에 따라 플레이어 쪽으로 이동
                    collider.transform.position += direction * magnetForce * Time.deltaTime;
                    
                }
            }
            time += Time.deltaTime;
            yield return null;
        }
        Release();
    }
}

