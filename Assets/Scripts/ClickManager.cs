using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public float autoClickInterval = 2.0f;
    private GameManager gameManager;
    private Coroutine autoClickCoroutine;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        autoClickCoroutine = StartCoroutine(AutoClickRoutine());
    }

    void Update()
    {
        if (Time.timeScale == 0f) return; // 게임 시간이 멈췄을 때 클릭을 무시합니다.

        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            HandleClick();
        }
    }

    void HandleClick()
    {
        if (gameManager.currentBox != null)
        {
            gameManager.currentBox.GetComponent<Box>().TakeDamage(10); // 클릭 시 10의 데미지를 줌
        }
    }

    IEnumerator AutoClickRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoClickInterval);
            if (gameManager.currentBox != null)
            {
                Debug.Log("오토클릭 발생!");
                gameManager.currentBox.GetComponent<Box>().TakeDamage(10);
            }
        }
    }
}
