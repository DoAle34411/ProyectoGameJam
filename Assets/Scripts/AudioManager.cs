using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private bool MainPlay = false;
    private bool LevelPlay = false;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "AudioManager";
                    instance = obj.AddComponent<AudioManager>();
                    DontDestroyOnLoad(obj); // Don't destroy the AudioManager when loading new scenes
                }
            }
            return instance;
        }
    }

    // Define AudioClips for different music tracks
    public AudioClip MenuMusic;
    public AudioClip LevelMusic;

    private AudioSource musicSource;

    void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().volume = 0.3f;
        musicSource.loop = true;
    }

    public void PlayMenuMusic()
    {
        if (!MainPlay)
        {
            musicSource.clip = MenuMusic;
            musicSource.Play();
            LevelPlay = false;
            MainPlay = true;
        }

    }

    public void PlayGameMusic()
    {
        if (!LevelPlay)
        {
            musicSource.clip = LevelMusic;
            musicSource.Play();
            LevelPlay = true;
            MainPlay = false;
        }

    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}