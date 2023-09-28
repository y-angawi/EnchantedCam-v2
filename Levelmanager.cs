using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Levelmanager : MonoBehaviour
{
    public Text pointText;

    public void Setup(int xp)
    {
        gameObject.SetActive(true);
        pointText.text = "XP: " + xp.ToString();
    }

    public void SetupWin(int xp)
    {
        gameObject.SetActive(true);
        pointText.text = "XP: " + xp.ToString();
    }

    public void QuitBtn()
    {
        PlayerPrefs.SetInt("LoadSaved", 1);
        PlayerPrefs.SetInt("SavedGame", SceneManager.GetActiveScene().buildIndex);
        Application.Quit();
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadGame()
    {
        if(PlayerPrefs.GetInt("LoadSaved") == 1)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedGame"));
        }
        else
        {
            return;
        }
    }

    public void MainBtn()
    {
        PlayerPrefs.SetInt("LoadSaved", 1);
        PlayerPrefs.SetInt("SavedGame", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MainMenu");
    }

    public void ToSecondLevel()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ToThirdLevel()
    {
        SceneManager.LoadScene("Level3");
        print("Level3");
    }

}
