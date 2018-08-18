using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ggggg : MonoBehaviour {
    public int state;

    public GameObject s1, s2, s22, s31, s32;
	// Use this for initialization
	void Start () {
        state = 1;
	}

    // Update is called once per frame
    void Update()
    {
        if (state == 1)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                state = 2;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.LoadLevel("1");
            }
        }else if(state == 2)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                state = 1;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                state = 3;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.LoadLevel("2");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                state = 2;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.Quit();
            }
        }
        update_state();
    }

    void update_state()
    {
        if (state == 1)
        {
            s1.SetActive(true);
            s2.SetActive(false);
            s22.SetActive(false);
            s31.SetActive(false);
            s32.SetActive(false);
        }
        else if (state == 2)
        {
            s1.SetActive(false);
            s2.SetActive(true);
            s22.SetActive(true);
            s31.SetActive(false);
            s32.SetActive(false);
        }
        else
        {
            s1.SetActive(false);
            s2.SetActive(false);
            s22.SetActive(false);
            s31.SetActive(true);
            s32.SetActive(true);
        }

    }
}
