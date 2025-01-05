using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
