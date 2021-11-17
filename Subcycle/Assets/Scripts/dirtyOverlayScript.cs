using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirtyOverlayScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    public gameManager gm;
    float percentage;
    private float opacity;

    void Start()
    {
        gm = gm.GetComponent<gameManager>();
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Decease opacity along with trash collection percentage.
    void Update()
    {
        percentage = gm.trashCollectedPercent;
        opacity = 0.35f - (percentage / 100) / 2;
        sprite.color = new Color(131, 255, 0, opacity);
    }
}
