using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -15)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("colliding");
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Play();

            Destroy(this.gameObject);

        }

    }

}
