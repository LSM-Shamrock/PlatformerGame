using UnityEngine;

public class BossBar : MonoBehaviour
{
    [SerializeField] 
    private Transform barFill;

    public void Set(float value)
    {
        if (value > 0f)
        {
            gameObject.SetActive(true);
            barFill.localScale = new Vector3(value, 1f, 1f);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
