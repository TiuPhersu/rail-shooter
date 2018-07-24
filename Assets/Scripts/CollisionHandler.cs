using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//ok as long as tis is the only script that loads scene

public class CollisionHandler : MonoBehaviour {
    AudioSource audioSource;

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1;
    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other){
        StartDeathSequence();
    }
    private void StartDeathSequence() {
        SendMessage("OnPlayerDeath");//execute function called OnPlayerDeath other scripts that uses it
        deathFX.SetActive(true);
        Invoke("LoadLevel", levelLoadDelay);
    }

    private void LoadLevel() {
        SceneManager.LoadScene(1);
    }

}
