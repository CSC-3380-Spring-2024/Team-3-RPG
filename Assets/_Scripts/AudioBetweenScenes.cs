
using UnityEngine;

public class AudioBetweenScenes : MonoBehaviour
{
    private static readonly string backgroundPref = "backgroundPref";
    private static readonly string soundEffectsPref = "soundEffectsPref";

    private float backgroundFloat, soundEffectsFloat;
    public AudioSource backgroundAudio;
    public AudioSource soundEffectsAudio;

    void Awake()
    {
        continueSetting();
    }

    private void continueSetting()
    {
        backgroundFloat = PlayerPrefs.GetFloat(backgroundPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(soundEffectsPref);

        backgroundAudio.volume = backgroundFloat;

        soundEffectsAudio.volume = soundEffectsFloat;
    }
    // private static AudioBetweenScenes instance;

    // public AudioSource audioSource;

    // private void Awake()
    // {
    //     // Singleton pattern to ensure only one instance of AudioController exists
    //     if (instance == null)
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject); // Prevent this GameObject from being destroyed when loading a new scene
    //     }
    //     else
    //     {
    //         Destroy(gameObject); // If another AudioController already exists, destroy this instance
    //     }
    // }

    // // Play the audio clip
    // public void Play(AudioClip clip)
    // {
    //     audioSource.clip = clip;
    //     audioSource.Play();
    // }

    // // Stop the audio clip
    // public void Stop()
    // {
    //     audioSource.Stop();
    // }
}
