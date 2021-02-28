using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintball : MonoBehaviour
{
    public float speed;
    public GameObject owner;
    public GameObject splat;
    public Vector3 direction;
    public Color color;
    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = color;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Paintable")
        {
            GameObject s = Instantiate(splat);
            s.transform.position = other.GetContact(0).point;
            s.transform.rotation = Quaternion.LookRotation(other.GetContact(0).normal * -1);
            s.GetComponent<Splat>().effectColor = color;
            s.GetComponent<MeshRenderer>().material.color = color;
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "CPU" && other.gameObject != owner)
        {
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(other.gameObject.GetComponent<MeshRenderer>().material.color, color, 0.1f);
            GameObject s = Instantiate(splat);
            s.transform.position = other.GetContact(0).point;
            s.transform.rotation = Quaternion.LookRotation(other.GetContact(0).normal * -1);
            s.GetComponent<Splat>().effectColor = color;
            s.GetComponent<MeshRenderer>().material.color = color;
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Player" && other.gameObject != owner)
        {
            other.gameObject.GetComponent<PlayerMovement>().yourColor.color = Color.Lerp(other.gameObject.GetComponent<PlayerMovement>().yourColor.color, color, 0.1f);
            Destroy(gameObject);
        }
    }

}
