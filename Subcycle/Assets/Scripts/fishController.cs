using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishController : MonoBehaviour
{
    public Sprite fish0, fish1, fish2, fish3, fish4, fish5, fish6, fish7, fish8, fish9, fish10, fish11, fish12;
    public bool isVisible;

    private SpriteRenderer sprite;
    public gameManager gm;
    private Rigidbody2D rigidBody2D;

    private Vector3 previousMousePosition = new Vector3(0f, 0f, 0f);
    private float moveSpeed = 5;

    private Vector2 currentPos;
    private Vector3 targetPosition;
    private float targetX, targetY;

    private Vector2 direction;
    private float fishAngle;

    float nextTime;
    float modifier;

    Color mColour;
    float opacity = 0f;
    public float fadeTime = 5f;
    float fadeTimeRef;
    int visibleRequirementPercentage;

    void Start()
    {
        fadeTimeRef = fadeTime;
        gm = gm.GetComponent<gameManager>();
        sprite = this.GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();

        // Random Sprite
        switch (Random.Range(0, 12))
        {
            case 0:
                sprite.sprite = fish0;
                break;
            case 1:
                sprite.sprite = fish1;
                break;
            case 2:
                sprite.sprite = fish2;
                break;
            case 3:
                sprite.sprite = fish3;
                break;
            case 4:
                sprite.sprite = fish4;
                break;
            case 5:
                sprite.sprite = fish5;
                break;
            case 6:
                sprite.sprite = fish6;
                break;
            case 7:
                sprite.sprite = fish7;
                break;
            case 8:
                sprite.sprite = fish8;
                break;
            case 9:
                sprite.sprite = fish9;
                break;
            case 10:
                sprite.sprite = fish10;
                break;
            case 11:
                sprite.sprite = fish11;
                break;
            case 12:
                sprite.sprite = fish12;
                break;
        }

        newTargetPosition();

        // Random timer to find new target position
        InvokeRepeating("newTargetPosition", Random.Range(3f, 10f), Random.Range(3f, 10f));
        visibleRequirementPercentage = Random.Range(15, 100);
        moveSpeed = Random.Range(4, 6);
    }

    void Update()
    {
        currentPos = transform.position;

        Movement();
        FlipSprite();

        // Go new direction when reaching the target position.
        if (Vector3.Distance(currentPos, new Vector2(targetX, targetY)) < 1)
        {
            newTargetPosition();
        }

        // Make fish visible when percentage is above a threshold. 
        if (visibleRequirementPercentage <= gm.trashCollectedPercent && !isVisible)
        {
            FadeIn();
        }

        mColour = new Color(1f, 1f, 1f, opacity);
        sprite.color = mColour;
    }

    // Move to target position.
    private void Movement()
    {
        targetPosition = new Vector3(targetX, targetY, 0f);

        direction = (targetPosition - transform.position).normalized;
        rigidBody2D.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

        fishAngle = AngleBetweenTwoPoints(currentPos, targetPosition);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, fishAngle));    // =======================================       
    }

    private void FlipSprite()
    {
        if (rigidBody2D.velocity.x < 0)
        {
            sprite.flipY = false;
        }
        else if (rigidBody2D.velocity.x > 0)
        {
            sprite.flipY = true;
        }
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    private void newTargetPosition()
    {
        //  range: 
        //  x: -75  y:   2
        //  X:  74  Y: -12

        targetX = Random.Range(-125, 125);
        targetY = Random.Range(-12, 2);
    }

    private void FadeIn()
    {
        fadeTime -= Time.deltaTime;

        opacity = 1f - (fadeTime / fadeTimeRef);

        if (fadeTime <= 0)
        {
            isVisible = true;
            opacity = 1f;
        }
    }
}
