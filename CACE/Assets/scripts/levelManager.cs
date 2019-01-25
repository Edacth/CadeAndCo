using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;
public class levelManager : MonoBehaviour
{
    public struct charDat
    {
        public string name;
        public int score;
        public charDat(string s, int i) {
            name = s; score = i;
        }
    };

    const string fileName = "highScores.txt";
    const int saveSlots = 10;

    charDat[] scores = new charDat[saveSlots];
    public timeHolder th;

    string folderPath;
    string dataPath;

    public int playerScore = 10; // sec
    public string playerName = "alexi"; // from input
    public InputField inpF;

    // can only save score once
    bool savedThisGame;

    // gameObject scores go to
    public Text scoreText;
    void Awake()
    {
        folderPath = Application.persistentDataPath;
        dataPath = Path.Combine(folderPath, fileName);
        th = GameObject.FindGameObjectWithTag("const").GetComponent<timeHolder>();

        savedThisGame = false;

        // check if file has been created
        if (!File.Exists(dataPath))
        {
            // create
            using (StreamWriter sw = File.CreateText(dataPath))
            {
                string temp = "empty";
                string temp2 = "0";
                for (int i = 0; i < saveSlots; i++)
                {
                    sw.WriteLine(temp);
                    sw.WriteLine(temp2);
                    scores[i] = new charDat(temp, 0);
                }
                sw.Flush();
                sw.Close();
            }
            
        }  
    }
    
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

    public void SaveScore()
    {
        if (savedThisGame)
        {
            return;
        }
        // only save once per game
        savedThisGame = true;

        // playerName = inpF.text;
        charDat current = new charDat(inpF.text, Int32.Parse(th.score));

        // sort
        LoadScores();
        // temp array with 11 slots
        charDat[] temp = new charDat[saveSlots+1];
        temp[0] = current;

        for(int i = 1; i < saveSlots+1; i++)
        {
            temp[i] = scores[i-1];
        }

        int n = saveSlots+1;
        // bubble sort because operator overloading takes time
        for(int i = 0; i < n-1; i++)
        {
            for(int j = 0; j < n-i-1; j++)
            {
                if (temp[i].score < temp[i + 1].score)
                {
                    // swap
                    var t = temp[j];
                    temp[j] = temp[j + 1];
                    temp[j + 1] = t;
                }
            }
        }

        for (int i = 0; i < saveSlots; i++)
        {
            scores[i] = temp[i];
        }


        // save
        using (StreamWriter sw = File.CreateText(dataPath))
        {
            for(int i = 0; i < saveSlots; i++)
            {
                // transfer back to original array
                // print(scores[i].name);
                //scores[i] = temp[i];
                // write
                sw.WriteLine(scores[i].name);
                sw.WriteLine(scores[i].score.ToString());
            }
            sw.Flush();
            sw.Close();
        }      
    }

    public void LoadScores()
    {     
        // test open
        using (StreamReader sr = File.OpenText(dataPath))
        {
            for(int i = 0; i < saveSlots; i++)
            {
                scores[i] = new charDat(sr.ReadLine(), Int32.Parse(sr.ReadLine()));
            }
            sr.Close();
        };
    }

}

