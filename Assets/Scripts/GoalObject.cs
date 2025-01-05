using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalObject : MonoBehaviour
{
    [SerializeField] private string nextSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            SceneManager.LoadScene(nextSceneName);
    }
}
