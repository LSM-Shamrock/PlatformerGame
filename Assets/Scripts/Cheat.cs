using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SceneManager.LoadScene(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SceneManager.LoadScene(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SceneManager.LoadScene(2);

        if (Input.GetKeyDown(KeyCode.B))
            GameManager.Instance.player.transform.position = transform.position;
    }
}
