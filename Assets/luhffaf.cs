using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luhffaf : MonoBehaviour {
    public float total, elap;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        elap += Time.deltaTime;
        if(elap >= total)
        {
            GetComponent<AudioSource>().Play();
            elap = 0;
        }
	}
}
