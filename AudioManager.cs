using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager audioManegerInstance;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (audioManegerInstance == null)
        {
            audioManegerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
