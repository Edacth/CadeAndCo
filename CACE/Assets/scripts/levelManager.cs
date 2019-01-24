using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelManager : MonoBehaviour
{
    public void LoadLevel()
    {
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

}

