using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;

    private bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 25f && moveRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (transform.position.x > 25f && moveRight)
        {
            transform.position = new Vector2(25f, transform.position.y - 1f);
            moveRight = false;

        }

        if (transform.position.x > -25f && !moveRight)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (transform.position.x < -25f && !moveRight)
        {
            transform.position = new Vector2(-25f, transform.position.y - 1f);
            moveRight = true;
        }
    }
}
