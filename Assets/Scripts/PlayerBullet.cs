using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BossHealthController boss = collision.GetComponent<BossHealthController>();
        if (boss != null)
        {
            boss.Hit(1);
            Invoke("BulletDestroy", 0.1f);
        }
    }

    public void ShootStart(Vector3 shootDirection, float shootSpeed, float shootDistance)
    {
        rb.linearVelocity = shootDirection * shootSpeed;
        Invoke("BulletDestroy", shootDistance / shootSpeed);
    }

    public void BulletDestroy()
    {
        gameObject.SetActive(false);
    }
}
