using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{

    private Camera cam;
    private Vector3 size;
    
    void Start()
    {
        cam = Camera.main;
        size = GetComponent<Renderer>().bounds.size/2;
    }
    void FixedUpdate()
    {
        Vector3 newPosition = transform.position;
        Vector3 camBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 camTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
        if (transform.position.x > camTopRight.x+size.x) newPosition.x = camBottomLeft.x;
        if (transform.position.x < camBottomLeft.x-size.x) newPosition.x = camTopRight.x;
        if (transform.position.y > camTopRight.y+size.y) newPosition.y = camBottomLeft.y;
        if (transform.position.y < camBottomLeft.y-size.y) newPosition.y = camTopRight.y;

        transform.position = newPosition;
    }
}
