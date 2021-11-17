using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, xpos, ypos;
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        xpos = transform.position.x;
        ypos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float xdist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(xpos + xdist, ypos, transform.position.z);

        if (temp > xpos + length)
        {
            xpos += length;
        }
        else if (temp < xpos - length)
        {
            xpos -= length;
        }
    }
}
