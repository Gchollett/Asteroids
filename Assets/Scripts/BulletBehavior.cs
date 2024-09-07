using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed;
    public int bulletTravelDistance;
    private int count;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(count*speed >= bulletTravelDistance){
            Destroy(gameObject);
        }
        transform.position += transform.up * speed;
        count++;
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Asteroid"){
            Destroy(gameObject);
        }
    }
}
