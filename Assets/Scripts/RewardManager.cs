using TMPro;
using UnityEngine;
using System.Numerics; // BigInteger 사용하기 위한 네임스페이스 추가
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class RewardManager : MonoBehaviour
{
    public TextMeshProUGUI appleScoreText;
    public TextMeshProUGUI bananaScoreText;
    public TextMeshProUGUI cherryScoreText;
    private BigInteger appleScore = new BigInteger(1000); // BigInteger 기능을 확인하고 싶다면 1000 넣기!
    private BigInteger bananaScore = new BigInteger(1000); // BigInteger 기능을 확인하고 싶다면 1000000 넣기!
    private BigInteger cherryScore = new BigInteger(1000); // BigInteger 기능을 확인하고 싶다면 1000000000 넣기!

    public GameObject rewardPrefab; // 프리팹 참조
    public Transform uiCanvas; // UI 캔버스 참조
    public Sprite appleSprite;
    public Sprite bananaSprite;
    public Sprite cherrySprite;

    private void Start()
    {
        UpdateUI();
    }

    public void AddRandomReward(int rewardType, BigInteger amount, Vector3 position)
    {
        switch (rewardType)
        {
            case 0:
                appleScore += amount;
                ShowRewardUI(position, "+" + amount.ToReadableString(), appleSprite);
                break;
            case 1:
                bananaScore += amount;
                ShowRewardUI(position, "+" + amount.ToReadableString(), bananaSprite);
                break;
            case 2:
                cherryScore += amount;
                ShowRewardUI(position, "+" + amount.ToReadableString(), cherrySprite);
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

    public void ShowRewardUI(Vector3 position, string text, Sprite sprite)
    {
        GameObject rewardUI = Instantiate(rewardPrefab, uiCanvas);
        rewardUI.transform.position = Camera.main.WorldToScreenPoint(position);
        rewardUI.GetComponentInChildren<TextMeshProUGUI>().text = text;
        rewardUI.GetComponentInChildren<Image>().sprite = sprite;
        Destroy(rewardUI, 0.5f); // 0.5초 후 UI 제거
    }
}
