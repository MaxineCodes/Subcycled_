using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coralScript : MonoBehaviour
{
    public gameManager gm;
    private SpriteRenderer sprite;
    Color mColour;

    void Start() 
    {
        gm = gm.GetComponent<gameManager>();
        sprite = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float opacity = (float)gm.trashCollectedPercent / 100;
        mColour = new Color(1f, 1f, 1f, opacity);
        sprite.color = mColour;
    }
}
