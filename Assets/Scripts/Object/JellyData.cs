using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

[CreateAssetMenu(fileName = "JellyData", menuName = "Data/Jelly")]
public class JellyData : ScriptableObject
{
    public int jellyType;
    // ������ ���� �� �������� �����͸� �Է�
    public Sprite icon;
    public string point;
}

