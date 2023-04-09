using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.5f;

    public GameObject bullet;

    private int speedBoostGot = 0;

    private bool moveRight = true;

    private GameObject gameManager;
    private int initialEnemyCount;

    public List<GameObject> enemyCanFire = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager");
        initialEnemyCount = gameManager.GetComponent<GameManager>().enemies.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            if (transform.position.x >= 23f)
            {
                List<GameObject> enemiesCopy = gameManager.GetComponent<GameManager>().enemies;

                for (int i = 0; i < enemiesCopy.Count; i++)
                {
                    if (enemiesCopy[i] == null) continue;
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
                    if (enemiesCopy[i] == null) continue;
                    enemiesCopy[i].transform.position = new Vector2(enemiesCopy[i].transform.position.x, enemiesCopy[i].transform.position.y - 1f);
                    enemiesCopy[i].GetComponent<EnemyController>().moveRight = true;
                }

                return;
            }

            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        
        if (speedBoostGot == 0 && GameObject.FindGameObjectsWithTag("Enemy").Length < Mathf.Floor(initialEnemyCount - (initialEnemyCount * 0.2f)))
        {
            speed = 4;
            speedBoostGot += 1;
        }
        else if (speedBoostGot == 1 && GameObject.FindGameObjectsWithTag("Enemy").Length < Mathf.Floor(initialEnemyCount - (initialEnemyCount * 0.4f)))
        {
            speed = 6;
            speedBoostGot += 1;
        }
        if (speedBoostGot == 2 && GameObject.FindGameObjectsWithTag("Enemy").Length < Mathf.Floor(initialEnemyCount - (initialEnemyCount * 0.8f)))
        {
            speed = 10;
        }

        CheckCanFire();
    }

    void CheckCanFire()
    {
        List<GameObject> enemy = gameManager.GetComponent<GameManager>().enemies;
        int count = gameManager.GetComponent<GameManager>().enemies.Count;

        for (int i = 0; i < count - 30; i++)
        {
            if (enemy[i + 10] == null && !enemyCanFire.Contains(enemy[i])) 
            {
                if (enemy[i + 20] == null)
                {
                    if (enemy[i + 30] == null)
                    {
                        enemyCanFire.Add(enemy[i]);
                    }
                }
            }
        }
        for (int i = 10; i < count - 20; i++)
        {
            if (enemy[i + 10] == null && !enemyCanFire.Contains(enemy[i]))
            {
                if (enemy[i + 20] == null)
                {
                    enemyCanFire.Add(enemy[i]);
                }
            }
        }
        for (int i = 20; i < count - 10; i++)
        {
            if (enemy[i + 10] == null && !enemyCanFire.Contains(enemy[i]))
            {
                enemyCanFire.Add(enemy[i]);
            }
        }
        for (int i = 30; i < count; i++)
        {
            if (enemy[i] != null && !enemyCanFire.Contains(enemy[i]))
            {
                enemyCanFire.Add(enemy[i]);
            }
        }

        for (int i = enemyCanFire.Count - 1; i >= 0; i--)
        {
            if (enemyCanFire[i] == null)
            {
                enemyCanFire.Remove(enemyCanFire[i]);
            }
        }
    }
}
