using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game2 : MonoBehaviour {
    public int[,] campo = new int[20, 20];
    public int dimension;
    private GameObject player, player2;
    public string atual_turn;
    public GameObject[] spawns;
    int rando, rando2;
    public GameObject nick, moves, coins, atks, turnm, life, pic;
    public GameObject nick2, moves2, coins2, atks2, turnm2, life2, pic2;
    public string[] nicks = new string[10];

    private bool damaged;
    private bool damaged2;
    private float total_time;
    private float time_elapsed;
    private float time_elapsed2;

    
    // Use this for initialization
    void Start()
    {
        nicks[0] = "Mano Brown";
        nicks[1] = "Afonsinho";
        nicks[2] = "Grauco";
        nicks[3] = "Hugi";
        nicks[4] = "Dig Din";
        nicks[5] = "Zé piqueno";
        nicks[6] = "Pepe Moreno";
        nicks[7] = "Weber";
        nicks[8] = "Bolsonaro";
        nicks[9] = "Ze cleudo";

        rando = Random.Range(0, 10);
        rando2 = Random.Range(0, 10);
        
        nick.GetComponent<UnityEngine.UI.Text>().text = nicks[rando];
        nick2.GetComponent<UnityEngine.UI.Text>().text = nicks[rando2];

        dimension = 20;
        atual_turn = "player";
        for (int i = 0; i < 20; i++) for (int j = 0; j < 20; j++) campo[i, j] = 0;
        campo[0, 0] = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        this.damaged = false;
        this.total_time = 0.1f;
        this.time_elapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if (campo[0, 13] == 1)
        {
            //print("alguem no fim");
            if (player.GetComponent<player>().i == 0 && player.GetComponent<player>().j == 13)
            {
                //print("hehe");
                if (player.GetComponent<player>().coins >= 2)
                {
                    
                    Application.LoadLevel("loserp2");
                }
                
            }
            if (player2.GetComponent<player2>().i == 0 && player2.GetComponent<player2>().j == 13)
            {
                if (player2.GetComponent<player2>().coins >= 2)
                {
                    Application.LoadLevel("loserp1");
                }

            }
        }
        updateUI();

        if (this.damaged)
        {
            pic.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        else
        {
            pic.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
        this.time_elapsed += Time.deltaTime;
        if ((this.time_elapsed >= this.total_time) && this.damaged)
        {
            damaged = false;
            this.time_elapsed = 0;
        }

        if (this.damaged2)
        {
            pic2.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        else
        {
            pic2.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
        this.time_elapsed2 += Time.deltaTime;
        if ((this.time_elapsed2 >= this.total_time) && this.damaged2)
        {
            damaged2 = false;
            this.time_elapsed2 = 0;
        }
    }

    public void take_dmg(int baitola)
    {
        if(baitola == 1)
        {
            this.damaged = true;
            this.time_elapsed = 0;
        }
        else
        {
            this.damaged2 = true;
            this.time_elapsed2 = 0;
        }
        
    }

    void updateUI()
    {
        life.GetComponent<UnityEngine.UI.Text>().text = "Life: " + player.GetComponent<player>().life;
        moves.GetComponent<UnityEngine.UI.Text>().text = "Moves: " + (player.GetComponent<player>().max_moves - player.GetComponent<player>().moves);
        atks.GetComponent<UnityEngine.UI.Text>().text = "Atks: " + (player.GetComponent<player>().max_atks - player.GetComponent<player>().atks);
        coins.GetComponent<UnityEngine.UI.Text>().text = "Coins: " + player.GetComponent<player>().coins;

        if (atual_turn.Equals("player"))
        {
            turnm.GetComponent<UnityEngine.UI.Text>().text = "Y O U";
        }
        else if (atual_turn.Equals("enemy"))
        {
            turnm.GetComponent<UnityEngine.UI.Text>().text = "E N E M Y S";
        }
        else
        {
            turnm.GetComponent<UnityEngine.UI.Text>().text = "P L A Y E R  2";
        }

        if (player.GetComponent<player>().life == 3)
        {
            life.GetComponent<UnityEngine.UI.Text>().color = Color.green;
        }
        else if (player.GetComponent<player>().life == 2)
        {
            life.GetComponent<UnityEngine.UI.Text>().color = Color.yellow;
        }
        else
        {
            life.GetComponent<UnityEngine.UI.Text>().color = Color.red;
        }

        life2.GetComponent<UnityEngine.UI.Text>().text = "Life: " + player2.GetComponent<player2>().life;
        moves2.GetComponent<UnityEngine.UI.Text>().text = "Moves: " + (player2.GetComponent<player2>().max_moves - player2.GetComponent<player2>().moves);
        atks2.GetComponent<UnityEngine.UI.Text>().text = "Atks: " + (player2.GetComponent<player2>().max_atks - player2.GetComponent<player2>().atks);
        coins2.GetComponent<UnityEngine.UI.Text>().text = "Coins: " + player2.GetComponent<player2>().coins;

        if (atual_turn.Equals("player2"))
        {
            turnm2.GetComponent<UnityEngine.UI.Text>().text = "Y O U";
        }   
        else if (atual_turn.Equals("enemy"))
        {
            turnm2.GetComponent<UnityEngine.UI.Text>().text = "E N E M Y S";
        }
        else
        {
            turnm2.GetComponent<UnityEngine.UI.Text>().text = "P L A Y E R  1";
        }

        if (player2.GetComponent<player2>().life == 3)
        {
            life2.GetComponent<UnityEngine.UI.Text>().color = Color.green;
        }
        else if (player2.GetComponent<player2>().life == 2)
        {
            life2.GetComponent<UnityEngine.UI.Text>().color = Color.yellow;
        }
        else
        {
            life2.GetComponent<UnityEngine.UI.Text>().color = Color.red;
        }
    }
    public void change_turn()
    {
        if (atual_turn.Equals("player"))
        {
            atual_turn = "player2";
            player2.GetComponent<player2>().new_turn();
        }
        else if(atual_turn.Equals("player2"))
        {
            atual_turn = "enemy";
            foreach (GameObject element in spawns)
            {
                element.GetComponent<spawnkeleto>().spawn();
            }
        }
        else
        {
            atual_turn = "player";
            player.GetComponent<player>().new_turn();
        }
    }



    public int[] player_find()
    {
        for (int i = 0; i < 20; i++) for (int j = 0; j < 20; j++) if (campo[i, j] == 1) return new int[] { i, j };
        return new int[] { 0 };
    }

    public void player_move(int back_i, int back_j, int new_i, int new_j)
    {
        campo[back_i, back_j] = 0;
        campo[new_i, new_j] = 1;
    }
    public void enemy_move(int back_i, int back_j, int new_i, int new_j)
    {
        campo[back_i, back_j] = 0;
        campo[new_i, new_j] = 2;
    }

    public void death(int i, int j)
    {
        campo[i, j] = 0;
    }

}
