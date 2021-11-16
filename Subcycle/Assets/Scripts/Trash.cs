using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public gameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //gameManager.TrashCollected();
            DestroyTrash();
        }
    }

    private void DestroyTrash()
    {
        Destroy(gameObject);
    }

}