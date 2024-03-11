using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

[CreateAssetMenu(fileName = "JellyData", menuName = "Data/Jelly")]
public class JellyData : ScriptableObject
{
    public int jellyType;
    // 젤리가 가질 수 있을만한 데이터를 입력
    public Sprite icon;
    public string point;
}

