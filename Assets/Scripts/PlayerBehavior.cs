using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public GameManager instance;
    public GameObject bullet;
    private Camera cam;
    private bool shootVal = false;
    void Start()
    {        
        cam = Camera.main;
        transform.position = cam.ViewportToWorldPoint(new Vector3(.5f,.5f,cam.nearClipPlane));
    }
    void FixedUpdate()
    {
        if(shootVal){
            Instantiate(bullet,transform.position,transform.rotation).SetActive(true);
            shootVal = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid"){
            gameObject.SetActive(false);
            if(instance.getLives() > 1){
                Instantiate(gameObject,cam.ViewportToWorldPoint(new Vector3(.5f,.5f,cam.nearClipPlane)),Quaternion.Euler(new Vector3(0,0,0))).SetActive(true);
            }
            Destroy(gameObject);
            instance.minusOneLife();
            
        }
    }

    void OnShoot()
    {
        shootVal = true;
    }
}
