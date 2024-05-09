using UnityEngine.UI;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string backgroundPref = "backgroundPref";
    private static readonly string soundEffectsPref = "soundEffectsPref";

    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectsSlider;
    private float backgroundFloat, soundEffectsFloat;

    [SerializeField]
    public PlayerController playerController;

    public AudioSource backgroundAudio;
    public AudioSource soundEffectsAudio;

    public static AudioManager Instance { get; private set; }
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlayInt == 0)
        {
            backgroundFloat = 0;
            soundEffectsFloat = 0;
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(backgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(soundEffectsPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(backgroundPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(soundEffectsPref);
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (playerController != null && playerController.enabled)
            {
                soundEffectsAudio.enabled = true;
            }

        }
        else
        {
            soundEffectsAudio.enabled = false;
        }

    }

    // private void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //         // ensures persistence across scenes
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         // destroys any duplicate instances
    //         Destroy(gameObject);
    //     }
    // }

    public void save()
    {
        if (backgroundSlider != null && backgroundPref != null)
        {
            PlayerPrefs.SetFloat(backgroundPref, backgroundSlider.value);
        }

        if (soundEffectsSlider != null && soundEffectsPref != null)
        {
            PlayerPrefs.SetFloat(soundEffectsPref, soundEffectsSlider.value);
        }
    }


    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            save();
        }
    }
    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;
        soundEffectsAudio.volume = soundEffectsSlider.value;
    }

}
