using UnityEngine;

public class DeadTilemapUp : MonoBehaviour
{
    [SerializeField] 
    private float upSpeed = 1f;

    private PlayerRespawnController player;
    private Vector3 savePosition;

    private void Awake()
    {
        player = GameManager.Instance.player.GetComponent<PlayerRespawnController>();
        player.saveActions.Add(() => { savePosition = transform.position; });
        player.deadActions.Add(() => { transform.position = savePosition; });
    }

    private void Update()
    {
        transform.Translate(Vector3.up * upSpeed * Time.deltaTime);
    }
}
