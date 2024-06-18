using TMPro;
using UnityEngine;
using System.Numerics;
using Vector3 = UnityEngine.Vector3; // BigInteger를 사용하기 위해 추가

public class RewardManager : MonoBehaviour
{
    public TextMeshProUGUI appleScoreText;
    public TextMeshProUGUI bananaScoreText;
    public TextMeshProUGUI cherryScoreText;
    private BigInteger appleScore = new BigInteger(0); // BigInteger 기능을 확인하고 싶다면 1000 넣기!
    private BigInteger bananaScore = new BigInteger(0); // BigInteger 기능을 확인하고 싶다면 1000000 넣기!
    private BigInteger cherryScore = new BigInteger(0); // BigInteger 기능을 확인하고 싶다면 1000000000 넣기!

    public GameObject rewardPrefab; // 프리팹 참조
    public Transform uiCanvas; // UI 캔버스 참조

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
        appleScoreText.text = appleScore.ToReadableString();
        bananaScoreText.text = bananaScore.ToReadableString();
        cherryScoreText.text = cherryScore.ToReadableString();
    }

    public void ShowRewardUI(Vector3 position)
    {
        GameObject rewardUI = Instantiate(rewardPrefab, uiCanvas);
        rewardUI.transform.position = Camera.main.WorldToScreenPoint(position);
        Destroy(rewardUI, 0.5f); // 0.5초 후 UI 제거
    }
}
