using System;
using Unity.Mathematics;
using UnityEngine;

public class Enemy_Base : MonoBehaviour
{
    public float speed;
    public bool shouldMove;
    public bool flying;

    private Vector3 startingPos;
    private Collider2D objCollider;
    private Vector2 dir = Vector2.left;
    private Vector2 flyDir;

    private void Awake()
    {
        if(GetComponent<CircleCollider2D>() != null)
        {
            objCollider = GetComponent<CircleCollider2D>();
        }
        startingPos = transform.position;
        flyDir = new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f));

        if(flyDir.x <= 0.4 && flyDir.x >= -0.4)
        {
            flyDir = new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f));
        }
    }

    private void FixedUpdate()
    {
        if(shouldMove)
        {
            if (!flying)
            {
                float offset = 3f;

                if (transform.position.x <= startingPos.x - offset)
                {
                    dir = Vector2.right;
                }
                else if (transform.position.x >= startingPos.x + offset)
                {
                    dir = Vector2.left;
                }
                transform.Translate(speed * Time.deltaTime * dir);
            }
            else
            {
                transform.Translate(speed * Time.deltaTime * flyDir);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Floor")
        {
            if (transform.position.y > collision.GetContact(0).point.y || transform.position.y < collision.GetContact(0).point.y)
            {
                flyDir.y *= -1;
            }
            else if(transform.position.y == collision.GetContact(0).point.y)
            {
                flyDir.y *= 1;
            }

            if (transform.position.x > collision.GetContact(0).point.x || transform.position.x < collision.GetContact(0).point.x)
            {
                flyDir.x *= -1;
            }
            else if (transform.position.x == collision.GetContact(0).point.x)
            {
                flyDir.x *= 1;
            }
        }
    }
}
