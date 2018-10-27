using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Trigger_Player : MonoBehaviour {
    public Vector3 respawnCord;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn") {
            this.transform.position = respawnCord;
        }
    }
}
