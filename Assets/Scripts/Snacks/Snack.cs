using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snack : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D snackObject;

    // Ersetzt Start(). Wird JEDES MAL aufgerufen, wenn der Spawner den Snack aktiviert.
    void OnEnable()
    {
        // 1. Reset: Den Schwung (Geschwindigkeit) vom vorherigen Wurf auf null setzen
        snackObject.linearVelocity = Vector2.zero; 
        
        // 2. Reset: Gravitation wieder ausstellen, damit er schwebt
        snackObject.gravityScale = 0f; 

        // 3. Jetzt erst die Coroutine zum Fallen starten
        StartCoroutine(SetGravityScaleAfterSeconds());
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        // Pro-Tipp: CompareTag() ist für WebGL performanter als == "String"
        if (_collision.gameObject.CompareTag("Player")) 
        {
            AudioSource snackEffect = _collision.gameObject.GetComponent<AudioSource>();
            
            // Kleine Sicherheitsabfrage, falls mal keine AudioSource da ist
            if (snackEffect != null) 
            {
                snackEffect.Play();
            }
            
            // RECYCLING: Zerstöre das Objekt nicht, verstecke es nur!
            gameObject.SetActive(false);
        }
        else if (_collision.gameObject.CompareTag("Bottom"))
        {
            // RECYCLING: Auch hier nur verstecken
            gameObject.SetActive(false);
        }
    }

    private IEnumerator SetGravityScaleAfterSeconds()
    {
        yield return new WaitForSeconds(0.25f);
        snackObject.gravityScale = 3f;
    }
}