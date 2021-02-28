using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOS : MonoBehaviour
{
    Cpu cpu;
    bool found;
    private void Start()
    {
        cpu = transform.parent.gameObject.GetComponent<Cpu>();
        found = false;
    }

    private void Update()
    {
        if(found)
        {
            cpu.atkCooldown -= Time.deltaTime;
            if (cpu.atkCooldown <= 0)
            {
                cpu.ShootAt(cpu.target);
                cpu.atkCooldown = 1.5f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == cpu.target)
        {
            found = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == cpu.target)
        {
            found = false;
        }
    }
}
