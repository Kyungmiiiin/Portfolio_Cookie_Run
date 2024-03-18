using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }

    public void LoadingSceneLoad()
    {
        Manager.Scene.LoadScene("LoadingScene");
    }
}
