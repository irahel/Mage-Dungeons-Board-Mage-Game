using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dance : MonoBehaviour {
    private float time_right_anim_1;
    public float total_time_anim_1;
    public float steap_anim_1;
    private bool state_anim_1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        time_right_anim_1 += Time.deltaTime;
        if (time_right_anim_1 >= total_time_anim_1)
        {
            state_anim_1 = !state_anim_1;
            time_right_anim_1 = 0;
        }

        if (state_anim_1 == true) GetComponent<Transform>().Rotate(0, 0, steap_anim_1);
        else GetComponent<Transform>().Rotate(0, 0, -steap_anim_1);
    }
}
