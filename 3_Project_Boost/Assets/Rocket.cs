using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;    // ref to Rigidbody of rocket

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();  // only acts of Rigidbody components; c# generic
                                                // what if there are multiple Rigidbodys?
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        // throw new NotImplementedException();

        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up);   // add forces relative to direction
                                                      // behaviors changes w/ Rigidbody's mass
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.forward);  // Transform component of the Rocket
                                                // forward = z-axis
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward); // counter-clockwise
        }
    }
}
