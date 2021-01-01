using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    // allows for manipulation in the Inspector
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 1500f;
    [SerializeField] float levelLoadDelay = 0.5f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip successSound;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] bool collisionsDisabled = false;

    enum State { Alive, Dying, Transcending };
    State state = State.Alive;
    Rigidbody rigidBody;    // ref to Rigidbody of rocket
    AudioSource audioSource;
    Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        rigidBody = GetComponent<Rigidbody>();  // only acts of Rigidbody components; c# generic
                                                // what if there are multiple Rigidbodys?
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Debug.isDebugBuild)
        {
            RespondToDebugKeys();
        }

        if (state == State.Alive)
        {
            RespondToThrustInput();
            RespondToThrustRotate();
        }
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            collisionsDisabled = !collisionsDisabled;
        }
    }

    private void RespondToThrustRotate()
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

    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();
        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }

    private void ApplyThrust()
    {
        rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);   // add forces relative to direction
                                                    // behaviors changes w/ Rigidbody's mass
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);    // play specified AudioClip, default volume scale is 1.0F  
        }

        mainEngineParticles.Play();
    }

    private void LoadNextLevel()
    {
        int levels = SceneManager.sceneCountInBuildSettings;
        int nextSceneBuildIndex = currentScene.buildIndex == levels - 1 ? 0 : currentScene.buildIndex + 1;
        SceneManager.LoadScene(nextSceneBuildIndex);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);  // go to level 1
    }

    private void StartDeathSequence()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(deathSound);
        deathParticles.Play();
        state = State.Dying;
        Invoke("LoadFirstLevel", levelLoadDelay);
    }

    private void StartFinishSequence()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(successSound);
        successParticles.Play();
        state = State.Transcending;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive || collisionsDisabled) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Deadly":
                StartDeathSequence();
                break;
            case "Finish":
                StartFinishSequence();
                break;
            default:
                break;
        }
    }
}
