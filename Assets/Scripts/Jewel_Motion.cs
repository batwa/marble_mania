using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel_Motion : MonoBehaviour {
    private Vector3 originalPos;
    private bool rise = true;
	// Use this for initialization
	void Start () {
        originalPos = new Vector3(this.transform.position.x, this.transform.position.y
                                  ,this.transform.position.z);
        Debug.Log(originalPos.y);
	}
	
	// Update is called once per frame
	void Update () {
        if (rise)
        {
            this.transform.Translate((Vector3.up * (float).10) * Time.deltaTime);
            if(this.transform.position.y >= originalPos.y + .10){
                rise = false;
            }
        }else{
            this.transform.Translate((Vector3.down * (float).10) * Time.deltaTime);
            if(this.transform.position.y <= originalPos.y - .10)
            {
                rise = true;
            }
        }
        //this.transform.Translate(-this.transform.position);
        //this.transform.Translate(this.transform.position);

    }
}

