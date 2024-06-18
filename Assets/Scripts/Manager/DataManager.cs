using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public RewardManager rewardManager;
    string savePath; // 저장경로

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        rewardManager = GetComponent<RewardManager>();
        savePath = Application.persistentDataPath; // 유니티에서 적당한 경로를 찾아준다.
    }

    public void SaveData(string json) // 저장할 매개변수 string
    {
        File.WriteAllText(savePath + "/FruitData.txt", json); // WriteAllText(경로, 데이터)
        Debug.Log("저장 완료 : " + savePath + "/FruitData.txt"); // 저장경로 디버그
    }

    public FruitsData LoadData()
    {
        string jsonData = File.ReadAllText(savePath + "/FruitData.txt");
        return JsonUtility.FromJson<FruitsData>(jsonData);
    }
}
