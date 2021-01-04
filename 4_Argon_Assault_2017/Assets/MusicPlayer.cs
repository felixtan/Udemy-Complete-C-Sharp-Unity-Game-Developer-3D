using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    // called before Start
    void Awake()
    {
        DontDestroyOnLoad(this);	// keep game object alive
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
