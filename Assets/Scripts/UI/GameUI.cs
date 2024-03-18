using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Image hpBar;
    [SerializeField] PlayerController playerController;
    [SerializeField] TextMeshProUGUI cointext;
    [SerializeField] TextMeshProUGUI jellytext;

    private void Update()
    {
        UpdateHpBar();
        UpdateCoinText();
        UpdateJellyText();
    }

    private void UpdateHpBar()
    {
        // 현재 체력을 나타내줌
        hpBar.fillAmount = playerController.hp / playerController.MaxHp;
    }

    private void UpdateCoinText()
    {
        // 점수를 text로 나타내줌
        cointext.text = playerController.coinScore.ToString();
    }
    private void UpdateJellyText()
    {
        jellytext.text = playerController.jellyScore.ToString();
    }
}
