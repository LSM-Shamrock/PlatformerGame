using UnityEngine;

public class RespawnObject : MonoBehaviour
{
    public Vector3 respawnPoint;

    public float respawnDelay = 1f;

    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        respawnPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead") ||
            collision.CompareTag("PlayerBullet"))
            Dead();
    }

    public void Dead()
    {
        RespawnManager.respawnObjects.Add(this);
    }
}
