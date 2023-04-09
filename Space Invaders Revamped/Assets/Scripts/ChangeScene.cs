using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    GameObject shopScreen;
    GameObject mainScreen;

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
        PlayerController.extraLife = true;
        GameManager.score -= 20;
    }

    public void BuyFasterShip()
    {
        PlayerController.fasterShip = true;
        GameManager.score -= 20;
    }

    public void BuySmallerShip()
    {
        PlayerController.smallerShip = true;
        GameManager.score -= 20;
    }
}
