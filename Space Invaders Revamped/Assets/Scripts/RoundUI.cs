using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundUI : MonoBehaviour
{
    public TextMeshProUGUI roundText;

    // Start is called before the first frame update
    void Start()
    {
        roundText.text = "ROUND " + GameManager.round;
    }

    // Update is called once per frame
    void Update()
    {
        roundText.text = "ROUND " + GameManager.round;
    }
}
