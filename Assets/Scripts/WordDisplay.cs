using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WordDisplay : MonoBehaviour
{
    public Text wordText;
    public float fallSpeed = 1;
    
    public void SetWord(string word)
    {
        wordText.text = word;
    }

    public void RemoveLetter()
    {
        wordText.text = wordText.text.Remove(0, 1); // removes first letter and goes one letter foward. 
        wordText.color = Color.red;

    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(0f, WordSpeed.wordSpeed * -fallSpeed * Time.deltaTime, 0f);
        
        if (wordText.transform.position.y <= -5f) // if word falls below screen, destroy it and game over
        {
            RemoveWord();

            SceneManager.LoadScene("GameScene_HighscoreTable");
        }
        
    }
}
