using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mage_atk : MonoBehaviour
{
    public int phase;
    public float step, dead_time;
    public enum type { E, D, C, B, NON_SELECTED }
    public type type_atk;
	// Use this for initialization
	void Start ()
    {
        phase = GameObject.FindGameObjectWithTag("Player").GetComponent<player>().phase;
        Destroy(gameObject, dead_time);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(type_atk != type.NON_SELECTED)
        {
            if(type_atk == type.E)
            {
                transform.Translate(Vector2.left * step);
            }
            if (type_atk == type.D)
            {
                transform.Translate(Vector2.right * step);
            }
            if (type_atk == type.C)
            {
                transform.Translate(Vector2.up * step);
            }
            if (type_atk == type.B)
            {
                transform.Translate(Vector2.down * step);
            }
        }
		
	}

    public void esq()
    {
        type_atk = type.E;
    }
    public void dir()
    {
        type_atk = type.D;
    }
    public void baix()
    {
        type_atk = type.B;
    }
    public void cim()
    {
        type_atk = type.C;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(phase == 1)
        {

            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
                GameObject.FindGameObjectWithTag("tab").GetComponent<game>().death(collision.gameObject.GetComponent<enemy>().i, collision.gameObject.GetComponent<enemy>().j);
                Destroy(collision.gameObject);
            }
        }
        else
        {

            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
                GameObject.FindGameObjectWithTag("tab").GetComponent<game2>().death(collision.gameObject.GetComponent<enemy>().i, collision.gameObject.GetComponent<enemy>().j);
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.tag == "Player")
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<player>().take_damage();
            }

            if (collision.gameObject.tag == "Player2")
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<player2>().take_damage();
            }
        }
    }
}
