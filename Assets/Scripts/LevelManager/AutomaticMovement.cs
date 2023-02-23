using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    private float _speed = 15f;

    public float Speed { get { return _speed; } set { _speed = value; } }

    [SerializeField]
    private Rigidbody2D rigidbody;

    [SerializeField]
    private bool endPosition = false;

    void Start()
    {
        rigidbody.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Kontrollieren ob die Endposition für den Arm in vertikaler Richtung erreicht ist, wenn ja, dann auf Anfangsposition setzen
        if (endPosition == false)
        {
            Vector2 direction = new Vector2(0, 1);
            rigidbody.velocity = direction * _speed;
        }
        else
        {
            Vector2 startPos = new Vector2(-2.77f,-33.35f); 
            rigidbody.position = startPos;
            endPosition = false;
        }
         
    }

    //Überprüft die Kollision des Arms mit dem oberen Ende der Spielfläche
    void OnTriggerEnter2D (Collider2D _collision)
    {
        if (_collision.gameObject.tag == "DownMovement")
        {
            endPosition = true;
        }
    }
}
