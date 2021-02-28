using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public GameObject player;
    public GameObject[] cpus;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cpus = GameObject.FindGameObjectsWithTag("CPU");
    }

    
    void Update()
    {
        
    }
}
