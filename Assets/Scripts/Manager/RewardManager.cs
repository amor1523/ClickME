using TMPro;
using UnityEngine;
using System.Numerics; // BigInteger ����ϱ� ���� ���ӽ����̽� �߰�
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

// ������ ����
// [Serializable] �� class �Ǵ� struct ���� �����, �ȿ� ������ ������ �ִ´�.
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

    private BigInteger appleScore = new BigInteger(0); // BigInteger ����� Ȯ���ϰ� �ʹٸ� 1000 �ֱ�!
    private BigInteger bananaScore = new BigInteger(0); // BigInteger ����� Ȯ���ϰ� �ʹٸ� 1000000 �ֱ�!
    private BigInteger cherryScore = new BigInteger(0); // BigInteger ����� Ȯ���ϰ� �ʹٸ� 1000000000 �ֱ�!

    public GameObject rewardPrefab; // ������ ����
    public Transform uiCanvas; // UI ĵ���� ����
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
        Destroy(rewardUI, 0.5f); // 0.5�� �� UI ����
    }

    // ������ ��ü�� ����� ��ü �ȿ� ������ ������ ���� �ִ´�.
    public void SaveFruitData()
    {
        FruitsData fruitsData = new FruitsData(); // ������ ��ü ����
        fruitsData.appleScore_string = appleScore.ToReadableString(); ;
        fruitsData.bananaScore_string = bananaScore.ToReadableString(); ;
        fruitsData.cherryScore_string = cherryScore.ToReadableString(); ;

        string jsonData = JsonUtility.ToJson(fruitsData); // JsonUtility�� �̿��� fruitData�� ����ȭ ���־���.

        DataManager.Instance.SaveData(jsonData); // ������ string �����͸� DataManager�� �Ѱ��ش�.
    }

    public void LoadFruitData()
    {
        FruitsData fruitsData = DataManager.Instance.LoadData(); // DataManager���� LoadData ȣ��

        appleScore = new BigInteger(int.Parse(fruitsData.appleScore_string)); // �� ����
        bananaScore = new BigInteger(int.Parse(fruitsData.bananaScore_string));
        cherryScore = new BigInteger(int.Parse(fruitsData.cherryScore_string));

        UpdateUI(); // ������ �� Update

        // void Start ���� ȣ���ص� ������ �� ������Ʈ������ ��ư�� ���� Save, Load�� ����.
    }

    // ������ ������ �� ȣ��Ǵ� �Լ��� �̿��Ͽ� ����
    //private void OnApplicationQuit()
    //{
    //    SaveData();
    //}
}


