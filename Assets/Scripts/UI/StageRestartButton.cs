using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageRestartButton : MonoBehaviour
{
    [SerializeField] 
    private Transform mark;

    private float requiredPressedTime = 1f;
    private float currentPressedTime = 0f;
    private bool isPressed;
    private Scene currentScene;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        currentScene = SceneManager.GetActiveScene();

        EventTrigger eventTrigger = GetComponent<EventTrigger>();

        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
        pointerDownEntry.eventID = EventTriggerType.PointerDown;
        pointerDownEntry.callback.AddListener((data) => { isPressed = true; });
        eventTrigger.triggers.Add(pointerDownEntry);

        EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
        pointerUpEntry.eventID = EventTriggerType.PointerUp;
        pointerUpEntry.callback.AddListener((data) => { isPressed = false; });
        eventTrigger.triggers.Add(pointerUpEntry);
    }

    private void Update()
    {
        if (isPressed || Input.GetKey(KeyCode.R))
        {
            currentPressedTime += Time.deltaTime;
            if (currentPressedTime >= requiredPressedTime)
                SceneManager.LoadScene(currentScene.name);

            float pressProgress = currentPressedTime / requiredPressedTime;
            mark.rotation = Quaternion.Euler(0, 0, pressProgress * -270);
            image.color = new Color(pressProgress, pressProgress, pressProgress, 0.2f + pressProgress * 0.8f);
        }
        else
        {
            currentPressedTime = 0f;

            mark.rotation = Quaternion.Euler(Vector3.zero);
            image.color = new Color(0f, 0f, 0f, 0.2f);
        }
    }
}
