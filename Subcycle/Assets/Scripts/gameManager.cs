using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    /*
    In here write the main game systems that are seperate from individual objects.
    For instance: counting the trash and how many have been collected.
    */

    private UIManager UIManager;
    private PlayerManager playerManager;
    public GameObject player;

    public int trashCollectedCount = 0;
    public int trashCollectedMax = 60;
    public int trashCollectedPercent = 0;

    public bool milestone1, milestone2;
    int milestone1check, milestone2check;

    void Start() 
    {
        // Set milestone1 as a 1/3rd of the max count
        float parsable1 = 0; parsable1 = trashCollectedMax / 3;
        milestone1check = (int)parsable1;
        // Set milestone as a 2/3rd of the max count
        float parsable2 = 0; parsable2 = (trashCollectedMax / 3) * 2;
        milestone2check = (int)parsable1;

        UIManager = this.GetComponent<UIManager>();
        playerManager = player.GetComponent<PlayerManager>();
    }

    public void TrashCollected() 
    {
        trashCollectedCount++;

        // Calculate percentage of the trash collected.
        trashCollectedPercent = (int)(0.5f + ((100f * trashCollectedCount) / trashCollectedMax));


        UIManager.updateUI();

        // Debugging
        Debug.Log(trashCollectedPercent);
        Debug.Log(milestone1 + " || " + milestone2);
    }

}
