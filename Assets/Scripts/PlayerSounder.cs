using UnityEngine;

public class PlayerSounder : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] [Range(0, 1)] private float _volume;

    private AudioSource _audioSource;
    private Rigidbody2D _rb;
    private bool _isGround;
    private bool _isDown;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        if ( _audioSource == null)
            _audioSource = gameObject.AddComponent<AudioSource>();

        _rb = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        bool isDown = _rb.linearVelocityY < 0;

        if (_isDown != isDown)
        {
            _isDown = isDown;
            if (_isDown == false)
            {
                _audioSource.PlayOneShot(_audioClip, _volume);
            }
        }
    }
}
