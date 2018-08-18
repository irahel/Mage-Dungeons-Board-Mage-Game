using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objective : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<player>().coins++;
            print("pegou obj");
        }
        if (collision.gameObject.tag == "Player2")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<player2>().coins++;
            print("pegou obj");
        }

    }
}
