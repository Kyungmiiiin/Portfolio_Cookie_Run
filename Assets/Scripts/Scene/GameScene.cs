using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameScene : BaseScene
{
    public override IEnumerator LoadingRoutine()
    {
        yield return new WaitForSecondsRealtime(0.1f);
    }
}
