using TMPro;
using UnityEngine;
using System.Numerics; // BigInteger 사용하기 위한 네임스페이스 추가
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

// 저장기능 구현
// [Serializable] 의 class 또는 struct 등을 만들고, 안에 저장할 정보를 넣는다.
[System.Serializable]
public struct FruitsData
{
    public string appleScore_string;
    public string bananaScore_string;
    public string cherryScore_string;
}

public class RewardManager : MonoBehaviour
{
    public FruitsData data;

    public TextMeshProUGUI appleScoreText;
    public TextMeshProUGUI bananaScoreText;
    public TextMeshProUGUI cherryScoreText;

    private BigInteger appleScore = new BigInteger(0); // BigInteger 기능을 확인하고 싶다면 1000 넣기!
    private BigInteger bananaScore = new BigInteger(0); // BigInteger 기능을 확인하고 싶다면 1000000 넣기!
    private BigInteger cherryScore = new BigInteger(0); // BigInteger 기능을 확인하고 싶다면 1000000000 넣기!

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

    // 저장할 객체를 만들고 객체 안에 저장할 정보의 값을 넣는다.
    public void SaveFruitData()
    {
        FruitsData fruitsData = new FruitsData(); // 저장할 객체 생성
        fruitsData.appleScore_string = appleScore.ToReadableString(); ;
        fruitsData.bananaScore_string = bananaScore.ToReadableString(); ;
        fruitsData.cherryScore_string = cherryScore.ToReadableString(); ;

        string jsonData = JsonUtility.ToJson(fruitsData); // JsonUtility를 이용해 fruitData를 직렬화 해주었다.

        DataManager.Instance.SaveData(jsonData); // 저장한 string 데이터를 DataManager로 넘겨준다.
    }

    public void LoadFruitData()
    {
        FruitsData fruitsData = DataManager.Instance.LoadData(); // DataManager에서 LoadData 호출

        appleScore = new BigInteger(int.Parse(fruitsData.appleScore_string)); // 값 대입
        bananaScore = new BigInteger(int.Parse(fruitsData.bananaScore_string));
        cherryScore = new BigInteger(int.Parse(fruitsData.cherryScore_string));

        UpdateUI(); // 대입한 값 Update

        // void Start 에서 호출해도 되지만 본 프로젝트에서는 버튼을 통해 Save, Load를 적용.
    }

    // 게임을 종료할 때 호출되는 함수를 이용하여 저장
    //private void OnApplicationQuit()
    //{
    //    SaveData();
    //}
}


