using System.Collections;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public float autoClickInterval = 2.0f;
    private GameManager gameManager;
    private Coroutine autoClickCoroutine;

    public int clickDamage = 10; // �⺻ Ŭ�� ������

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
            gameManager.currentBox.GetComponent<Box>().TakeDamage(clickDamage); // Ŭ�� �� clickDamage��ŭ�� �������� ��
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

    public void IncreaseClickDamage(int amount)
    {
        clickDamage += amount;
    }
}
