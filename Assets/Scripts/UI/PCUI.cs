using UnityEngine;

public class PCUI : MonoBehaviour
{
    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer)
        {
            gameObject.SetActive(false);
        }
    }
}
