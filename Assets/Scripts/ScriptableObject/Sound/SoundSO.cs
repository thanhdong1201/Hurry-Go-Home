using UnityEngine;
using System;

[CreateAssetMenu(fileName = "SoundsManager", menuName = "Audio/SoundsManager")]
public class SoundSO : ScriptableObject
{
    public AudioClip jump;
    public AudioClip collectCoin;
    public AudioClip collectItem;
    public AudioClip hitByVehical;
    public AudioClip explosion;
    public AudioClip gameOver;

}

[System.Serializable]
public class Sound
{
    [HideInInspector] public AudioSource source;
    public string clipName;
    public AudioClip audioClip;
    public bool isLoop;
    public bool isPlayOnAwake;
    [Range(0, 1)]
    public float volume = 0.5f;
}


