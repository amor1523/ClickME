using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private GameManager gameManager;

    void Start()
    {
        currentHealth = maxHealth;
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            DestroyBox();
        }
    }

    void DestroyBox()
    {
        gameManager.OnBoxDestroyed();
        Destroy(gameObject);
    }
}
