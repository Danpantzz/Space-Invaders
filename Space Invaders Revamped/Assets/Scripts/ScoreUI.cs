using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        scoreText.text = "POINTS\n" + GameManager.score.ToString("0000");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "POINTS\n" + GameManager.score.ToString("0000");
    }
}
