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

    private void Update()
    {
        if (currentHealth <= 0)
        {
            DestroyBox();
        }
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
