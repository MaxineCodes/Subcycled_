using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    /*
    In here write everything that UI needs to do.
    Such as functions that are called from buttons.
    Creating lots of seperate functions all over is messy so this keeps it organized.
    */

    private gameManager gameManager;

    void Start() 
    {
        gameManager = this.GetComponent<gameManager>();
    }

    public void loadSampleScene() 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
