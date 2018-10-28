﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_Trigger_Player : MonoBehaviour {
    public Vector3 respawnCord;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    /*
     * handles all trigger events.
     */
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("yee");
        if (other.gameObject.tag == "Respawn") {
            this.transform.position = respawnCord;
        }
        if (other.gameObject.tag == "Jewel")
        {
            score.gemsLeft--;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Portal")
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}
