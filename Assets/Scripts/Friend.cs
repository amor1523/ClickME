using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public int autoClickDamage = 10;
    public float autoClickInterval = 2.0f;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(AutoClickRoutine());
    }

    IEnumerator AutoClickRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoClickInterval);
            if (gameManager.currentBox != null)
            {
                gameManager.currentBox.GetComponent<Box>().TakeDamage(autoClickDamage);
            }
        }
    }
}
