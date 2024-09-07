using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    public float speed;
    public int smallAsteroidCount;
    public int scorePerAsteroid;
    public GameObject SmallAsteroidPrefab;
    private Vector3 direction;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        direction = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet"){
            if(GetComponent<Renderer>().bounds.size.x > 12){
                genSmallAsteroids();
            }
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Bullet"){
            if(GetComponent<Renderer>().bounds.size.x > 12){
                genSmallAsteroids();
            }
            Destroy(gameObject);
            gm.addToScore(scorePerAsteroid);
        }
    }

    private void genSmallAsteroids(){
        for(int i = 0; i < smallAsteroidCount; i++){
            Vector3 newPosition = transform.position;
            newPosition.x += Random.Range(0,10);
            newPosition.y += Random.Range(0,10);
            Instantiate(SmallAsteroidPrefab,newPosition,Quaternion.Euler(new Vector3(0,0,Random.Range(0,360)))).SetActive(true);
        }
    }
}
