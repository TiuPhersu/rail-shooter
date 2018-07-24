using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

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
        print("hit from particle" + gameObject.name);
        //use explostion fx, set position, don't rotate);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);//have explosion affect to enemy
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
