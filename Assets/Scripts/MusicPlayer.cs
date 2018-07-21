using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {  // Use this for initialization
    private void Awake(){
        var numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        // if more than one music player 
        if (numMusicPlayer > 1){
            //destroy ourselves
            Destroy(gameObject);
        }
        // else
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
}
