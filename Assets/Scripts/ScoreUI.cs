using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public GameManager gm;
    void Start()
    {
        transform.position = new Vector3(0+50,Screen.height-35-35/2,0);
    }
    void FixedUpdate()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + gm.getScore();
    }
}
