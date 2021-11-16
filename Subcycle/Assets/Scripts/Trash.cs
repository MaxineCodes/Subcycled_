using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public gameManager gameManager;
    private SpriteRenderer mRenderer;

    public Sprite trash0, trash1, trash2, trash3, trash4, trash5, trash6, trash7, trash8, trash9, trash10;

    void Start()
    {
        mRenderer = this.GetComponent<SpriteRenderer>();

        // Randomly select a sprite.
        Random.Range(0, 10);
        switch (Random.Range(0, 10)) 
        {
            case 0:
                mRenderer.sprite = trash0;
                break;
            case 1:
                mRenderer.sprite = trash1;
                break;    
            case 2:
                mRenderer.sprite = trash2;
                break;
            case 3:
                mRenderer.sprite = trash3;
                break;
            case 4:
                mRenderer.sprite = trash4;
                break;
            case 5:
                mRenderer.sprite = trash5;
                break;    
            case 6:
                mRenderer.sprite = trash6;
                break;    
            case 7:
                mRenderer.sprite = trash7;
                break;    
            case 8:
                mRenderer.sprite = trash8;
                break; 
            case 9:
                mRenderer.sprite = trash9;
                break;    
            case 10:
                mRenderer.sprite = trash10;
                break;  
            default: 
                mRenderer.sprite = trash10;
                break;
        }
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