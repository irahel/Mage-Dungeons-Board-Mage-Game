using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnkeleto : MonoBehaviour {
    public GameObject objetc;
    public GameObject tabueiro;
    public int i, j;
    public int phase = 1;
    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    	
	}

    public void spawn()
    {
        if (phase == 1)
        {
            if (tabueiro.GetComponent<game>().campo[i, j] == 0)
                Instantiate(objetc, transform.position, transform.rotation);
        }
        else
        {
            if (tabueiro.GetComponent<game2>().campo[i, j] == 0)
                Instantiate(objetc, transform.position, transform.rotation);
        }
    }
}
