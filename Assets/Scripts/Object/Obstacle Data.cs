using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ObstacleData", menuName = "Data/Obstacle")]

public class ObstacleData : ScriptableObject
{
    public int  ObstacleType;
    // ��ֹ��� �������� ������
    public Sprite icon;
    public int dmg;
}
