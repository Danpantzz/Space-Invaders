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

    public void LoseLife()
    {
        livesRemaining--;
        healthText.text = livesRemaining.ToString();

        lives[livesRemaining].enabled = false;

        if (livesRemaining == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
