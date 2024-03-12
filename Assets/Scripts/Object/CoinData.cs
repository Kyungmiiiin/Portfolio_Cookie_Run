using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinData", menuName = "Data/Coin")]
public class CoinData : ScriptableObject
{
    public AnimatorController controller;
    //public Coin prefab;
    public int coin;
}
