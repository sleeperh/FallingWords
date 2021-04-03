using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManage : MonoBehaviour
{
   
    public void RestartGame()
    {
        SceneManager.LoadScene("Intro");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
