﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        scoreText.text =  ScoreManager.currentScore.ToString();
    }
}
