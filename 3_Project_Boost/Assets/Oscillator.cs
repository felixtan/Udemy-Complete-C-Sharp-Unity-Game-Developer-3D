using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(-15.0f, -2.0f, 0f);
    [SerializeField] float period = 2f;

    Vector3 startingPos;
    float movementFactor; // 0 for not moved, 1 for fully moved

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;  // automatically frame rate independent
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau); // [-1, 1]

        movementFactor = rawSinWave / 2f + 0.5f;    // [0, 1]
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
