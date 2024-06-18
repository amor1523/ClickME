using System.Collections;
using System.Collections.Generic;
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
        File.WriteAllText(savePath + "/FruitData.txt", json); // WriteAllText(���, ������)
        Debug.Log("���� �Ϸ� : " + savePath + "/FruitData.txt"); // ������ �����
    }

    public FruitsData LoadData()
    {
        string jsonData = File.ReadAllText(savePath + "/FruitData.txt");
        return JsonUtility.FromJson<FruitsData>(jsonData);
    }
}
