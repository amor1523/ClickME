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
    private int appleScore = 1000;
    private int bananaScore = 1000;
    private int cherryScore = 1000;

    private void Start()
    {
        UpdateUI();
    }

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

    public bool UseApples(int amount)
    {
        if (appleScore >= amount)
        {
            appleScore -= amount;
            UpdateUI();
            return true;
        }
        return false;
    }

    public bool UseBananas(int amount)
    {
        if (bananaScore >= amount)
        {
            bananaScore -= amount;
            UpdateUI();
            return true;
        }
        return false;
    }

    public bool UseCherries(int amount)
    {
        if (cherryScore >= amount)
        {
            cherryScore -= amount;
            UpdateUI();
            return true;
        }
        return false;
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
