using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class PartOne : MonoBehaviour, PlotSegment
{
    private GameController controller;
    AudioSource darkAudio;
    AudioSource lightAudio;
    public void darkCablePlaced(bool placed)
    {
        throw new System.NotImplementedException();
    }

    public void lightCablePlaced(bool placed)
    {
        throw new System.NotImplementedException();
    }

    public void playDarkPhoneAudio()
    {
        darkAudio.Play();
    }

    public void playLightPhoneAudio()
    {
        lightAudio.Play();
    }


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<GameController>();
        AudioSource[] audio = GetComponents<AudioSource>();
        darkAudio = audio[0];
        lightAudio = audio[1];
    }


    // Update is called once per frame
    void Update()
    {

    }
}

