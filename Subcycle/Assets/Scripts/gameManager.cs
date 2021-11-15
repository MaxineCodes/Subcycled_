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

    void Start() 
    {
        UIManager = this.GetComponent<UIManager>();
    }

}
