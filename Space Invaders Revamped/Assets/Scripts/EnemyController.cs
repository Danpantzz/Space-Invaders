using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.5f;

    private int speedBoostGot = 0;

    private bool moveRight = true;

    private GameObject gameManager;
    private int initialEnemyCount;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager");
        initialEnemyCount = gameManager.GetComponent<GameManager>().enemies.Count;

    }

    // Update is called once per frame
    void Update()
    {
        if(moveRight)
        {
            if (transform.position.x >= 23f)
            {
                List<GameObject> enemiesCopy = gameManager.GetComponent<GameManager>().enemies;

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
            if (transform.position.x <= -23f)
            {
                List<GameObject> enemiesCopy = gameManager.GetComponent<GameManager>().enemies;

                for (int i = 0; i < enemiesCopy.Count; i++)
                {
                    enemiesCopy[i].transform.position = new Vector2(enemiesCopy[i].transform.position.x, enemiesCopy[i].transform.position.y - 1f);
                    enemiesCopy[i].GetComponent<EnemyController>().moveRight = true;
                }

                return;
            }

            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        
        if (speedBoostGot == 0 && gameManager.GetComponent<GameManager>().enemies.Count < Mathf.Floor(initialEnemyCount - (initialEnemyCount * 0.2f)))
        {
            speed = 4;
            speedBoostGot += 1;
        }
        else if (speedBoostGot == 1 && gameManager.GetComponent<GameManager>().enemies.Count < Mathf.Floor(initialEnemyCount - (initialEnemyCount * 0.4f)))
        {
            speed = 6;
            speedBoostGot += 1;
        }
        if (speedBoostGot == 2 && gameManager.GetComponent<GameManager>().enemies.Count < Mathf.Floor(initialEnemyCount - (initialEnemyCount * 0.8f)))
        {
            speed = 10;
        }

    }
}
