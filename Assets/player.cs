using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public enum turn { Player, Enemy };
    public GameObject tabuleiro;
    public int phase = 1;
    public float step;
    public int i, j;
    public int max_moves;
    //private int moves;
    public int moves;

    public int max_atks;
    //private int atks;
    public int atks;
    public int coins;
    
    public GameObject mage_atk_d, mage_atk_e, mage_atk_c, mage_atk_b;

    public float adjust_d, adjust_e, adjust_c, adjust_b;

    public int life;
    // Use this for initialization
    void Start ()
    {
        coins = 0;
        life = 3;
        i = 0;
        j = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (phase == 1)
        {
            if (life == 0)
             {
                Application.LoadLevel("loser");
             }
       
            if (tabuleiro.GetComponent<game>().atual_turn.Equals("player"))
            {
                move_controller();
                atk_controller();
                if (Input.GetKeyDown("b")) tabuleiro.GetComponent<game>().change_turn();
            }
        }
        else
        {

            if (life == 0)
            {
                Application.LoadLevel("loserp1");
            }
            if (tabuleiro.GetComponent<game2>().atual_turn.Equals("player"))
            {
                move_controller();
                atk_controller();
                if (Input.GetKeyDown("b")) tabuleiro.GetComponent<game2>().change_turn();
            }
        }
             

    }

    public void new_turn()
    {
        moves = 0;
        atks = 0;
    }

    bool possible_move(string move)
    {
        if (phase == 1)
        {
            if (move == "up")
            {
                if ((i - 1) < 0) return false;
                else if (tabuleiro.GetComponent<game>().campo[i - 1, j] != 0) return false;
            }
            else if (move == "down")
            {
                if ((i + 1) >= tabuleiro.GetComponent<game>().dimension) return false;
                else if (tabuleiro.GetComponent<game>().campo[i + 1, j] != 0) return false;
            }
            else if (move == "left")
            {
                if ((j - 1) < 0) return false;
                else if (tabuleiro.GetComponent<game>().campo[i, j - 1] != 0) return false;
            }
            else if (move == "right")
            {
                if ((j + 1) >= tabuleiro.GetComponent<game>().dimension) return false;
                else if (tabuleiro.GetComponent<game>().campo[i, j + 1] != 0) return false;
            }
        }
        else
        {
            if (move == "up")
            {
                if ((i - 1) < 0) return false;
                else if (tabuleiro.GetComponent<game2>().campo[i - 1, j] != 0) return false;
            }
            else if (move == "down")
            {
                if ((i + 1) >= tabuleiro.GetComponent<game2>().dimension) return false;
                else if (tabuleiro.GetComponent<game2>().campo[i + 1, j] != 0) return false;
            }
            else if (move == "left")
            {
                if ((j - 1) < 0) return false;
                else if (tabuleiro.GetComponent<game2>().campo[i, j - 1] != 0) return false;
            }
            else if (move == "right")
            {
                if ((j + 1) >= tabuleiro.GetComponent<game2>().dimension) return false;
                else if (tabuleiro.GetComponent<game2>().campo[i, j + 1] != 0) return false;
            }
        }
        
                                                                            return true;
    }

    public void take_damage()
    {
        life--;
        if (phase == 1)
        {
            tabuleiro.GetComponent<game>().take_dmg();
        }
        else
        {
            tabuleiro.GetComponent<game2>().take_dmg(1);
        }
    }

    void move_controller()
    {
        if (phase == 1)
        {
            if (moves < max_moves)
            {
                if (Input.GetKeyDown("d"))
                {
                    if (possible_move("right"))
                    {
                        GetComponent<Transform>().Translate(Vector2.right * step);
                        moves++;
                        j++;
                        tabuleiro.GetComponent<game>().player_move(i, j - 1, i, j);
                    }
                    else
                    {
                        print("impossible move");
                    }
                }
                if (Input.GetKeyDown("a"))
                {
                    if (possible_move("left"))
                    {
                        GetComponent<Transform>().Translate(Vector2.left * step);
                        moves++;
                        j--;
                        tabuleiro.GetComponent<game>().player_move(i, j + 1, i, j);
                    }
                    else
                    {
                        print("impossible move");
                    }
                }
                if (Input.GetKeyDown("w"))
                {
                    if (possible_move("up"))
                    {
                        GetComponent<Transform>().Translate(Vector2.up * step);
                        moves++;
                        i--;
                        tabuleiro.GetComponent<game>().player_move(i + 1, j, i, j);
                    }
                    else
                    {
                        print("impossible move");
                    }

                }
                if (Input.GetKeyDown("s"))
                {
                    if (possible_move("down"))
                    {
                        GetComponent<Transform>().Translate(Vector2.down * step);
                        moves++;
                        i++;
                        tabuleiro.GetComponent<game>().player_move(i - 1, j, i, j);
                    }
                    else
                    {
                        print("impossible move");
                    }
                }
            }
        }
        else
        {
            if (moves < max_moves)
            {
                if (Input.GetKeyDown("d"))
                {
                    if (possible_move("right"))
                    {
                        GetComponent<Transform>().Translate(Vector2.right * step);
                        moves++;
                        j++;
                        tabuleiro.GetComponent<game2>().player_move(i, j - 1, i, j);
                    }
                    else
                    {
                        print("impossible move");
                    }
                }
                if (Input.GetKeyDown("a"))
                {
                    if (possible_move("left"))
                    {
                        GetComponent<Transform>().Translate(Vector2.left * step);
                        moves++;
                        j--;
                        tabuleiro.GetComponent<game2>().player_move(i, j + 1, i, j);
                    }
                    else
                    {
                        print("impossible move");
                    }
                }
                if (Input.GetKeyDown("w"))
                {
                    if (possible_move("up"))
                    {
                        GetComponent<Transform>().Translate(Vector2.up * step);
                        moves++;
                        i--;
                        tabuleiro.GetComponent<game2>().player_move(i + 1, j, i, j);
                    }
                    else
                    {
                        print("impossible move");
                    }

                }
                if (Input.GetKeyDown("s"))
                {
                    if (possible_move("down"))
                    {
                        GetComponent<Transform>().Translate(Vector2.down * step);
                        moves++;
                        i++;
                        tabuleiro.GetComponent<game2>().player_move(i - 1, j, i, j);
                    }
                    else
                    {
                        print("impossible move");
                    }
                }
            }
        }
       
    }

    void atk_controller()
    {
        if (atks < max_atks)
        {
            if (Input.GetKeyDown("l"))
            {
                Instantiate(mage_atk_d, transform.position + new Vector3(adjust_d, 0, 0), transform.rotation);               
                atks++;
            }
            if (Input.GetKeyDown("j"))
            {
                Instantiate(mage_atk_e, transform.position + new Vector3(adjust_e, 0, 0), transform.rotation);
                atks++;
            }
            if (Input.GetKeyDown("i"))
            {
                Instantiate(mage_atk_c, transform.position + new Vector3(0, adjust_c, 0), transform.rotation);
                atks++;
            }
            if (Input.GetKeyDown("k"))
            {
                Instantiate(mage_atk_b, transform.position + new Vector3(0, adjust_b, 0), transform.rotation);
                atks++;
            }
        }
    }
}
