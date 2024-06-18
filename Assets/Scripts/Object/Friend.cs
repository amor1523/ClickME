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
        // 현재 위치에서 목표 위치로 이동
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetX, transform.position.y), speed * Time.deltaTime);

        // 목표 위치에 도달했는지 확인
        if (Mathf.Abs(transform.position.x - targetX) < 0.1f)
        {
            SetNewTarget();
        }

        // 방향을 확인하고, 필요한 경우 플립
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
        // 새로운 목표 지점을 랜덤하게 설정
        targetX = Random.Range(leftBoundary, rightBoundary);
    }

    void Flip()
    {
        // 방향을 바꾸기 위해 플립
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
