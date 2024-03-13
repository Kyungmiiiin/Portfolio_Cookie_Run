using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVData : MonoBehaviour
{
    public int JellyType;
    public int JellyYPos;
    public int JellyAmount;
    public int ObstacleType;
}

public class CSVDataList
{
    public List<CSVData> CSVList = new List<CSVData>();
}