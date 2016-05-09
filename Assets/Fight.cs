using UnityEngine;
using System.Collections;

public class Fight : MonoBehaviour {
    Health player;
    Health enemy;

    int turn = 0;
    bool fightStarted = false;

    void Start()
    {
        player = GetComponent<Health>();
    }

    void Update()
    {
        if (enemy && enemy.alive() && player.alive())
        {
            enemy.follow(player);
            player.follow(enemy);
            if (!fightStarted)
            {
                enemy.initializeFight(player);
                player.initializeFight(enemy);
                fightStarted = true;
            }
            if (turn % 2 == 0)
            {
                if(player.attacked())
                {
                    turn++;
                }
                else if(!player.attackStarted())
                {
                    player.attack(enemy);
                }
            }
            else
            {
                if (enemy.attacked())
                {
                    turn++;
                }
                else if (!enemy.attackStarted())
                {
                    enemy.attack(player);
                }
            }
            print(turn);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemy = other.GetComponent<Health>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemy = null;
        }
    }
}
