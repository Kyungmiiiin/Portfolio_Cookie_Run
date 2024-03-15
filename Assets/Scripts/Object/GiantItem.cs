using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GiantItem : Item
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        
        player.StartCoroutine(Biggest(data.extraSize.x , 2));
        base.OnTriggerEnter2D(collision);
    }

    IEnumerator Biggest(float size, float wantTime)
    {
        float one = 1;
        while(player.transform.localScale.x >= size)
        {
            // 2�ʰ� ����
            one += size * (Time.deltaTime / wantTime);
                                      // (1, 1, 1)                                       
            player.transform.localScale = Vector3.one * one;
            yield return new WaitForFixedUpdate();
        }
        player.transform.localScale = Vector3.one * size;

        yield return new WaitForSeconds(5);

        yield return Smallest();
    }

    IEnumerator Smallest()
    {
        // �۾����� ����
        player.transform.localScale = Vector3.one;
        yield return null;
    }
}
