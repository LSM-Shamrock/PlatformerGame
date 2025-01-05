using UnityEngine;

public class SlimeController : MonoBehaviour
{
    private int move = -1;
    private float moveSpeed = 1f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void LateUpdate()
    {
        LayerMask groundLayer = GameManager.Instance.groundLayer;
        RaycastHit2D downCheck = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);
        if (downCheck.collider != null)
        {
            Vector3 front = transform.position;
            front.x += move * boxCollider.size.x / 2;
            RaycastHit2D frontCheck = Physics2D.Raycast(front, Vector3.right * move, 0.1f, groundLayer);
            RaycastHit2D frontDownCheck = Physics2D.Raycast(front, Vector3.down, 0.1f, groundLayer);

            if (frontCheck.collider != null || frontDownCheck.collider == null)
                move *= -1;
        }

        rb.linearVelocityX = move * moveSpeed;

        if (move > 0)
            sr.flipX = true;
        if (move < 0)
            sr.flipX = false;
    }
}
