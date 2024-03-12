using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

[CreateAssetMenu(fileName = "JellyData", menuName = "Data/Jelly")]
public class JellyData : ScriptableObject
{
    // ������ ���� �� �������� �����͸� �Է�
    public int jellyType;
    public Sprite icon;
    public int point;
}

