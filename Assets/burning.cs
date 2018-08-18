using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burning : MonoBehaviour {
    public float step;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Transform>().Rotate(0, step, 0);
    }
}
