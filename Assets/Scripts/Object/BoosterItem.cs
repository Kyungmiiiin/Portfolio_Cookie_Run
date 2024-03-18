using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterItem : Item
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        player.StartCoroutine(booster());
        base.OnTriggerEnter2D(collision);
    }

    IEnumerator booster() 
    {
        // 2�ʰ� ����ǰ� ������ ���ư�
        Time.timeScale = 3f;

        yield return new WaitForSecondsRealtime(1.5f);
        
        Time.timeScale = 1f;

    }
}
