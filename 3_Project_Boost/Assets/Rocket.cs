﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    enum State { Alive, Dying, Transcending };
    State state = State.Alive;
    Rigidbody rigidBody;    // ref to Rigidbody of rocket
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();  // only acts of Rigidbody components; c# generic
                                                // what if there are multiple Rigidbodys?
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {
            Thrust();
            Rotate();
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true;    // take manual control of rotation

        float rotationThisFrame = rcsThrust * Time.deltaTime;   // rot speed = thurst * frame_time

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);  // Transform component of the Rocket
                                                                    // forward = z-axis
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame); // counter-clockwise
        }

        rigidBody.freezeRotation = false;   // resume physics control of rotation
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);   // add forces relative to direction
                                                      // behaviors changes w/ Rigidbody's mass
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // prevent layering BRRRT sound   
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1);  // go to level 2
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);  // go to level 1
    }

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Deadly":
                state = State.Dying;
                Invoke("LoadFirstLevel", 0f);
                break;
            case "Finish":
                state = State.Transcending;
                Invoke("LoadNextLevel", 1f);    // load next scene after 1s
                break;
            default:
                break;
        }
    }
}
