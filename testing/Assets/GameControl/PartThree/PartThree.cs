using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Chris, write all of the logic for part 3 here. If you need something from the inventory or the manual, get it from controller (take a look at what methods it has)
//The controller handles everything. When the Part 3 is complete, notify the controller in update().
//The controller will call the methods bellow when the phone is selected by the player.
//You can assume that if this code is running, everything in Parts 1 and 2 are complete.
//Don't worry about making the segment start or starting the next segment. The controller handles that, you just need to tell it when you're done.
//Also, please let me know if there is something that needs to be changed/added/deleted from the controller
//You can create other scripts (and/or add those scripts to game objects) as needed in the PartThree folder too! 
//  And can add methods here to interact with the scripts you create. 
//If you need to add more audio components, create a child GameObject of this object and add the AudioPlayer script to it (its in the GameControl folder)
//  add the audio as a component to that GameObject. You will need to add variables bellow (see the AudioPlayer feilds) and edit the start method. 
//  I've set up the first few audio components with some filler audio so you can see how it works
//You can create new InventoryItem scripts as well (just please don't change the existing ones)! 
//  Take a look at RedPhoneCable and BluePhoneCable in part 1 for reference. 
//If you have any questions, take a look at PartOne! and also I can answer questions too!

public class PartThree : MonoBehaviour, PlotSegment
{
    //Use this controller to interact with manual/inventory
    private GameController controller;

    //Audio 
    private AudioPlayer previousDarkAudio;
    private AudioPlayer previousLightAudio;
    private AudioPlayer darkAudio;
    private AudioPlayer lightAudio;
    //create more AudioPlayers here if you need more audio 

    //Add variables here as needed. You can delete these but they might be useful so I left them in here from part 1
    private bool darkAudioPlayed = false;
    private bool lightAudioPlayed = false;
    

    void Start()
    {
        controller = GetComponentInParent<GameController>();
        AudioPlayer[] audio = GetComponentsInChildren<AudioPlayer>();
        previousDarkAudio = audio[0];
        previousLightAudio = audio[1];
        darkAudio = audio[2];
        lightAudio = audio[3];
        //to add more audio components, initialize AudioPlayers above from array.
        //GetComponentsInChilren<AudioPlayer>() returns an array of the child audio components. 
    }

    //Use update to check if the segement is complete.
    //if it is complete execute: controller.segmentComplete(3);
    //I've written some pseudo code bellow
    void Update()
    {
        /* if(check if complete){
         *   controller.segmentComplete(3);
         *   }
         * */
    }


    //These methods run whenever the phones are clicked. And don't delete these. 
    //Change what the methods do as needed. 
    public void selectDarkPhone()
    {
        //this is here so that it still plays part 2's audio if they have not done anything in part 3
        //feel free to change if needed
        previousDarkAudio.PlayAudio(); 

        //This is code leftover from part 1 but could be useful:
        //darkAudio.PlayAudio();
    }

    public void selectLightPhone()
    {
        previousLightAudio.PlayAudio();
            //lightAudio.PlayAudio();
    }

    
}

