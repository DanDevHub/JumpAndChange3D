using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceGamePanel : MonoBehaviour
{
    public Text distance;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance.text = player.position.x.ToString("0");
        //PlayerPrefs.SetFloat("DistanceScore", distance);
    }
}
