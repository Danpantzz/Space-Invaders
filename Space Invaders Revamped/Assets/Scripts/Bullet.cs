using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 8f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 20)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("colliding"); 
        Destroy(collision.gameObject);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().enemies.Remove(collision.gameObject);
        Destroy(this.gameObject);

        GameManager.score += 10;
    }
}
