using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cam;
    public float parallaxEffect;
    private float startingPosition;
    private float length;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x -= Time.deltaTime * parallaxEffect * TimeManager.instance.CurrentSpeed;

        if((position.x - cam.position.x) < -length)
        {
            position.x += length;
        }
        else if ((position.x - cam.position.x) > length)
        {
            position.x -= length;
        }

        transform.position = position;
    }
}
