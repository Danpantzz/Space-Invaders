using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    private float leftWall;
    private float rightWall;

    private float top;

    private List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);

        leftWall = -25f;
        rightWall = 25f;
        top = 13f;

        Instantiate(player);
        InitializeEnemies();
    }

    // Update is called once per frame
    void Update()
    {

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
                Transform block = enemy.transform;

                // Create the block in the game world, setting it as a child of the blocks container.
                (Instantiate(block, new Vector3(xPos, yPos, 0), Quaternion.identity) as Transform).parent = transform;
            }

            // Update the new row's y position.
            yPos = yPos - enemy.GetComponent<Renderer>().bounds.size.y - gap;
        }
    }
}
