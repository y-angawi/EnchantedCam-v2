using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public Image splasImg;


    IEnumerator Start()
    {
        splasImg.canvasRenderer.SetAlpha(0.0f);

        FadeIn();

        yield return new WaitForSeconds(2.5f);

        FadeOut();

        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene("MainMenu");
    }

    void FadeIn()
    {
        splasImg.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        splasImg.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
