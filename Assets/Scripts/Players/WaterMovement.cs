using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WaterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravity;

    private Vector2 _direction;
    private Vector2 _velocity;
    private Vector2 _normal;
    private List<RaycastHit2D> _raycast;
    private Rigidbody2D _rb;
    private bool _isGrounded;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _raycast = new List<RaycastHit2D>();
    }

    private void Update()
    {
        _direction.x += Input.GetAxisRaw("Horizontal") * _speed;
    }

    private void FixedUpdate()
    {
        _isGrounded = false;
        _raycast.Clear();
        _direction += Physics2D.gravity * _gravity * Time.deltaTime;
        _direction.x *= Time.deltaTime;

        _rb.Cast(_direction, _raycast, _direction.magnitude);

        if (_raycast.Count > 0)
        {
            for (int i = 0; i < _raycast.Count; i++)
            {
                if (_raycast[i].collider.gameObject.GetComponent<Ground>())
                {
                    _normal = _raycast[i].normal;
                    _isGrounded = true;
                }
            } 
        }
        else
        {
            _normal = Vector2.zero;
        }

        _direction = _direction - (Vector2.Dot(_direction, _normal) * _normal);

        _rb.position += _direction;
        _direction = Vector2.zero;
    }
}
