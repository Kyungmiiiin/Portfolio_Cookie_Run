using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigHpItem : Item
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        player.hp += data.extraHp;

        if (player.hp >= player.MaxHp)
        {
            player.hp = player.MaxHp;
        }
    }
}
