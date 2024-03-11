using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "Data/Obstacle")]

public class ObstacleData : ScriptableObject
{
    public int  ObstacleType;
    // 장애물이 가질만한 데이터
    public Sprite icon;
    public int dmg;
}
