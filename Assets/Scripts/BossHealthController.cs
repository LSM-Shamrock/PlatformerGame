using System;
using System.Collections;
using UnityEngine;

public class BossHealthController : MonoBehaviour
{
    [SerializeField]
    private BossBar bossBar;

    [HideInInspector] 
    public int maxHP = 10;
    [HideInInspector] 
    public int remainHP;

    private int saveHP;
    private PlayerRespawnController player;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        remainHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameManager.Instance.player.GetComponent<PlayerRespawnController>();
        player.saveActions.Add(() => { saveHP = remainHP; });
        player.deadActions.Add(() => { remainHP = saveHP;  bossBar.Set((float)remainHP / maxHP); gameObject.SetActive(remainHP > 0); });
    }

    public void Hit(int damage)
    {
        remainHP -= damage;
        bossBar.Set((float)remainHP / maxHP);
        if (remainHP <= 0)
        {
            bossBar.Set(0f);
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(HitEffect(0.5f));
        }
    }

    private IEnumerator HitEffect(float value)
    {
        while (value > 0)
        {
            spriteRenderer.color = new Color(1f, 1f - value, 1f - value);
            yield return null;
            value -= 2 * Time.deltaTime;
        }
    }
}
