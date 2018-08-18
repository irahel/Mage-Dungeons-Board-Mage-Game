using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour {
    public int[,] campo = new int[20, 20];
    public int dimension;
    private GameObject player;
    public string atual_turn;
    public GameObject[] spawns;
    int rando;
    public GameObject nick, moves, coins, atks, turnm, life, pic;
    public string[] nicks = new string[10];

    private bool damaged;
    private float total_time;
    private float time_elapsed;
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
            
        rando = Random.Range(0, 11);
        
        nick.GetComponent<UnityEngine.UI.Text>().text = nicks[rando];

        dimension = 20;
        atual_turn = "player";
        for (int i = 0; i < 20; i++) for (int j = 0; j < 20; j++) campo[i, j] = 0;
        campo[0, 0] = 1;
        player = GameObject.FindGameObjectWithTag("Player");

        this.damaged = false;
        this.total_time = 0.1f;
        this.time_elapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {

        
        if(campo[0,13] == 1)
        {
            if(player.GetComponent<player>().coins >= 3)
            {
                Application.LoadLevel("winner");
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
    }

    public void take_dmg()
    {
        this.damaged = true;
        this.time_elapsed = 0;
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
        else
        {
            turnm.GetComponent<UnityEngine.UI.Text>().text = "E N E M Y S";
        }

        if(player.GetComponent<player>().life == 3)
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
    }
    public void change_turn()
    {
        if (atual_turn.Equals("player"))
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
        for (int i = 0; i < 20; i++) for (int j = 0; j < 20; j++) if(campo[i, j] == 1) return new int[] { i, j };
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
