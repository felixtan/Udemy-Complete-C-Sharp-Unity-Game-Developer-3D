using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // called before Start
    void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;  // number of MusicPlayer objects in scene

        if (numMusicPlayers > 1)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);	// keep game object alive
        }
    }
}
