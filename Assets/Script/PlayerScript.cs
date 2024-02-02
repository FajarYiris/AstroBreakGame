using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float horizontal;
    float vertical;
    float speed = 10;
    Rigidbody2D rb;
    public GameObject ProjectilePrefab;
    public Transform ShootFrom;
    void Start()
    {
      rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Move(new Vector2(horizontal,vertical));
        LookAtCursor(CursorLocation());
        if(Input.GetMouseButtonDown(0))
        {
            Pew(CursorLocation());
        }
    }
    void Move(Vector2 vector2)
    {
        rb.AddForce(vector2, ForceMode2D.Force);
    }

    void LookAtCursor(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>location of cursor as Vector2</returns>
    Vector2 CursorLocation()
    {
        Vector3 _mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);
        worldMousePosition.z = 0f;
        return (worldMousePosition - transform.position).normalized;
    }
    void Pew(Vector2 direction)
    {
        GameObject Bullet = Instantiate(ProjectilePrefab,ShootFrom.position, Quaternion.identity);
        Bullet.GetComponent<ProjectileScript>().SetTarget(direction,speed);
    }
}
