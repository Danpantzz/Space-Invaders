using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public static int score;
    public static int round = 1;

    public int tempScore;

    private float leftWall;
    private float rightWall;

    private float top;

    public List<GameObject> enemies = new List<GameObject>();

    private int timeCheck = 0;

    private void Awake()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Enemy Bullet");
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);

        timeCheck = 0;

        leftWall = -15f;
        rightWall = 15f;
        top = 9f;

        Instantiate(player);
        InitializeEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            score -= tempScore;
            round = 1;
            SceneManager.LoadScene("MainMenu");
            SceneManager.UnloadSceneAsync("SpaceInvaders");
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] != null)
            {
                break;
            }
            else if (enemies[i] == null && i == enemies.Count - 1)
            {
                round++;
                tempScore = 0;
                enemies.Clear();
                GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
                foreach (GameObject bullet in bullets)
                {
                    Destroy(bullet);
                }
                Destroy(GameObject.FindGameObjectWithTag("Enemy Bullet"));
                InitializeEnemies();
            }
        }

        if (Time.time > timeCheck)
        {
            timeCheck += 4;
            Fire();
        }
    }

    public void InitializeEnemies()
    {
        float totalSize = Mathf.Abs(leftWall) + Mathf.Abs(rightWall);

        // Calculate the number of blocks that can fit on the court.
        float blockNum = Mathf.Floor(totalSize / enemy.GetComponent<Renderer>().bounds.size.x);

        // Calculate the size of the gap between the maximum number of bricks and the edge of the court.
        float endGap = totalSize - (blockNum * enemy.GetComponent<Renderer>().bounds.size.x);

        // Calculate the gap we want to place between each block.
        float gap = endGap / (blockNum);
        gap = 2;

        // Initialize a local variable to the top of the court.
        float yPos = top;

        // Iterate through the 4 rows of blocks...
        for (int i = 0; i < 4; i++)
        {
            // ...and iterate across the screen using the gap size and block width to guide us...
            for (float xPos = leftWall; xPos <= rightWall; xPos = xPos + enemy.GetComponent<Renderer>().bounds.size.x + gap)
            {
                // Create a placeholder transform.
                //Transform block = enemy.transform;

                // Create the block in the game world, setting it as a child of the blocks container.
                enemies.Add(Instantiate(enemy, new Vector3(xPos, yPos, 0), Quaternion.identity));
            }

            // Update the new row's y position.
            yPos = yPos - enemy.GetComponent<Renderer>().bounds.size.y - gap;
        }
    }

    void Fire()
    {
        int index = Random.Range(0, (GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>().enemyCanFire.Count - 1));
        GameObject fireEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>().enemyCanFire[index];
        GameObject enemyBullet = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>().bullet;
        Instantiate(enemyBullet, new Vector3(fireEnemy.transform.position.x, fireEnemy.transform.position.y - 1f, 0f), Quaternion.identity);
    }
}
