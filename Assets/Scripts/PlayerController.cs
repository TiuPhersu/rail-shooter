using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    //movement on screen and limit to the viewable screen
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 4f;
    [Tooltip("In m")] [SerializeField] float yRange = 5f;

    //rotation
    [Header("Screen-Position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -30f;
    [Header("Control-Throw Based")]
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;


    float xThrow, yThrow;
    bool isControlEnabled = true;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update (){
        if (isControlEnabled){
            ProcessTranslation();
            ProcessRotation();
        }
    }

    void OnPlayerDeath() {// called by string reference
        //freeze the controls
        isControlEnabled = false;
    }

    private void ProcessRotation(){
        //transform.localRotation = Quaternion.Euler(x, y, z);
        // pitch controls the vertical view
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        // yaw controls the horizontal view
        float yaw = transform.localPosition.x * positionYawFactor;
        // roll controls the spin
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation(){
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float restrictedX = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float restrictedY = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        //set the position
        transform.localPosition = new Vector3(restrictedX, restrictedY, transform.localPosition.z);
    }
}
