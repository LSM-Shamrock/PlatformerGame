using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightLaunchButton : MonoBehaviour
{
    [SerializeField]
    Direction buttonDirection;
    private Color defaultColor = new Color(1f, 1f, 1f, 0.2f);
    private Color pressedColor = new Color(0.5f, 0.5f, 0.5f, 0.4f);
    private Image image;
    private PlayerLauncher playerLauncher;

    private void Start()
    {
        image = GetComponent<Image>();
        playerLauncher = GameManager.Instance.player.GetComponent<PlayerLauncher>();

        image.color = defaultColor;

        EventTrigger eventTrigger = GetComponent<EventTrigger>();

        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
        pointerDownEntry.eventID = EventTriggerType.PointerDown;
        pointerDownEntry.callback.AddListener((data) => { ButtonDown(); });
        eventTrigger.triggers.Add(pointerDownEntry);

        EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
        pointerUpEntry.eventID = EventTriggerType.PointerUp;
        pointerUpEntry.callback.AddListener((data) => { ButtonUp(); });
        eventTrigger.triggers.Add(pointerUpEntry);
    }

    private void Update()
    {
        if (buttonDirection == Direction.Left)
        {
            if (Input.GetKeyDown(KeyCode.D))
                ButtonDown();
            if (Input.GetKeyUp(KeyCode.D))
                ButtonUp();
        }
        if (buttonDirection == Direction.Right)
        {
            if (Input.GetKeyDown(KeyCode.F))
                ButtonDown();
            if (Input.GetKeyUp(KeyCode.F))
                ButtonUp();
        }
    }

    private void ButtonDown()
    {
        image.color = pressedColor;
        playerLauncher.LaunchButtonDown(buttonDirection);
    }

    private void ButtonUp()
    {
        image.color = defaultColor;
        playerLauncher.LaunchButtonUp();
    }
}