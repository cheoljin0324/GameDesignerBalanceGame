using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioActive : MonoBehaviour
{
    public AudioSource adSource;

    [SerializeField]
    public List<AudioClip> newClip;

    private void Start()
    {
        adSource = GetComponent<AudioSource>();
        adSource.clip = newClip[0];
        adSource.Play();
    }

    public void ChangeAudio(int index)
    {
        adSource.clip = newClip[index];
        adSource.Play();
    }
}
