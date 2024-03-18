using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    public void Test()
    {
        Debug.Log(GetInstanceID());
    }
   
}
