using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Image[] lives;
    private int livesRemaining = 3;

    public void Start()
    {
        if (PlayerController.extraLife)
        {
            livesRemaining = 4;
            healthText.text = livesRemaining.ToString();
        }
        else
        {
            lives[3].enabled = false;
        }
    }

    public void LoseLife()
    {
        livesRemaining--;
        healthText.text = livesRemaining.ToString();

        lives[livesRemaining].enabled = false;

        if (livesRemaining == 0)
        {
            PlayerController.extraLife = false;
            PlayerController.smallerShip = false;
            PlayerController.fasterShip = false;

            GameManager.round = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
