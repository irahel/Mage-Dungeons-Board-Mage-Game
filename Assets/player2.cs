using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour {
    public enum turn { Player, Enemy };
    public GameObject tabuleiro;

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
    void Start()
    {
        coins = 0;
        life = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life == 0)
        {
            Application.LoadLevel("loserp2");
        }

        if (tabuleiro.GetComponent<game2>().atual_turn.Equals("player2"))
        {
            move_controller();
            atk_controller();
            if (Input.GetKeyDown("b")) tabuleiro.GetComponent<game2>().change_turn();
        }

    }

    public void new_turn()
    {
        moves = 0;
        atks = 0;
    }

    bool possible_move(string move)
    {
        if (move == "up")
        {
            if ((i - 1) < 0) return false;
            else if (tabuleiro.GetComponent<game2>().campo[i - 1, j] != 0) return false;
        }
        else if (move == "down")
        {
            print(tabuleiro.GetComponent<game2>().dimension);
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
        return true;
    }

    public void take_damage()
    {
        life--;
        tabuleiro.GetComponent<game2>().take_dmg(2);
    }

    void move_controller()
    {
        if (moves < max_moves)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
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
            if (Input.GetKeyDown(KeyCode.LeftArrow))
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
            if (Input.GetKeyDown(KeyCode.UpArrow))
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
            if (Input.GetKeyDown(KeyCode.DownArrow))
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

    void atk_controller()
    {
        if (atks < max_atks)
        {
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                Instantiate(mage_atk_d, transform.position + new Vector3(adjust_d, 0, 0), transform.rotation);
                atks++;
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                Instantiate(mage_atk_e, transform.position + new Vector3(adjust_e, 0, 0), transform.rotation);
                atks++;
            }
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                Instantiate(mage_atk_c, transform.position + new Vector3(0, adjust_c, 0), transform.rotation);
                atks++;
            }
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                Instantiate(mage_atk_b, transform.position + new Vector3(0, adjust_b, 0), transform.rotation);
                atks++;
            }
        }
    }
}
