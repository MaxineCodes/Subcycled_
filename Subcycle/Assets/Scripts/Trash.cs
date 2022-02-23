using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public gameManager gameManager;
    private SpriteRenderer mRenderer;

    public Sprite[] trashIcons;

    void Start()
    {
        mRenderer = this.GetComponent<SpriteRenderer>();

        // Randomly select a sprite.
        mRenderer.sprite = trashIcons[Random.Range(0, trashIcons.Length)];
        // Rotate the object randomly
        transform.Rotate(0,0, Random.Range(0, 180));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameManager.TrashCollected();
            Destroy(gameObject);
        }
    }
}
