using System.Collections;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public int autoClickDamage = 50;
    public float autoClickInterval = 2.0f;
    private GameManager gameManager;

    public float speed = 5.0f;
    private float targetX;
    private float leftBoundary = -7.5f;
    private float rightBoundary = 7.5f;
    private Animator animator;
    private bool movingRight = true;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(AutoClickRoutine());
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // ���� ��ġ���� ��ǥ ��ġ�� �̵�
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetX, transform.position.y), speed * Time.deltaTime);

        // ��ǥ ��ġ�� �����ߴ��� Ȯ��
        if (Mathf.Abs(transform.position.x - targetX) < 0.1f)
        {
            SetNewTarget();
        }

        // ������ Ȯ���ϰ�, �ʿ��� ��� �ø�
        if (targetX > transform.position.x && !movingRight)
        {
            Flip();
        }
        else if (targetX < transform.position.x && movingRight)
        {
            Flip();
        }
    }

    void SetNewTarget()
    {
        // ���ο� ��ǥ ������ �����ϰ� ����
        targetX = Random.Range(leftBoundary, rightBoundary);
    }

    void Flip()
    {
        // ������ �ٲٱ� ���� �ø�
        movingRight = !movingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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
