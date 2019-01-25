using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class levelManager : MonoBehaviour
{

    const string fileName = "highScores";
    const string fileExt = ".dat";

    public int playerScore = 10; // sec
    public string playerName; // from input

    private void Awake()
    {
        
    }
    // can only save score once
    bool savedThisGame = false;
    public void LoadLevel()
    {
        // reset
        savedThisGame = false;

        SceneManager.LoadScene("mazeScene");
    }
    public void QuitRequest()
    {
        Debug.Log("I want to Quit!");
        Application.Quit();
    }
    public void LoadLose()
    {
        SceneManager.LoadScene("loseScene");
    }

    void SaveScore(int score, string path)
    {
        // https://unity3d.com/learn/tutorials/topics/scripting/introduction-saving-and-loading

        if (savedThisGame)
        {
            return;
        }

        string folderPath = Application.persistentDataPath;
        string dataPath = Path.Combine(folderPath, fileName);

        savedThisGame = true;
        print("saving data");

        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = File.Open(path, FileMode.OpenOrCreate))
        {
            bf.Serialize(fs, score);
        }

    }

}

