using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameScene : BaseScene
{
    [SerializeField] bool isPause;
    [SerializeField] GameObject gameOverUI;
   
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        // 비활성화 해둔 GameOverUI를 활성화 시킴
        gameOverUI.SetActive(true);
     
        EventSystem eventSystem = gameOverUI.GetComponent<EventSystem>();
        if (eventSystem != null)
        {
            eventSystem.enabled = true;
        }
    }

    public void TitleSceneLoad()
    {
        Manager.Scene.LoadScene("TitleScene");
    }

    public override IEnumerator LoadingRoutine()
    {
        yield return new WaitForSecondsRealtime(0.1f);
    }
  
}
