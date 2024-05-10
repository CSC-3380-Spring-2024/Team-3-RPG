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
        //initialzed the deafult settings for the first time you run it
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
            //if you already hit the start
            //the player prefs get funcitons help get the previous settings
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
            //if hit wasd and the player can move then make the footsteps sound

        }
        else
        {
            soundEffectsAudio.enabled = false;
        }

    }


    public void save()
    {
        //save between scenes, get the player current values ans aves
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
        //if in settings/ bw scenes
        if (!inFocus)
        {
            save();
        }
    }
    public void UpdateSound()
    {//while using slider, save
        backgroundAudio.volume = backgroundSlider.value;
        soundEffectsAudio.volume = soundEffectsSlider.value;
    }

}
