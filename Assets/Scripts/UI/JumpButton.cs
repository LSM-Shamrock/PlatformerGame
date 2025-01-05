using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    [SerializeField] 
    private Direction buttonDirection;
    private Color defaultColor = new Color(1f, 1f, 1f, 0.2f);
    private Color pressedColor = new Color(0.5f, 0.5f, 0.5f, 0.4f);
    private Image image;
    private PlayerJumpController playerJumpController;

    private void Start()
    {
        image = GetComponent<Image>();
        playerJumpController = GameManager.Instance.player.GetComponent<PlayerJumpController>();

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
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                ButtonDown();
            if (Input.GetKeyUp(KeyCode.LeftArrow))
                ButtonUp();
        }
        if (buttonDirection == Direction.Right)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
                ButtonDown();
            if (Input.GetKeyUp(KeyCode.RightArrow))
                ButtonUp();
        }
    }

    public void ButtonDown()
    {
        image.color = pressedColor;
        playerJumpController.JumpButtonDown(buttonDirection);
    }

    public void ButtonUp()
    {
        image.color = defaultColor;
        playerJumpController.JumpButtonUp();
    }
}