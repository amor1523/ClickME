using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public float autoClickInterval = 5.0f;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(AutoClickRoutine());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            HandleClick();
        }
    }

    void HandleClick()
    {
        if (gameManager.currentBox != null)
        {
            gameManager.currentBox.GetComponent<Box>().TakeDamage(10); // 클릭 시 1의 데미지를 줌 수정!
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
                gameManager.currentBox.GetComponent<Box>().TakeDamage(10); // 오토 클릭 시 1의 데미지를 줌 수정!
            }
        }
    }
}
