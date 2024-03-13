using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    public AnimatorController controller;

    public int ItemType;
    // BoosterItem�� �Ծ�����
    public int extraSpeed;

    // HpItem�� �Ծ�����
    public int extraHp;

    // GiantItem�� �Ծ�����
    public Vector3 extraSize;
}
