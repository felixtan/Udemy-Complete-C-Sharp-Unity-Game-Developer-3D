using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // called before Start
    void Awake()
    {
        DontDestroyOnLoad(this);	// keep game object alive
    }
}
