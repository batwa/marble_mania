using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
    public static int gemsLeft;
    public Text remainingGems;
    GameObject [] getCount;
	// Use this for initialization
	void Start () {
        remainingGems.text = "Gems left: " + gemsLeft.ToString();
        getCount = GameObject.FindGameObjectsWithTag("Jewel");
        gemsLeft = getCount.Length;
    }
	
	// Update is called once per frame
	void Update () {
        remainingGems.text = "Gems left: " + gemsLeft.ToString();
    }
}
