using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private float m_speedPlayer = 35f;

    public float SpeedPlayer { get { return m_speedPlayer; } set { m_speedPlayer = value; } }

    [SerializeField]
    private Rigidbody2D rigidbodyPlayer;

    // cached input used by FixedUpdate (physics)
    [SerializeField]
    private float m_horizontalInput;

    void Start()
    {
        rigidbodyPlayer.GetComponent<Rigidbody2D>(); 
    }

    // Read player input (keyboard or touch) in Update, store for physics in FixedUpdate.
    void Update()
    {
        // Default to keyboard / joystick axis
        float horizontal = Input.GetAxis("Horizontal");

        // Touch support: map touch x position to -1..1 (left = -1, center = 0, right = +1)
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            // Consider Began, Moved and Stationary as active input
            if (t.phase == TouchPhase.Began || t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary)
            {
                // Normalize touch x to range -1..1
                float normalized = (t.position.x / (float)Screen.width - 0.5f) * 2f;
                horizontal = Mathf.Clamp(normalized, -1f, 1f);
            }
        }

        m_horizontalInput = horizontal;
    }

    // Use the cached input to move the rigidbody in FixedUpdate for correct physics timing.
    void FixedUpdate()
    {
        Vector2 direction = new Vector2(m_horizontalInput, 0);
        rigidbodyPlayer.linearVelocity = direction * m_speedPlayer;
    }

}

