using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public GameManager gm;
    void Start()
    {
        transform.position = new Vector3(0+35,Screen.height-35/2,0);
    }
    void FixedUpdate()
    {
        GetComponent<TextMeshProUGUI>().text = "Lives: " + gm.getLives();
    }
}
