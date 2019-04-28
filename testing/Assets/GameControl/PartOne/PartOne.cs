using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PartOne : MonoBehaviour, PlotSegment
{
    private GameController controller;
    private AudioPlayer darkAudio;
    private AudioPlayer lightAudio;

    public GameObject finalRedStart;
    public GameObject finalRedEnd;
    public GameObject finalBlueStart;
    public GameObject finaleBlueEnd;

    private bool redConected = false;
    private bool blueConected = false;

    private bool darkAudioPlayed = false;
    private bool lightAudioPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<GameController>();
        AudioPlayer[] audio = GetComponentsInChildren<AudioPlayer>();
        darkAudio = audio[0];
        lightAudio = audio[1];
    }


    // Update is called once per frame
    void Update()
    {
        if(darkAudioPlayed && lightAudioPlayed)
        {
            controller.segmentComplete(1);
        }
    }
    public void selectDarkPhone()
    {
        Debug.Log("Recived select dark phone");
        if (redConected)
        {
            Debug.Log("Playing Audio Dark");
            darkAudio.PlayAudio();
        }
        else if (controller.inventoryContains("Red Cable"))
        {
            Debug.Log("Connecting Wire Light");
            finalRedStart.SetActive(true);
            finalRedEnd.SetActive(true);
            controller.destroyInventoryItem("Red Cable");
            redConected = true;
        }
    }

    public void selectLightPhone()
    {
        Debug.Log("Recived select light phone");
        if(blueConected)
        {
            Debug.Log("Playing Audio Light");
            lightAudio.PlayAudio();
        }else if(controller.inventoryContains("Blue Cable"))
        {
            Debug.Log("Connecting Wire Light");
            finalBlueStart.SetActive(true);
            finaleBlueEnd.SetActive(true);
            controller.destroyInventoryItem("Blue Cable");
            blueConected = true;
        }        
    }

}

