using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int rotation_speed;
    private float moveVal = 0;
    private float rotateVal = 0;
    void FixedUpdate()
    {
        Vector3 direction = transform.up;
        direction.Normalize();
        transform.position += direction * speed * moveVal;
        transform.Rotate(new Vector3(0,0,-rotation_speed*rotateVal));
    }
    void OnMove(InputValue value)
    {
        moveVal = value.Get<float>();
    }

    void OnRotate(InputValue value)
    {
        rotateVal = value.Get<float>();
    }
}
