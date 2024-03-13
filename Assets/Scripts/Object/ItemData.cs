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
    // BoosterItem을 먹었을때
    public int extraSpeed;

    // HpItem을 먹었을때
    public int extraHp;

    // GiantItem을 먹었을때
    public Vector3 extraSize;
}
