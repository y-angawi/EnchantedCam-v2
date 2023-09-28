using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    public Material oldMaterial;
    public AudioClip heartBeat;
    public GameObject cam;
    public Levelmanager gameover;
    private float distance;
    private bool paused = false;
    float step;
    Gaze gaze;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangePosition", 0, 5); //calls ChangePosition() every 5 secs
        heartBeat = (AudioClip) Resources.Load("heartbeat");

        gaze = FindObjectOfType<Gaze>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = closeBy();

        move();

        if (distance <= 5.5)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                StartCoroutine(playHeartBeat());
            }
            if (distance <= 2.0)
            {
                //die
                GameOver();
            }
        }
        else
        {
            if (GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Pause();
                print("Paused heartbeat");
            }
        }
    }

    public void ChangePosition()
    {
        GetComponent<Renderer>().material = oldMaterial;
        float x = Random.Range(-1.5f, 5.94f);
        float y = Random.Range(-3.51f, 2.81f);
        float z = Random.Range(4.0f, 5.5f);

        transform.localPosition = new Vector3(x, y, z);
    }

    public float closeBy()
    {
        float dist = Vector3.Distance(cam.transform.position, this.transform.position);
        
        return dist;
    }

    private void move()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        // LOW DIFFICALITY FOR LEVEL 1 - NO MOVEMENT

        if (sceneName == "Level2" && !paused)
        {
            step = 0.5f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, cam.transform.position, step);
        }
        else if (sceneName == "Level3" && !paused)
        {
            step = 1.0f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, cam.transform.position, step);
        }
    }

    public void stopMove()
    {
        paused = true;
    }

    IEnumerator playHeartBeat()
    {
        GetComponent<AudioSource>().clip = heartBeat;
        GetComponent<AudioSource>().Play();
        print("play heartbeat");
        yield return new WaitUntil(() => GetComponent<AudioSource>().isPlaying == false);
    }

    private void GameOver()
    {
        int xp = gaze.GetXp();
        gaze.SetFlag();
        stopMove();
        CancelingInvoke();
        gameover.Setup(xp);
    }

    public void CancelingInvoke()
    {
        CancelInvoke();
    }
}
