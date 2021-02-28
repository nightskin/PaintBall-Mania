using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public InputManager inputManager;
    public Image yourColor;
    public GameObject paintball;
    public Transform shootpoint;
    public float speed;
    public float jumpHeight = 3;
    public float gravity = -9.81f;
    public Camera cam;
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public bool grounded;
    private Vector2 lookDir;
    public float lookSensitivity = 0.00001f;
    float xrot = 0;
    bool washing;

    Color color;
    Vector3 velocity;

    void Start()
    {
        washing = false;
        Cursor.lockState = CursorLockMode.Locked;
        inputManager = GameObject.Find("Util").GetComponent<InputManager>();
        cam = transform.Find("Cam").GetComponent<Camera>();
        controller = GetComponent<CharacterController>();
        groundCheck = transform.Find("GroundCheck");
        color = new Color(PlayerPrefs.GetFloat("r"), PlayerPrefs.GetFloat("g"), PlayerPrefs.GetFloat("b"));
    }

    void Update()
    {
        Look();
        Movment();
        Shoot();
        if(washing)
        {
            Wash();
        }
    }
    
    void Movment()
    {
        grounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);

        if(grounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        float x = inputManager.GetMovement().x;
        float y = inputManager.GetMovement().y;

        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * speed * Time.deltaTime);

        if(grounded && inputManager.Jumped())
        {
            velocity.y = Mathf.Sqrt(jumpHeight) * -2 * gravity;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }

    void Look()
    {
        lookDir.x = inputManager.GetAim().x;
        lookDir.y = inputManager.GetAim().y;
        xrot -= lookDir.y;
        xrot = Mathf.Clamp(xrot, -90, 90);

        cam.transform.localRotation = Quaternion.Euler(xrot, 0, 0);
        transform.Rotate(Vector3.up * lookDir.x);
    }

    void Shoot()
    {
        if (inputManager.Shooting())
        {
            GameObject p = Instantiate(paintball);
            p.transform.position = shootpoint.position;
            p.GetComponent<Paintball>().color = color;
            p.GetComponent<Paintball>().owner = gameObject;
            p.GetComponent<Paintball>().direction = shootpoint.forward;
        }
    }

    void Wash()
    {
        yourColor.color = Color.Lerp(yourColor.color, Color.white, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
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
