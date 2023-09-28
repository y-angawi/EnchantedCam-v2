using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gaze : MonoBehaviour
{
    public Material newMaterial;
    public Levelmanager gameover;
    public Levelmanager win;
    public Text points;
    private int xp = 0;
    private AudioClip roar;
    private bool flag = false;
    Ghost g;
    int maxWin;
    string sceneName;


    // Start is called before the first frame update
    void Start()
    {
        roar = (AudioClip) Resources.Load("growl");
        g = FindObjectOfType<Ghost>();

        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        sceneName = currentScene.name;

        if (sceneName == "Level1")
        {
            maxWin = 10;
        }
        else if (sceneName == "Level2")
        {
            maxWin = 15;
        }
        else if (sceneName == "Level3")
        {
            maxWin = 15;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject ob = hit.collider.gameObject;
            if (ob.CompareTag("GhostTagged") && flag == false)
            {
                flag = true;
                ob.GetComponent<Renderer>().material = newMaterial;
                StartCoroutine(playRoar());
                StartCoroutine(Wait());
                xp++;
                DisplayPoints(xp);

                if (xp == maxWin)
                {
                    Won();
                }
            }
        }
    }

    IEnumerator playRoar()
    {
        GetComponent<AudioSource>().clip = roar;
        GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => GetComponent<AudioSource>().isPlaying == false);
    }

    IEnumerator Wait()
    {
        if (sceneName == "Level1")
        {
            yield return new WaitForSeconds(1);
        }
        else if (sceneName == "Level2" || sceneName == "Level3")
        {
            yield return new WaitForSeconds(0.5f);
        }

        g.ChangePosition();
        flag = false;
    }

    void DisplayPoints(int pointsVal)
    {
        points.text = "XP: " + pointsVal;
    }

    public int GetXp()
    {
        return xp;
    }

    public void SetFlag()
    {
        flag = true;
    }

    private void GameOver()
    {
        flag = true;
        g.CancelingInvoke();
        g.stopMove();
        gameover.Setup(xp);
    }

    private void Won()
    {
        flag = true;
        g.CancelingInvoke();
        g.stopMove();
        win.SetupWin(xp);
    }
}
