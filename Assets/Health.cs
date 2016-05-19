using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public int hp = 100;
    public int amount = 40;
    public bool startAttack = false;
    public bool finishAttack = false;
    public GameObject troll;
    
    Animator anim;
    MeshRenderer rend;
    Health oponentHealth;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        rend = this.GetComponent<MeshRenderer>();
    }

    public bool alive()
    {
        return hp > 0;
    }

    public void follow(Health oponent)
    {
        transform.rotation = Quaternion.LookRotation(oponent.transform.position - transform.position, Vector3.up);
    }

    public void initializeFight(Health oponent) { }
    
    public bool attacked() 
    {
        return finishAttack;
    }

    public bool attackStarted()
    {
        return startAttack;
    }

    public void attack(Health oponent)
    {
        startAttack = true;
        finishAttack = false;
        anim.SetTrigger("Attack");
        oponentHealth = oponent;
    }

    public void hit()
    {
        oponentHealth.damage(amount);
        oponentHealth.startAttack = false;
        oponentHealth.finishAttack = false;
        finishAttack = true;
    }

    public void damage(int amountHit)
    {
        hp -= amountHit;
        if (alive())
        {
            anim.SetTrigger("Impact");
        }
        else
        {
            anim.SetBool("Dead", true);
            StartCoroutine(die());
        }
    }

    public IEnumerator die()
    {
        yield return new WaitForSeconds(3);
        rend.enabled = false;
        yield return new WaitForSeconds(3);
        Instantiate(troll, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
