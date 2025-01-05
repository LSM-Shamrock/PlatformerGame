using UnityEngine;

public class BossLauncher : MonoBehaviour
{
    [SerializeField] 
    private GameObject bulletPrefab;

    private float shootCooltime = 2f;
    private float shootCooldown = 0f;

    private float shootSpeed = 3f;
    private float shootDistance = 15f;
    private Vector3 shootDirection = Vector3.left;

    private void Update()
    {
        if (shootCooldown >  0)
        {
            shootCooldown -= Time.deltaTime;
        }
        else
        {
            Launch();
            shootCooldown = shootCooltime;
        }
    }

    private void Launch()
    {
        BossBullet bullet = PoolManager.instance.Get(bulletPrefab, transform.position).GetComponent<BossBullet>();
        bullet.gameObject.transform.Translate(Vector3.up * Random.Range(0, 5));
        bullet.ShootStart(shootDirection, shootSpeed, shootDistance);
    }
}
