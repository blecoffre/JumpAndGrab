using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMusicPlayer : MonoBehaviour
{
    public bool StartOnAwake = false;
    public bool StartOnEnable = false;
    public bool PlayLoop = false;
    public double PlaySheduldedTime = 0.0f;

    [SerializeField]
    AudioSource audioSource = default;
    [SerializeField]
    AudioClip audioClip = default;

    private void Awake()
    {
        if (StartOnAwake)
            PlayClip();
    }

    private void OnEnable()
    {
        if (StartOnEnable)
            PlayClip();
    }

    public void PlayClip()
    {
        audioSource.clip = audioClip;

        if (PlaySheduldedTime <= 0.0f)
            audioSource.Play();
        else
            audioSource.PlayScheduled(PlaySheduldedTime);

        audioSource.loop = PlayLoop;
    }
}
