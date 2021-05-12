using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Configuration")]
    [Tooltip("Horsepower")]
    [SerializeField] float horsePower = 20000f;
    [Tooltip("Turn Speed")]
    [SerializeField] float turnSpeed = 25f;
    [Tooltip("Max Speed")]
    [SerializeField] int maxSpeed = 180;
    [Header("Object References")]
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI rpmText;

    //Private variables
    float horizontalInput, forwardInput;
    int speed;
    int rpm;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.RoundToInt(rb.velocity.magnitude * 3.6f);
        speedText.text = "Speed: " + speed + " Km/h";
        rpm = Mathf.RoundToInt((speed % 30) * 40);
        rpmText.text = "" + rpm;

        //Getting player inputs
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //Moving forward
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        if (speed < maxSpeed)
        {
            rb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
        }
        //Rotates the car
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        
    }
}
