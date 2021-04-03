using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour
{

    public GameObject CreditsPanel;
    public GameObject HighScoresButton;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("HighScoresBool") == 0)
        {
            HighScoresButton.SetActive(false);
            CreditsPanel.SetActive(false);
        }
    }


    public void CreditsInterface()
    {
        
        HighScoresButton.SetActive(false);
        CreditsPanel.SetActive(false);
        FindObjectOfType<HighscoreTable>().AddScore();
        if (PlayerPrefs.GetInt("HighScoresBool") == 1)
        {
            PlayerPrefs.SetInt("HighScoresBool", 0);
            Debug.Log("Reloading Scene...");
            SceneManager.LoadScene("GameScene_HighscoreTable");
            
        }

    }

    public void EnableCredits()
    {
        HighScoresButton.SetActive(true);
        CreditsPanel.SetActive(true);
    }
}
