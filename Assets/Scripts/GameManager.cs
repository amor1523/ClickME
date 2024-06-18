using System.Numerics; // BigInteger 사용하기 위한 네임스페이스 추가
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject currentBox;
    private RewardManager rewardManager;

    public GameObject friendPrefab1;
    public GameObject friendPrefab2;
    public GameObject friendPrefab3;

    private BigInteger baseRewardAmount = new BigInteger(10); // 과일 기본 획득량

    void Start()
    {
        rewardManager = FindObjectOfType<RewardManager>();
        SpawnNewBox();
    }

    void SpawnNewBox()
    {
        float xPosition = Random.Range(-5.0f, 5.0f);
        currentBox = Instantiate(boxPrefab, new Vector3(xPosition, 1, 0), UnityEngine.Quaternion.identity);
    }

    public void OnBoxDestroyed()
    {
        Vector3 boxPosition = currentBox.transform.position;
        currentBox = null;
        int randomReward = Random.Range(0, 3); // 0, 1, 2 중 하나의 값을 랜덤으로 선택
        rewardManager.AddRandomReward(randomReward, baseRewardAmount, boxPosition); // 선택된보상 추가
        SpawnNewBox();
    }

    public void IncreaseBaseRewardAmount(int amount)
    {
        baseRewardAmount += amount;
    }

    public void SpawnFriend(int friendType)
    {
        GameObject friendPrefab = null;
        switch (friendType)
        {
            case 1:
                friendPrefab = friendPrefab1;
                break;
            case 2:
                friendPrefab = friendPrefab2;
                break;
            case 3:
                friendPrefab = friendPrefab3;
                break;
        }

        if (friendPrefab != null)
        {
            GameObject friend = Instantiate(friendPrefab, new Vector3(Random.Range(-5.0f, 5.0f), -1.5f, 0), Quaternion.identity);
            Debug.Log("Friend spawned: " + friend.name);
        }
        else
        {
            Debug.LogError("Friend prefab is null for type: " + friendType);
        }
    }
}
