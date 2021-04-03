using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static int currentScore;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        PlayerPrefs.SetInt("HighScoresBool", 1);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }
}
