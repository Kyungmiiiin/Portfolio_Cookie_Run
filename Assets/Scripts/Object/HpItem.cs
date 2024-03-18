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

        //    // ã�� GameObject�� ����� Image ������Ʈ�� ������
        //    itemUIImage = itemUIGameObject.GetComponent<Image>();

        //    if (itemUIImage == null)
        //    {
        //        Debug.LogError("ItemUI GameObject�� Image ������Ʈ�� �����ϴ�.");
        //    }
        //}
        //else
        //{
        //    Debug.LogError("ItemUI GameObject�� ã�� �� �����ϴ�.");
        //}

        //if (itemUIImage != null)
        //{
        //    // �������� ���� �� UI �̹����� ����
        //    itemUIImage.enabled = false;
        //}
    }

}

