using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceController : MonoBehaviour
{
    public AudioMixer _mixer;

    public GameObject coinSFX;
    public GameObject heartSFX;
    public GameObject deathSFX;
    public GameObject checkpointSFX;

    private void Start()
    {
        UpdateMusicGroup(PlayerPrefs.GetFloat(Structs.Mixers.musicVolume));
        UpdateSFXGroup(PlayerPrefs.GetFloat(Structs.Mixers.sfxVolume));
    }

    public void CreateVSX(string audioName)
    {
        GameObject newAudio = Instantiate(GetSFX(audioName), Vector3.zero, Quaternion.identity);
        newAudio.GetComponent<AudioSource>().Play();
    }

    public GameObject GetSFX(string audioName)

    {
        switch (audioName)
        {
            case Structs.SoundEffects.coin:
                {
                    return coinSFX;

                }
            case Structs.SoundEffects.heart:
                {
                    return heartSFX;
                }
            case Structs.SoundEffects.death:
                {
                    return deathSFX;
                }
            case Structs.SoundEffects.checkpoint:
                {
                    return checkpointSFX;
                }
        }
        return null;


    }

    public void UpdateSFXGroup(float newVolume)
    {
        PlayerPrefs.SetFloat(Structs.Mixers.sfxVolume, newVolume);
        _mixer.SetFloat(Structs.Mixers.sfxVolume, Mathf.Log10(newVolume) * 20);
    }
    public void UpdateMusicGroup(float newVolume)
    {
        PlayerPrefs.SetFloat(Structs.Mixers.musicVolume, newVolume);
        _mixer.SetFloat(Structs.Mixers.musicVolume, Mathf.Log10(newVolume) * 20);
    }
}
