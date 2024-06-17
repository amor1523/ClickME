using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject currentBox;
    private RewardManager rewardManager;

    void Start()
    {
        rewardManager = FindObjectOfType<RewardManager>();
        SpawnNewBox();
    }

    void SpawnNewBox()
    {
        float xPosition = Random.Range(-5.0f, 5.0f);
        currentBox = Instantiate(boxPrefab, new Vector3(xPosition, 1, 0), Quaternion.identity);
    }

    public void OnBoxDestroyed()
    {
        int randomReward = Random.Range(0, 3); // 0, 1, 2 �� �ϳ��� ���� �������� ����
        rewardManager.AddRandomReward(randomReward, 10); // ���õ� ���� ���� 10�� �߰�
        SpawnNewBox();
    }
}
