using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 4f;
    [Tooltip("In m")] [SerializeField] float yRange = 5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float restrictedX = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float restrictedY = Mathf.Clamp(rawNewYPos, -yRange, yRange);


        transform.localPosition = new Vector3(restrictedX, restrictedY, transform.localPosition.z);
        //print(xThrow);
        //print(xOffset);
    }
}
