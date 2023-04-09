using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupUI : MonoBehaviour
{
    public GameObject powerupImage;

    public Sprite life;
    public Sprite size;
    public Sprite speed;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.extraLife)
        {
            powerupImage.SetActive(true);
            powerupImage.GetComponent<Image>().sprite = life;
        }
        else if (PlayerController.smallerShip)
        {
            powerupImage.SetActive(true);
            powerupImage.GetComponent<Image>().sprite = size;
        }
        else if (PlayerController.fasterShip)
        {
            powerupImage.SetActive(true);
            powerupImage.GetComponent<Image>().sprite = speed;
        }
        else
        {
            powerupImage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
