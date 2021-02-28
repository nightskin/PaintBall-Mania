using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cpu : MonoBehaviour
{
    public bool start;
    public NavMeshAgent agent;
    public Transform[] opponents;
    public Transform shoot;
    public GameObject paintball;
    public Color color;

    public Transform target;

    //Attacking 
    public float atkCooldown = 0;
    public float atkRange = 10;
    bool attacked;
    bool washing;
    RaycastHit hit;

    LayerMask mask;

    float[] dist = new float[3];

    void Start()
    {
        washing = false;
        shoot = transform.Find("shoot");
        agent = GetComponent<NavMeshAgent>();
        attacked = false;
        start = false;
    }
    
    void Update()
    {
        Search();
        if (washing)
        {
            Wash();
        }
    }

    public void Search()
    {
        if (start)
        {
            dist[0] = Vector3.Distance(transform.position, opponents[0].position);
            dist[1] = Vector3.Distance(transform.position, opponents[1].position);
            dist[2] = Vector3.Distance(transform.position, opponents[2].position);

            if (Mathf.Min(dist) == dist[0])
            {
                target = opponents[0];
            }
            else if (Mathf.Min(dist) == dist[1])
            {
                target = opponents[1];
            }
            else if (Mathf.Min(dist) == dist[2])
            {
                target = opponents[2];
            }

            agent.SetDestination(target.position);
        }
    }

    public void ShootAt(Transform t)
    {
        GameObject p = Instantiate(paintball);
        p.transform.position = shoot.position;
        p.GetComponent<Paintball>().color = color;
        p.GetComponent<Paintball>().owner = gameObject;
        p.GetComponent<Paintball>().direction = shoot.forward;
    }

    void Wash()
    {
        GetComponent<MeshRenderer>().material.color = Color.Lerp(GetComponent<MeshRenderer>().material.color, Color.white, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            washing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            washing = true;
        }
    }

}
