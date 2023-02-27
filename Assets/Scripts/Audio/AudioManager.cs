using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundEffectSlider;

    [Header("AudioMixerGroup")]
    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup soundEffectMixerGroup;

    [Header("SaveValue")]
    [SerializeField] private AudioManagerSO audioSave;

    private float musicVolume;
    private float soundEffectVolume;


    private void Start()
    {
        SetValue();
    }

    private void Update()
    {
        SetValue();
    }

    private void SetValue()
    {
        musicVolume = audioSave.CurrentMusicValue;
        musicSlider.value = musicVolume;
        musicMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);

        soundEffectVolume = audioSave.CurrentSoundEffectValue;
        soundEffectSlider.value = soundEffectVolume;
        soundEffectMixerGroup.audioMixer.SetFloat("SoundEffectVolume", Mathf.Log10(soundEffectVolume) * 20);
    }

    public void OnChangeMusicSlider(float value)
    {
        audioSave.SetCurrentMusicValue(value);
    }

    public void OnChangeSoundEffectSlider(float value)
    {
        audioSave.SetCurrentSoundEffectValue(value);
    }
}
