using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestartButton : MonoBehaviour
{
    public void Restart(string restartSceneName)
    {
        SceneManager.LoadScene(restartSceneName);
        return;
    }
}
