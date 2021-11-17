using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public bool colourful;  // If false, boring fish. If true, colourful tropical fish.
    private SpriteRenderer sprite;
    public gameManager gm;

    Color mColour;
    int minimumVisibleValue;
    float opacity = 0f;
    public float fadeInTime;

    public Sprite boringSprite0, boringSprite1, boringSprite2;
    public Sprite colourfulSprite0, colourfulSprite1, colourfulSprite2, colourfulSprite3;

    void Start()
    {
        gm = gm.GetComponent<gameManager>();
        sprite = this.GetComponent<SpriteRenderer>();

        // Randomly assign colourful or not.
        if (colourful == true) {
            colourful = true;       // Colourful Fish

            // Random Sprite
            switch (Random.Range(0, 3)) {
                case 0:
                    sprite.sprite = colourfulSprite0;
                    break; 
                case 1:
                    sprite.sprite = colourfulSprite1;
                    break; 
                case 2:
                    sprite.sprite = colourfulSprite2;
                    break; 
                case 3:
                    sprite.sprite = colourfulSprite3;
                    break; 
            }
            // Random value for when the fish appears relative to trash collected percentage.
            minimumVisibleValue = Random.Range(40, 80);
        }
        else {
            colourful = false;      // Boring Fish

            // Random Sprite
            switch (Random.Range(0, 2)) {
                case 0:
                    sprite.sprite = boringSprite0;
                    break; 
                case 1:
                    sprite.sprite = boringSprite1;
                    break; 
                case 2:
                    sprite.sprite = boringSprite2;
                    break; 
            }
            // Random value for when the fish appears relative to trash collected percentage.
            minimumVisibleValue = Random.Range(5, 55);
        }
        opacity = 0f;
        mColour = new Color(1f, 1f, 1f, opacity);
        sprite.color = mColour;

        minimumVisibleValue = 1;
        Debug.Log("Fish minvis: " + minimumVisibleValue);
    }

    void Update()
    {
        if (minimumVisibleValue >= gm.trashCollectedPercent) {
            StartCoroutine(fadeIn());
        }
    }

    private IEnumerator fadeIn () {
        Debug.Log("ïenumerator started");

        while (opacity < 1) {
            //opacity -= 0.01f;
            mColour = new Color(1f, 1f, 1f, opacity);
            sprite.color = mColour;
            Debug.Log(opacity);
        }
        yield return new WaitForSeconds(0.05f); // update interval
    }
}
