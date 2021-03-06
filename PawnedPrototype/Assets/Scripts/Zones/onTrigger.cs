﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTrigger : MonoBehaviour {

	private EnemyStatePattern enemy;


	// Use this for initialization
	void Start () {
		enemy = transform.parent.GetComponent<EnemyStatePattern>();
	}
	
	// Update is called once per frame
	void Update () {


		
	}

	public void OnTriggerStay (Collider other) {
		if (other.gameObject.tag == "Player") {
			if (enemy.alive && enemy.chase && enemy.seePlayer)
				//Debug.Log ("Chase");
				enemy.wanderingState.ChaseState (); //Enter to Zone One which is Chasing Zone\
		}
			
			
	}

	public void OnTriggerEnter (Collider other) { 
		if (other.gameObject.tag == "Wall") {
			enemy.wanderingState.getwayPoint ();
		

		}
        if(other.gameObject.tag == "Bullet")
        {

        }
	}

	public void OnTriggerExit (Collider otherExit) {


		if (otherExit.gameObject.tag == "Player" && enemy.currentlyChasing == true && enemy.foreverChasing != true) {
			if (enemy.alive) {
				enemy.chaseState.StalkerState ();
			}
		} else if (otherExit.gameObject.tag == "Player" && enemy.currentlyChasing == true && enemy.foreverChasing == true) {
			enemy.chaseState.ChaseState ();
		}

	}
}
