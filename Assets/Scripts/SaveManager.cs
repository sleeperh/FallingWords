using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform worldCanvas;
    public GameObject[] words;
    private Save CreateSaveGameObject()
    {
        Save save = new Save
        {
            name = NameInput.currentName,
            score = ScoreManager.currentScore,
            speed = WordSpeed.wordSpeed
        };
        return save;
    }

    public void SaveGame()
    {
        Save save = CreateSaveGameObject();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Game Saved");
    }
    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
        save = JSONtoSave(json);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }
    private Save JSONtoSave(string json)
    {
        Save save = JsonUtility.FromJson<Save>(json);
        return save;
    }
    public void LoadGame()
    {
        
        if (File.Exists(Application.persistentDataPath + "/gamesave.save")) // if there exists a save file
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            ScoreManager.currentScore = save.score;
            NameInput.currentName = save.name;
            WordSpeed.wordSpeed = save.speed;
            Debug.Log("Game Loaded " + "Score: " + save.score);
        }
        else
            Debug.Log("No game saved!");
    }

}
