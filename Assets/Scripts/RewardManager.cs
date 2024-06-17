using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public TextMeshProUGUI appleScoreText;
    public TextMeshProUGUI bananaScoreText;
    public TextMeshProUGUI cherryScoreText;
    private int appleScore = 0;
    private int bananaScore = 0;
    private int cherryScore = 0;

    public void AddRandomReward(int rewardType, int amount)
    {
        switch (rewardType)
        {
            case 0:
                appleScore += amount;
                break;
            case 1:
                bananaScore += amount;
                break;
            case 2:
                cherryScore += amount;
                break;
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        appleScoreText.text = appleScore.ToString();
        bananaScoreText.text = bananaScore.ToString();
        cherryScoreText.text = cherryScore.ToString();
    }

    //TODO:: 리워드발생 시 Box위치 위에 리워드 +
    //10 UI띄움
    //public void RewardsUI()
    //{
    //    GameObject go = Instantiate(plusTxt, plusTxt.transform.position, plusTxt.transform.rotation, UICanvus);
    //    Destroy(go, 0.5f);
    //}
}
