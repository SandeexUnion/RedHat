using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float rotationSpeed = 10f;

    private WolfPatrol patrol;
    private Vector2 lastPosition;
    private float currentDirection;
    private Rigidbody2D rb;

    private void Awake()
    {
        patrol = GetComponent<WolfPatrol>();
        lastPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveTo(Vector2 targetPosition)
    {
        float direction = Mathf.Sign(targetPosition.x - transform.position.x);
        Vector2 velocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
        rb.linearVelocity = velocity;
        FlipSprite(direction);
    }

   

    private void FlipSprite(float direction)
    {
        if (direction == 0) return;

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(direction);
        transform.localScale = scale;
    }
}