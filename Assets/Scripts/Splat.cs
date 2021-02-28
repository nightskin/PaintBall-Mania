using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splat : MonoBehaviour
{
    public GameObject effect;
    public Color effectColor;
    public float fadetime = 5;
    
    void Start()
    {
        effect = transform.GetChild(0).gameObject;
        ParticleSystem p = effect.GetComponent<ParticleSystem>();
        p.startColor = effectColor;
    }
    
    void Update()
    {
        fadetime -= Time.deltaTime;
        if(fadetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
