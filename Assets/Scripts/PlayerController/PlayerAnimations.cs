using PlayerController.States;
using UnityEngine;

namespace PlayerController
{
    public class PlayerAnimations : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private PlayerController _player;
        
        private Animator _animator;
        private int _xSpeedHash;
        private int _ySpeedHash;
        private int _isGroundedHash;
        private int _isSlidingHash;
        private int _isDashingHash;

        private void Awake()
        {
            _player = GetComponent<PlayerController>();
            _animator = GetComponent<Animator>();
            
            // set animations hashes
            _xSpeedHash = Animator.StringToHash("xSpeed");
            _ySpeedHash = Animator.StringToHash("ySpeed");
            _isGroundedHash = Animator.StringToHash("isGrounded");
            _isSlidingHash = Animator.StringToHash("isSliding");
            _isDashingHash = Animator.StringToHash("isDashing");
        }

        private void Update()
        {
            FlipSprite();
            
            GameManager.Instance.invulnerable = _player.CurrentState == PlayerStates.Dashing? true: false;

            if (_player.CanDash && _player.DashRequest)
                _animator.SetTrigger(_isDashingHash);
        }

        private void LateUpdate()
        {
            _animator.SetFloat(_xSpeedHash, Mathf.Abs(_player.Velocity.x));
            _animator.SetFloat(_ySpeedHash, _player.Velocity.y);
            _animator.SetBool(_isGroundedHash, _player.IsGrounded);
            _animator.SetBool(_isSlidingHash, _player.IsWallSliding);

            if ( _player.CurrentState != _player.LastState && _player.CurrentState == PlayerStates.Dashing) {
                Debug.Log(_player.CurrentState);
                _animator.SetBool(_isDashingHash, _player.CurrentState == PlayerStates.Dashing);
            }

            _player.LastState = _player.CurrentState;
        }
        
        private void FlipSprite()
        {
            if (!_spriteRenderer) return;
            if (_player.MovementDirection.x == 0) return;

            _spriteRenderer.flipX = !_player.IsFacingRight;
        }
    }
}
