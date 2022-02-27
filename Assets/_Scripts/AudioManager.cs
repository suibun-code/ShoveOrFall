using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public void PlayClickSound(AudioSource audioSource)
    {
        audioSource.Play();
    }
}
