using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AddNonTriggerBoxCollider();
	}

    private void AddNonTriggerBoxCollider(){
        //gameObject is the particular instance with the particular ship
        //NonTrigger
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
        //Trigger
        //gameObject.AddComponent<BoxCollider>();
    }

    void OnParticleCollision(GameObject other) {
        //print("hit from particle" + gameObject.name);
        Destroy(gameObject);
    }
}
