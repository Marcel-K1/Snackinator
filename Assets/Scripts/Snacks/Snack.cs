using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snack : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D snackObject;

    void Start()
    {
        StartCoroutine(SetGravityScaleAfterSeconds());
    }

    //Kontrolliert die Kollision des Snacks mit dem Player oder dem unteren Ende der Spielfläche
    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.gameObject.tag == "Player")
        {
            AudioSource snackEffect = _collision.gameObject.GetComponent<AudioSource>();
            snackEffect.Play();
            Destroy(this.gameObject);
        }
        else if (_collision.gameObject.tag == "Bottom")
        {
            Destroy(this.gameObject);
        }
    }

    //Lässt dir Snacks erst eine gewisse Zeit schweben, bevor sie fallen
    private IEnumerator SetGravityScaleAfterSeconds()
    {
        yield return new WaitForSeconds(0.25f);
        snackObject.gravityScale = 3f;
    }
}
