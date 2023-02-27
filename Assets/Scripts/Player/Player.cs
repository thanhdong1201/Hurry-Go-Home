using StarterAssets;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float _moveSpeed = 4.0f;
    [SerializeField] private float _jumpForce = 1.5f;
    [SerializeField] private float _gravity = -15.0f;
    [SerializeField] private float _jumpTimeoutDefault = 0.1f; 

    private float _jumpTimeout;
    private float _verticalVelocity;
    private float _terminalVelocity = 53.0f;
    private bool _alreadyGameOver;
    private Vector3 _moveDirection;

    [Header("Components")]
    [SerializeField] private SoundSO _soundSO;
    [SerializeField] private Animator _animator;
    private AudioSource _audioSource;
    private CharacterController _characterController;
    private StarterAssetsInputs _input;

    [Header("Camera")]
    public GameObject startCamera;
    public GameObject normalCamera;
    public GameObject gameOverCamera;
    public GameObject endCamera;
    private float timer = 1f;

    [Header("Events")]
    [SerializeField] private GameEvent _onGameOver;
    

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _characterController = GetComponent<CharacterController>();
        _input = GetComponent<StarterAssetsInputs>();
    }

    private void Start()
    {
        _jumpTimeout = _jumpTimeoutDefault;
        startCamera.SetActive(true);
        normalCamera.SetActive(false);
        gameOverCamera.SetActive(false);
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            startCamera.SetActive(false);
            normalCamera.SetActive(true);  
        }
        if (_input != null)
        {
            Move();
            Jump();
        }
    }
    private void Jump()
    {
        if (_characterController.isGrounded)
        {
            _animator.SetBool("Jump", false);

            // Time rest per jump
            if (_jumpTimeout > 0)
            {
                _jumpTimeout -= Time.deltaTime;
            }
            // Jump
            if (_input.jump && _jumpTimeout <= 0)
            {
                _audioSource.PlayOneShot(_soundSO.jump);
                _animator.SetBool("Jump", true);
                _verticalVelocity = Mathf.Sqrt(_jumpForce * -2f * _gravity);              
            }
            // Stop our velocity dropping infinitely when grounded
            if (_verticalVelocity < 0.0f)
            {
                _verticalVelocity = -2f;
            }        
        }
        if (!_characterController.isGrounded)
        {
            
            _jumpTimeout = _jumpTimeoutDefault;
            _input.jump = false;
        }

        // apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
        if (_verticalVelocity < _terminalVelocity)
        {
            _verticalVelocity += _gravity * Time.deltaTime;
        }
    }

    private void Move()
    {
        _moveDirection = new Vector3(_input.move.x, 0f, 1f).normalized;

        if (_input.move != Vector2.zero)
        {
            _moveDirection = transform.right * _input.move.x * 0.5f + transform.forward;
        }

        _characterController.Move(_moveDirection.normalized * _moveSpeed * Time.deltaTime + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
    }

    private void GameOver()
    {
        if (!_alreadyGameOver)
        {
            _alreadyGameOver = true;
            _audioSource.PlayOneShot(_soundSO.gameOver);          
            _onGameOver?.Invoke();
            _animator.SetTrigger("Dead");          
            gameOverCamera.SetActive(true);
            
            _input = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            _audioSource.PlayOneShot(_soundSO.collectCoin);
        }
        if (other.CompareTag("Item"))
        {
            _audioSource.PlayOneShot(_soundSO.collectItem);
        }
        if (other.CompareTag("Obstacle"))
        {
            GameOver();
        }
        if (other.CompareTag("EndGame"))
        {
            endCamera.SetActive(true);
        }
    }

}
