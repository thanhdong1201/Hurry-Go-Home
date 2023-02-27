using UnityEngine;

[CreateAssetMenu(fileName = "AudioManager", menuName = "Audio/Audio Manager")]
public class AudioManagerSO : ScriptableObject
{
    [Header("Only Read Value. Do not change")]
    [SerializeField] private float currentMusicValue;
    [SerializeField] private float currentSoundEffectValue;

    public float CurrentMusicValue => currentMusicValue;
    public float CurrentSoundEffectValue => currentSoundEffectValue;

	public void SetCurrentMusicValue(float newValue)
	{
		currentMusicValue = newValue;
	}
	public void SetCurrentSoundEffectValue(float newValue)
	{
		currentSoundEffectValue = newValue;
	}
}
