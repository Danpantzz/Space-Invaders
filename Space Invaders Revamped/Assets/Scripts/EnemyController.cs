using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.5f;

    private bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moveRight)
        {
            if (transform.position.x >= 25f)
            {
                List<GameObject> enemiesCopy = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().enemies;

                for (int i = 0; i < enemiesCopy.Count; i++)
                {
                    enemiesCopy[i].transform.position = new Vector2(enemiesCopy[i].transform.position.x, enemiesCopy[i].transform.position.y - 1f);
                    enemiesCopy[i].GetComponent<EnemyController>().moveRight = false;
                }

                return;
            }

            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        else
        {
            if (transform.position.x <= -25f)
            {
                List<GameObject> enemiesCopy = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().enemies;

                for (int i = 0; i < enemiesCopy.Count; i++)
                {
                    enemiesCopy[i].transform.position = new Vector2(enemiesCopy[i].transform.position.x, enemiesCopy[i].transform.position.y - 1f);
                    enemiesCopy[i].GetComponent<EnemyController>().moveRight = true;
                }

                return;
            }

            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        //if (transform.position.x < 25f && moveRight)
        //{
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
        //}
        //else if (transform.position.x > 25f && moveRight)
        //{
            //transform.position = new Vector2(25f, transform.position.y - 1f);
            //moveRight = false;
        //}

        //if (transform.position.x > -25f && !moveRight)
        //{
            //transform.Translate(Vector2.left * speed * Time.deltaTime);
        //}
        //else if (transform.position.x < -25f && !moveRight)
        //{
            //transform.position = new Vector2(-25f, transform.position.y - 1f);
            //moveRight = true;
        //}
    }
}
