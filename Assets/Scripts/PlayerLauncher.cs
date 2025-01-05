using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    private float shootSpeed = 20f;
    private float shootDistance = 10f;
    private Vector3 shootDirection = Vector3.right;

    private float launchCoolTime = 0.2f;
    private float launchCoolDown = 0f;

    private BoxCollider2D box;

    private bool launchButtonPressed = false;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (launchCoolDown > 0)
            launchCoolDown -= Time.deltaTime;
        else
        {
            launchCoolDown = 0;
            if (launchButtonPressed)
                Launch();
        }
    }

    private void Launch()
    {
        PlayerBullet bullet = PoolManager.instance.Get(bulletPrefab, transform.position).GetComponent<PlayerBullet>();
        bullet.gameObject.transform.Translate(Vector3.up * box.size.y / 2);
        bullet.ShootStart(shootDirection, shootSpeed, shootDistance);

        launchCoolDown = launchCoolTime;
    }

    public void LaunchButtonDown(Direction buttonDirection)
    {
        if (buttonDirection == Direction.Left)
        {
            shootDirection = Vector3.left;
        }
        if (buttonDirection == Direction.Right)
        {
            shootDirection = Vector3.right;
        }
        launchButtonPressed = true;
    }

    public void LaunchButtonUp()
    {
        launchButtonPressed = false;
    }
}
