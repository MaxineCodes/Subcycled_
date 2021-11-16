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
    public Text trashCollectedText;
    public GameObject gameWonPopup;

    void Start() 
    {
        gameManager = this.GetComponent<gameManager>();

        gameWonPopup.SetActive(false);

        updateUI();
    }

    public void updateUI()
    {
        trashCollectedText.text = "Trash Collected: " + gameManager.trashCollectedCount;
        if (gameManager.trashCollectedCount >= gameManager.trashCollectedMax) {
            gameWonPopup.SetActive(true);
        }
    }

    public void loadSampleScene() {
        SceneManager.LoadScene("SampleScene");
    }
    public void loadMainMenuScene(){
        SceneManager.LoadScene("mainMenuScene");
    }
}
