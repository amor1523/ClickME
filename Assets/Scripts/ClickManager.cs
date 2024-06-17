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
        if (Time.timeScale == 0f) return; // ���� �ð��� ������ �� Ŭ���� �����մϴ�.

        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            HandleClick();
        }
    }

    void HandleClick()
    {
        if (gameManager.currentBox != null)
        {
            gameManager.currentBox.GetComponent<Box>().TakeDamage(10); // Ŭ�� �� 10�� �������� ��
        }
    }

    IEnumerator AutoClickRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoClickInterval);
            if (gameManager.currentBox != null)
            {
                Debug.Log("����Ŭ�� �߻�!");
                gameManager.currentBox.GetComponent<Box>().TakeDamage(10);
            }
        }
    }
}
