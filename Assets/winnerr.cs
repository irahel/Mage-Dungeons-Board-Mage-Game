using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winnerr : MonoBehaviour {
    private float time_right_anim_1;
    public float total_time_anim_1;
    public int steap_anim_1;
    private bool state_anim_1;
    // Use this for initialization
    void Start()
    {
        GetComponent<UnityEngine.UI.Text>().color = Color.yellow;

    }

    // Update is called once per frame
    void Update()
    {

        time_right_anim_1 += Time.deltaTime;
        if (time_right_anim_1 >= total_time_anim_1)
        {
            state_anim_1 = !state_anim_1;
            time_right_anim_1 = 0;
        }

        if (state_anim_1 == true) GetComponent<UnityEngine.UI.Text>().fontSize += steap_anim_1;
        else GetComponent<UnityEngine.UI.Text>().fontSize -= steap_anim_1;

        if (GetComponent<UnityEngine.UI.Text>().color == Color.yellow)
        {
            GetComponent<UnityEngine.UI.Text>().color = Color.white;
        }
        else
        {
            GetComponent<UnityEngine.UI.Text>().color = Color.yellow;
        }
    }
}