using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitBtn()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("Level1");
    }
}
