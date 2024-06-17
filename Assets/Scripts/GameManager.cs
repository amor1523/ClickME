using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject[] rewards;
    public GameObject currentBox;

    void Start()
    {
        SpawnNewBox();
    }

    void SpawnNewBox()
    {
        float xPosition = Random.Range(-5.0f, 5.0f);
        currentBox = Instantiate(boxPrefab, new Vector3(xPosition, 1, 0), Quaternion.identity);
    }

    public void OnBoxDestroyed()
    {
        // 보상 아이템 생성 로직
       
        SpawnNewBox();
    }
}
