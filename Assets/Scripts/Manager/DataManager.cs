using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public RewardManager rewardManager;
    string savePath; // ������

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        rewardManager = GetComponent<RewardManager>();
        savePath = Application.persistentDataPath; // ����Ƽ���� ������ ��θ� ã���ش�.
    }

    public void SaveData(string json) // ������ �Ű����� string
    {
        File.WriteAllText(savePath + "/FruitsData.txt", json); // WriteAllText(���, ������)
        Debug.Log("���� �Ϸ� : " + savePath + "/FruitsData.txt"); // ������ �����
    }

    public FruitsData LoadData()
    {
        //if (!File.Exists(savePath + "/FruitsData.txt")) return null; // ������ ���� ��� ����ó��

        string jsonData = File.ReadAllText(savePath + "/FruitsData.txt");
        return JsonUtility.FromJson<FruitsData>(jsonData);
    }
}
