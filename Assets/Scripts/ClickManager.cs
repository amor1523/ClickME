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
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            HandleClick();
        }
    }

    void HandleClick()
    {
        if (gameManager.currentBox != null)
        {
            gameManager.currentBox.GetComponent<Box>().TakeDamage(10); // Ŭ�� �� 1�� �������� �� ����!
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
                gameManager.currentBox.GetComponent<Box>().TakeDamage(10); // ���� Ŭ�� �� 1�� �������� �� ����!
            }
        }
    }
}
