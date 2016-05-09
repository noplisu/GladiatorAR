using UnityEngine;
using System.Collections;

public class frezeDeath : MonoBehaviour {
    Animator anim;

	void Start () {
        anim = this.GetComponent<Animator>();
	}

    public void pause()
    {
        anim.speed = 0;
    }
}
