using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseUI : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseText;
    public GameObject newGameBtn;
    public GameObject saveBtn;
    public GameObject loadBtn;
    public GameObject jsonBtn;
    public GameObject musicToggle;
    public AudioSource musicFile;
    public Toggle toggle;
    bool toggler = false;
    bool pause = false;


    private void Awake()
    {
        PauseMenuUI(false); // initially false
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetInt("Music", 1);
            toggle.isOn = true;
            musicFile.enabled = true;
            PlayerPrefs.Save();
        }
        else
        {
            if (PlayerPrefs.GetInt("Music") == 0)
            {
                musicFile.enabled = false;
                toggle.isOn = false;
            }
            else
            {
                musicFile.enabled = true;
                toggle.isOn = true;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                PauseMenuUI(true);
                pause = true;
            }
            else if (pause)
            {
                PauseMenuUI(false);
                pause = false;
            }
        }
        PlayerPrefs.GetInt("Music");
    }

    
    public void PauseButton()
    {
        if (!pause)
        {
            PauseMenuUI(true);
            pause = true;
        }
        else if (pause)
        {
            PauseMenuUI(false);
            pause = false;
        }
    }
    public void PauseMenuUI(bool activeBool)
    {

        pausePanel.SetActive(activeBool);
        pauseText.SetActive(activeBool);
        newGameBtn.SetActive(activeBool);
        saveBtn.SetActive(activeBool);
        loadBtn.SetActive(activeBool);
        jsonBtn.SetActive(activeBool);
        musicToggle.SetActive(activeBool);
        if (activeBool)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }

    public void MusicToggler(bool active)
    {
        if (active)
        {
            musicFile.Play();
        }
        else if (!active)
        {
            musicFile.Stop();
        }
    }    
}
