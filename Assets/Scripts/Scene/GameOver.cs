using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
// using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameOver : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TextMeshProUGUI cointext;
    [SerializeField] TextMeshProUGUI jellytext;
   
    private void Update()
    {
        UpdateCoinText();
        UpdateJellyText();
    }

    private void UpdateCoinText()
    {
        // ������ text�� ��Ÿ����
        cointext.text = playerController.coinScore.ToString();
    }
    private void UpdateJellyText()
    {
        jellytext.text = playerController.jellyScore.ToString();
    }
}
