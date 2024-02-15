using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float speed = 10;
    private Vector2 direction;
    private Vector2 currpos;
    Collider2D _collider;
    Rigidbody2D _rb2;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Body");
        currpos = gameObject.transform.position;
        direction = player.transform.position;
        direction = (direction - currpos).normalized;
        Debug.Log($"this is direction {direction}");
        _collider = GetComponent<Collider2D>();
        _rb2 = GetComponent<Rigidbody2D>();
        _rb2.AddForce(direction * speed, ForceMode2D.Impulse);
    }
    public void initializeAsteroid()
    {
        speed = Random.Range(1, 11);
        // this.direction = direction.normalized;
    }
    // void OnCollisionEnter2D(Collision2D something)
    // {
    //     ContactPoint2D contact = something.GetContact(0);
    //     Reflect(contact.normal);
    // }
    // void Reflect(Vector2 wall)
    // {
    //     // this.direction = Vector2.Reflect(_rb2.velocity.normalized, wall);
    // }
}