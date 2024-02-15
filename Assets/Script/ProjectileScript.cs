using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed;
    private float time = 0f;
    private Vector2 Target;
    Collider2D _collider;
    Rigidbody2D _rb2;
    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _rb2 = GetComponent<Rigidbody2D>();
        _rb2.AddForce(Target * speed, ForceMode2D.Impulse);
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= 5f)
        {
            Destroy(gameObject);
        }
    }
    public void SetTarget(Vector2 direction, float _speed)
    {
        Target = direction.normalized;
        speed = _speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

}
