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

    public Text message;
    public Color messageColour;
    float opacity = 0f;

    public GameObject gameWonPopup;
    public Text trashCollectedText;
    
    public GameObject credits;
    public GameObject intro;

    void Start() 
    {
        gameManager = this.GetComponent<gameManager>();

        gameWonPopup.SetActive(false);
        credits.SetActive(false);
        messageColour = new Color(1f, 1f, 1f, opacity);

        updateUI();
    }
    void Update() 
    {
        messageColour = new Color(1f, 1f, 1f, opacity);
        message.color = messageColour;
    }
    void FixedUpdate() {
        opacity -= 0.01f;
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
    public void openCredits(){
        credits.SetActive(true);
    }
    public void closeCredits(){
        credits.SetActive(false);
    }
    public void openIntro(){
        intro.SetActive(true);
    }
    public void closeIntro(){
        intro.SetActive(false);
    }
    public void displayMessage() {
        opacity = 1f;
    }
}
