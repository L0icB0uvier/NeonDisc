using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using Random = UnityEngine.Random;

public class DiscMovement : MonoBehaviour
{
    private Rigidbody2D m_rb2d;

    private Vector2 m_direction;
    [SerializeField] private int movementSpeed;
    const int m_speedFactor = 100;

    private void Awake()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        m_rb2d.AddForce(Random.insideUnitCircle.normalized * movementSpeed * m_speedFactor);
    }
}
