using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Trash puller")]

    public float pullRadius = 2;
    public float pullForce = 1;

    void FixedUpdate()
    {
        foreach (Collider2D collider2D in Physics2D.OverlapCircleAll(transform.position, pullRadius))
        {
            if (collider2D.tag == "Trash")
            {
                TrashPuller(collider2D);
            }
        }
    }

    void TrashPuller(Collider2D collider2D)
    {
        Rigidbody2D trashRB = collider2D.GetComponent<Rigidbody2D>();

        // Calculate direction from target to me
        Vector3 forceDirection = transform.position - collider2D.transform.position;

        // Apply force on target towards me
        trashRB.AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, pullRadius);
    }

}
