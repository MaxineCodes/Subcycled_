using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 10;

    [SerializeField] private Vector2 currentPos;
    [SerializeField] private Vector3 mousePosition;
    private Vector3 previousMousePosition = new Vector3(0f, 0f, 0f);

    [SerializeField] private Vector2 direction;
    [SerializeField] private float playerAngle;

    [Header("Reference Settings")]

    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rigidBody2D;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()                                                                               // Hii!
    {                                                                                           // I changed the flipY to flipX and disabled the quaternion rotation
        currentPos = transform.position;                                                        // It would be nice to still have some rotation, but not completely up and down. Like there's a limit.
                                                                                                // Feel free to revert all these changes btw!
        Movement();
        FlipSprite();
    }

    private void Movement()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            direction = (mousePosition - transform.position).normalized;
            rigidBody2D.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

            playerAngle = AngleBetweenTwoPoints(currentPos, mousePosition);
            //transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, playerAngle));  // ==========================================================
        }
        else
        {
            rigidBody2D.velocity = Vector2.zero;
            transform.rotation = transform.rotation;
        }
    }

    private void FlipSprite()
    {
        if (rigidBody2D.velocity.x < 0)
        {
            spriteRenderer.flipX = false; // ========================================================== previously: flipY
        }
        else if (rigidBody2D.velocity.x > 0)
        {
            spriteRenderer.flipX = true; // ========================================================== previously: flipY
        }
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
