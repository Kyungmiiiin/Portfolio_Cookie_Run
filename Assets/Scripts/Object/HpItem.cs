using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;

public class HpItem : Item
{
    [SerializeField] Image itemUIImage;
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        player.hp += data.extraHp;

        if (player.hp >= player.MaxHp)
        {
            player.hp = player.MaxHp;
        }

        //GameObject itemUIGameObject = GameObject.FindWithTag("HpUI");

        //if (itemUIGameObject != null)
        //{
        //    itemUIImage.enabled = true;

        //    // 찾은 GameObject에 연결된 Image 컴포넌트를 가져옴
        //    itemUIImage = itemUIGameObject.GetComponent<Image>();

        //    if (itemUIImage == null)
        //    {
        //        Debug.LogError("ItemUI GameObject에 Image 컴포넌트가 없습니다.");
        //    }
        //}
        //else
        //{
        //    Debug.LogError("ItemUI GameObject를 찾을 수 없습니다.");
        //}

        //if (itemUIImage != null)
        //{
        //    // 아이템을 먹은 후 UI 이미지를 숨김
        //    itemUIImage.enabled = false;
        //}
    }

}

