using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : BaseScene
{
    public override IEnumerator LoadingRoutine()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        GameSceneLoad();
    }

    public void GameSceneLoad()
    {
        Manager.Scene.LoadScene("GameScene");
    }
}
