using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direction
{
    Left,
    Right,
}

public class PlayerJumpController : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float jumpPower = 20f;
    private float fullJumpChargeTime = 0.5f;

    private float currentJumpChargeTime = 0f;
    private bool jumpButtonPressed = false;
    private Direction direction = Direction.Right;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private LayerMask groundLayer;

    [HideInInspector] 
    public Transform jumpGauge;
    [HideInInspector] 
    public Transform jumpGaugeFill;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        groundLayer = GameManager.Instance.groundLayer;
    }

    private void Update()
    {
        if (jumpButtonPressed)
        {
            jumpGauge.gameObject.SetActive(true);
            if (direction == Direction.Right)
            {
                jumpGauge.position = transform.position + Vector3.right;
                spriteRenderer.flipX = true;
            }
            else
            {
                jumpGauge.position = transform.position + Vector3.left;
                spriteRenderer.flipX = false;
            }    
            jumpGaugeFill.localScale = new Vector3(1, currentJumpChargeTime / fullJumpChargeTime, 1);
            currentJumpChargeTime += Time.deltaTime;
            if (currentJumpChargeTime > fullJumpChargeTime)
                currentJumpChargeTime = fullJumpChargeTime;
        }
        else
        {
            jumpGauge.gameObject.SetActive(false);
            currentJumpChargeTime = 0;
        }
    }

    private void LateUpdate()
    {
        rigidBody.linearVelocityX = 0f;
        bool isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, groundLayer);
        if (!isGrounded)
        {
            if (direction == Direction.Right)
                rigidBody.linearVelocityX = moveSpeed;
            else
                rigidBody.linearVelocityX = -moveSpeed;
        }
    }

    public void JumpButtonDown(Direction buttonDirection)
    {
        bool isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, groundLayer);
        if (isGrounded)
        {
            direction = buttonDirection;
            jumpButtonPressed = true;
        }
    }

    public void JumpButtonUp()
    {
        bool isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, groundLayer);
        if (isGrounded)
        {
            jumpButtonPressed = false;
            rigidBody.linearVelocityY = jumpPower * currentJumpChargeTime / fullJumpChargeTime;
        }
    }
}
