using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int phase = 1;
    public GameObject tabuleiro;
    public int i, j;
    public float step;

    public bool movebool;
    private float t = 0.4f, e;

    public int max_moves;
    //private int moves;
    public int moves;

    public enum behaviours {line_first, colum_first, random }
    public behaviours behaviour;

    public float totaltime, elapsed;

    private GameObject player, player2;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        phase = player.GetComponent<player>().phase;
        if (phase == 1)
        {
            tabuleiro = GameObject.FindGameObjectWithTag("tab");
            movebool = true;
            tabuleiro.GetComponent<game>().campo[i, j] = 2;
            float behaviour_rand = Random.Range(0, 9);
            if (behaviour_rand < 3) behaviour = behaviours.line_first;
            else if (behaviour_rand < 6) behaviour = behaviours.colum_first;
            else behaviour = behaviours.random;
        }
        else
        {
            tabuleiro = GameObject.FindGameObjectWithTag("tab");
            movebool = true;
            tabuleiro.GetComponent<game2>().campo[i, j] = 2;
            float behaviour_rand = Random.Range(0, 9);
            if (behaviour_rand < 3) behaviour = behaviours.line_first;
            else if (behaviour_rand < 6) behaviour = behaviours.colum_first;
            else behaviour = behaviours.random;
            player2 = GameObject.FindGameObjectWithTag("Player2");
        }
 
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (phase == 1)
        {
            if (tabuleiro.GetComponent<game>().atual_turn.Equals("enemy"))
            {
                elapsed += Time.deltaTime;
                if (elapsed >= totaltime)
                {
                    elapsed = 0;
                    tabuleiro.GetComponent<game>().change_turn();

                }
                if (!movebool)
                {
                    e += Time.deltaTime;
                    if (e >= t)
                    {
                        movebool = true;
                        e = 0;
                    }
                }
                if (movebool)
                {
                    go_move();
                    movebool = false;
                }
            }
            if (moves == max_moves)
            {
                tabuleiro.GetComponent<game>().change_turn();
                moves = 0;
                elapsed = 0;
            }
        }
        else
        {
            if (tabuleiro.GetComponent<game2>().atual_turn.Equals("enemy"))
            {
                elapsed += Time.deltaTime;
                if (elapsed >= totaltime)
                {
                    elapsed = 0;
                    tabuleiro.GetComponent<game2>().change_turn();

                }
                if (!movebool)
                {
                    e += Time.deltaTime;
                    if (e >= t)
                    {
                        movebool = true;
                        e = 0;
                    }
                }
                if (movebool)
                {
                    go_move();
                    movebool = false;
                }
            }
            if (moves == max_moves)
            {
                tabuleiro.GetComponent<game2>().change_turn();
                moves = 0;
                elapsed = 0;
            }
        }
       
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
    void new_turn()
    {
        moves = 0;
        //atks = 0;
    }

    void go_move()
    {
        if (phase == 1)
        {
            if (moves < max_moves)
            {
                if (behaviour == behaviours.line_first)
                {
                    int[] player_position = tabuleiro.GetComponent<game>().player_find();
                    if (i < player_position[0])
                    {
                        if (possible_move("down"))
                        {
                            transform.Translate(Vector2.down * step);
                            i++;
                            moves++;
                            tabuleiro.GetComponent<game>().enemy_move(i - 1, j, i, j);
                        }
                    }
                    else if (i > player_position[0])
                    {
                        if (possible_move("up"))
                        {
                            transform.Translate(Vector2.up * step);
                            i--;
                            moves++;
                            tabuleiro.GetComponent<game>().enemy_move(i + 1, j, i, j);
                        }
                    }
                    else
                    {
                        if (j < player_position[1] - 1)
                        {
                            if (possible_move("right"))
                            {
                                transform.Translate(Vector2.right * step);
                                j++;
                                moves++;
                                tabuleiro.GetComponent<game>().enemy_move(i, j - 1, i, j);
                            }
                        }
                        else if (j > player_position[1] + 1)
                        {
                            if (possible_move("left"))
                            {
                                transform.Translate(Vector2.left * step);
                                j--;
                                moves++;
                                tabuleiro.GetComponent<game>().enemy_move(i, j + 1, i, j);
                            }
                        }
                        else
                        {
                            player.GetComponent<player>().take_damage();
                            moves++;
                        }
                    }
                }
                else if (behaviour == behaviours.colum_first)
                {
                    int[] player_position = tabuleiro.GetComponent<game>().player_find();
                    if (j < player_position[1] - 1)
                    {
                        if (possible_move("right"))
                        {
                            transform.Translate(Vector2.right * step);
                            j++;
                            moves++;
                            tabuleiro.GetComponent<game>().enemy_move(i, j - 1, i, j);
                        }
                    }
                    else if (j > player_position[1] + 1)
                    {
                        if (possible_move("left"))
                        {
                            transform.Translate(Vector2.left * step);
                            j--;
                            moves++;
                            tabuleiro.GetComponent<game>().enemy_move(i, j + 1, i, j);
                        }
                    }
                    else
                    {
                        if (i < player_position[0])
                        {
                            if (possible_move("down"))
                            {
                                transform.Translate(Vector2.down * step);
                                i++;
                                moves++;
                                tabuleiro.GetComponent<game>().enemy_move(i - 1, j, i, j);
                            }
                        }
                        else if (i > player_position[0])
                        {
                            if (possible_move("up"))
                            {
                                transform.Translate(Vector2.up * step);
                                i--;
                                moves++;
                                tabuleiro.GetComponent<game>().enemy_move(i + 1, j, i, j);
                            }
                        }
                        else
                        {
                            player.GetComponent<player>().take_damage();
                            moves++;
                        }

                    }

                }
                else if (behaviour == behaviours.random)
                {
                    float rand = Random.Range(0, 10);
                    if (rand < 5)
                    {
                        rand = Random.Range(0, 10);
                        if (rand < 5)
                        {
                            if (possible_move("right"))
                            {
                                transform.Translate(Vector2.right * step);
                                j++;
                                moves++;
                                tabuleiro.GetComponent<game>().enemy_move(i, j - 1, i, j);
                            }
                        }
                        else
                        {
                            if (possible_move("left"))
                            {
                                transform.Translate(Vector2.left * step);
                                j--;
                                moves++;
                                tabuleiro.GetComponent<game>().enemy_move(i, j + 1, i, j);
                            }
                        }
                    }
                    else
                    {
                        rand = Random.Range(0, 10);
                        if (rand < 5)
                        {
                            if (possible_move("up"))
                            {
                                transform.Translate(Vector2.up * step);
                                i--;
                                moves++;
                                tabuleiro.GetComponent<game>().enemy_move(i + 1, j, i, j);
                            }
                        }
                        else
                        {
                            if (possible_move("down"))
                            {
                                transform.Translate(Vector2.down * step);
                                i++;
                                moves++;
                                tabuleiro.GetComponent<game>().enemy_move(i - 1, j, i, j);
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (moves < max_moves)
            {
                if (behaviour == behaviours.line_first)
                {
                    int[] player_position = tabuleiro.GetComponent<game2>().player_find();
                    if (i < player_position[0])
                    {
                        if (possible_move("down"))
                        {
                            transform.Translate(Vector2.down * step);
                            i++;
                            moves++;
                            tabuleiro.GetComponent<game2>().enemy_move(i - 1, j, i, j);
                        }
                    }
                    else if (i > player_position[0])
                    {
                        if (possible_move("up"))
                        {
                            transform.Translate(Vector2.up * step);
                            i--;
                            moves++;
                            tabuleiro.GetComponent<game2>().enemy_move(i + 1, j, i, j);
                        }
                    }
                    else
                    {
                        if (j < player_position[1] - 1)
                        {
                            if (possible_move("right"))
                            {
                                transform.Translate(Vector2.right * step);
                                j++;
                                moves++;
                                tabuleiro.GetComponent<game2>().enemy_move(i, j - 1, i, j);
                            }
                        }
                        else if (j > player_position[1] + 1)
                        {
                            if (possible_move("left"))
                            {
                                transform.Translate(Vector2.left * step);
                                j--;
                                moves++;
                                tabuleiro.GetComponent<game2>().enemy_move(i, j + 1, i, j);
                            }
                        }
                        else
                        {
                            if (player.GetComponent<player>().i == i -1)
                            {
                                player.GetComponent<player>().take_damage();
                            }
                            else if (player.GetComponent<player>().i == i + 1)
                            {
                                player.GetComponent<player>().take_damage();
                            }
                            else if (player.GetComponent<player>().j == j - 1)
                            {
                                player.GetComponent<player>().take_damage();
                            }
                            else if (player.GetComponent<player>().j == j + 1)
                            {
                                player.GetComponent<player>().take_damage();
                            }
                            else
                            {
                                player2.GetComponent<player2>().take_damage();
                            }                            
                            moves++;
                        }
                    }
                }
                else if (behaviour == behaviours.colum_first)
                {
                    int[] player_position = tabuleiro.GetComponent<game2>().player_find();
                    if (j < player_position[1] - 1)
                    {
                        if (possible_move("right"))
                        {
                            transform.Translate(Vector2.right * step);
                            j++;
                            moves++;
                            tabuleiro.GetComponent<game2>().enemy_move(i, j - 1, i, j);
                        }
                    }
                    else if (j > player_position[1] + 1)
                    {
                        if (possible_move("left"))
                        {
                            transform.Translate(Vector2.left * step);
                            j--;
                            moves++;
                            tabuleiro.GetComponent<game2>().enemy_move(i, j + 1, i, j);
                        }
                    }
                    else
                    {
                        if (i < player_position[0])
                        {
                            if (possible_move("down"))
                            {
                                transform.Translate(Vector2.down * step);
                                i++;
                                moves++;
                                tabuleiro.GetComponent<game2>().enemy_move(i - 1, j, i, j);
                            }
                        }
                        else if (i > player_position[0])
                        {
                            if (possible_move("up"))
                            {
                                transform.Translate(Vector2.up * step);
                                i--;
                                moves++;
                                tabuleiro.GetComponent<game2>().enemy_move(i + 1, j, i, j);
                            }
                        }
                        else
                        {
                            if (player.GetComponent<player>().i == i - 1)
                            {
                                player.GetComponent<player>().take_damage();
                            }
                            else if (player.GetComponent<player>().i == i + 1)
                            {
                                player.GetComponent<player>().take_damage();
                            }
                            else if (player.GetComponent<player>().j == j - 1)
                            {
                                player.GetComponent<player>().take_damage();
                            }
                            else if (player.GetComponent<player>().j == j + 1)
                            {
                                player.GetComponent<player>().take_damage();
                            }
                            else
                            {
                                player2.GetComponent<player2>().take_damage();
                            }
                            moves++;
                        }

                    }

                }
                else if (behaviour == behaviours.random)
                {
                    float rand = Random.Range(0, 10);
                    if (rand < 5)
                    {
                        rand = Random.Range(0, 10);
                        if (rand < 5)
                        {
                            if (possible_move("right"))
                            {
                                transform.Translate(Vector2.right * step);
                                j++;
                                moves++;
                                tabuleiro.GetComponent<game2>().enemy_move(i, j - 1, i, j);
                            }
                        }
                        else
                        {
                            if (possible_move("left"))
                            {
                                transform.Translate(Vector2.left * step);
                                j--;
                                moves++;
                                tabuleiro.GetComponent<game2>().enemy_move(i, j + 1, i, j);
                            }
                        }
                    }
                    else
                    {
                        rand = Random.Range(0, 10);
                        if (rand < 5)
                        {
                            if (possible_move("up"))
                            {
                                transform.Translate(Vector2.up * step);
                                i--;
                                moves++;
                                tabuleiro.GetComponent<game2>().enemy_move(i + 1, j, i, j);
                            }
                        }
                        else
                        {
                            if (possible_move("down"))
                            {
                                transform.Translate(Vector2.down * step);
                                i++;
                                moves++;
                                tabuleiro.GetComponent<game2>().enemy_move(i - 1, j, i, j);
                            }
                        }
                    }
                }
            }
        }
        
    }
}
