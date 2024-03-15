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
        Debug.Log("3��");
        yield return new WaitForSecondsRealtime(2f);
        Debug.Log("2��");
        
        Time.timeScale = 1f;
        Debug.Log("1��");
    }
}
