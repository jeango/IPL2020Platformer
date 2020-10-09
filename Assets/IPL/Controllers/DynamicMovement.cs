using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DynamicMovement : Movement
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private bool flipped;
    [SerializeField] private Transform[] groundChecks;
    [SerializeField] private float maxGroundDistance = 0.1f;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float jumpSpeed = 6;
    
    private float _horizontal;
    private float _vertical;
    private bool _grounded;
    private RaycastHit2D[] groundHits = new RaycastHit2D[1];
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private bool _jumping;
    private int _jump;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void Move(float horizontal, float vertical)
    {
        _horizontal = horizontal;
        _vertical = vertical;
        if (horizontal > 0 && flipped || horizontal < 0 && !flipped)
            Flip();
    }

    public override void Jump()
    {
        _jump = CanJump() ? 1 : 0;
    }

    private bool CanJump()
    {
        if (!_jumping && _grounded)
        {
            _jumping = true;
            return true;
        }
        return false;
    }

    private void CheckGround()
    {
        _grounded = false;
        foreach (var check in groundChecks)
        {
            if (Physics2D.RaycastNonAlloc(check.position, Vector2.down, groundHits, maxGroundDistance, groundLayers) >
                0)
            {
                if (!_grounded)
                    _jumping = false;
                _grounded = true;
                break;
            }
        }
    }

    private void Flip(bool updateFlip = true)
    {
        flipped = updateFlip ? !flipped : flipped;
        var flipValue = flipped ? 180 : 0;
        _transform.localRotation = Quaternion.Euler(0, flipValue, 0);
    }

    private void FixedUpdate()
    {
        CheckGround();
        var velocity = _rigidbody.velocity;
        velocity.x = _horizontal * horizontalSpeed;
        if (_jump > 0)
        {
            velocity.y = jumpSpeed;
            _jump = 0;
        }
        _rigidbody.velocity = velocity;
    }

    private void OnValidate()
    {
        _transform = transform;
        Flip(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        foreach (var check in groundChecks)
        {
            var position = check.position;
            Gizmos.DrawLine(position, position + Vector3.down * maxGroundDistance);
        }
    }
}