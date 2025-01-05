using UnityEngine;

public class JumpGauge : MonoBehaviour
{
    [SerializeField] private Transform fill;

    private PlayerJumpController playerJumpController;

    private void Start()
    {
        playerJumpController = GameManager.Instance.player.GetComponent<PlayerJumpController>();
        playerJumpController.jumpGauge = transform;
        playerJumpController.jumpGaugeFill = fill;
    }
}
