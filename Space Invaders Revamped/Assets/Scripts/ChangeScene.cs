using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject shopScreen;
    public GameObject mainScreen;

    public void StartGame()
    {
        SceneManager.LoadScene("SpaceInvaders");
    }

    public void Awake()
    {
        shopScreen.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (shopScreen.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            shopScreen.SetActive(false);
            mainScreen.SetActive(true);
        }
    }

    public void ShopMenu()
    {
        mainScreen.SetActive(false);
        shopScreen.SetActive(true);
    }

    public void BuyExtraLife()
    {
        if (GameManager.score >= 600 && !PlayerController.extraLife && !PlayerController.fasterShip && !PlayerController.smallerShip)
        {
            PlayerController.extraLife = true;
            GameManager.score -= 600;
        }
        
    }

    public void BuyFasterShip()
    {
        if (GameManager.score >= 1000 && !PlayerController.fasterShip && !PlayerController.extraLife && !PlayerController.smallerShip)
        {
            PlayerController.fasterShip = true;
            GameManager.score -= 1000;
        }
        
    }

    public void BuySmallerShip()
    {
        if (GameManager.score >= 800 && !PlayerController.smallerShip && !PlayerController.extraLife && !PlayerController.fasterShip)
        {
            PlayerController.smallerShip = true;
            GameManager.score -= 800;
        }
        
    }
}
