using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private float m_speedPlayer = 35f;

    public float SpeedPlayer { get { return m_speedPlayer; } set { m_speedPlayer = value; } }

    [SerializeField]
    private Rigidbody2D rigidbodyPlayer;


    void Start()
    {
        rigidbodyPlayer.GetComponent<Rigidbody2D>(); 
    }

    //Die horizontale Bewegung des Greifers auf dem Arm durch UserInput setzen
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(horizontalInput, 0);
        rigidbodyPlayer.velocity = direction * m_speedPlayer;
    }
}

