using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour {

    public float start_position;
    public float end_position;
    public bool positive_direction;
    bool at_start;
    float direction;
    public float speed;
    Vector3 target;

	// Use this for initialization
	void Start () {
        at_start = true;
        transform.position = new Vector3(start_position, transform.position.y, transform.position.z);
        target = new Vector3(end_position, transform.position.y, transform.position.z);
        if (positive_direction) {
            direction = 1.0f;
        } else {
            direction = -1.0f;
        }
	}
	
	// Update is called once per frame
	void Update () {
        // move until a certain point and then move back
        if(at_start) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(end_position, transform.position.y, transform.position.z), direction * speed * Time.deltaTime);
            at_end(end_position);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(start_position, transform.position.y, transform.position.z), direction * speed * Time.deltaTime);
            at_end(start_position);
        }
	}

    // Checks whether or not a point is reached and changes bool at_start
    // accordingly
    // pos ==> either end_position or start_position
    void at_end(float x_pos) {
        if (Mathf.Abs(transform.position.x - x_pos) <= 0.1f)
        {
            at_start = !at_start;
        }
    }
}
