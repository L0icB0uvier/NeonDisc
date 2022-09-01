using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterController : MonoBehaviour
{
    private Rigidbody2D m_rb2d;
    private Collider2D m_collider;

    [SerializeField] private int movementSpeed;
    private Vector2 moveDir;
    
    private void Awake()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        m_rb2d.velocity = moveDir * movementSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>();
    }
}
