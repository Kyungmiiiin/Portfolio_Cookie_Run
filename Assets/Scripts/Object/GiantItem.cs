using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GiantItem : Item
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        //Biggest 코루틴 실행
        player.StartCoroutine(Biggest(data.extraSize.x , 1.5f));
        base.OnTriggerEnter2D(collision);
    }

    IEnumerator Biggest(float size, float wantTime)
    {
        float one = 1;
        while(player.transform.localScale.x < size)
        {
            // 커지도록
            one += size * (Time.deltaTime / wantTime);
                                      // (1, 1, 1)                                       
            player.transform.localScale = Vector3.one * one;
            yield return new WaitForFixedUpdate();
        }
        player.transform.localScale = Vector3.one * size;

        // 2초간 실행
        yield return new WaitForSeconds(1.5f);

        // Smallest 코루틴 실행
        player.StartCoroutine(Smallest(size, wantTime));
    }

    IEnumerator Smallest(float size, float wantTime)
    {
        float currentSize = size;
        while (player.transform.localScale.x > 1)
        {
            // 작아지도록
            currentSize -= size * (Time.deltaTime / wantTime);
                                  
            player.transform.localScale = Vector3.one * currentSize;
            yield return new WaitForFixedUpdate();
        }
        
        // 초기 사이즈
        player.transform.localScale = Vector3.one;
    }
}
