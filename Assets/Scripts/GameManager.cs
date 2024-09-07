using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject AsteroidPrefab;
    public int asteroidNum;
    private int lives = 3;
    private int score = 0;
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
        cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));
        genAsteroids();
    }
    void Awake()
    {
        if (instance == null) instance = this;
    }
    void FixedUpdate()
    {
        if(GameObject.FindGameObjectsWithTag("Asteroid").Length == 0){
            genAsteroids();
        }
    }
    public void minusOneLife()
    {
        lives -= 1;
    }
    public int getLives()
    {
        return lives;
    }

    private void genAsteroids()
    {
        for(int i = 0; i < asteroidNum; i++){
            Instantiate(AsteroidPrefab,cam.ViewportToWorldPoint(new Vector3(Random.Range(0,2),Random.Range(0,2),cam.nearClipPlane)),Quaternion.Euler(new Vector3(0,0,Random.Range(0,360)))).SetActive(true);
        }
    }

    public void addToScore(int addition)
    {
        score += addition;
    }

    public int getScore()
    {
        return score;
    }
}
