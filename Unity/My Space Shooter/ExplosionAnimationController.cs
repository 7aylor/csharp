using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimationController : MonoBehaviour {

    Animator explosion;

	// Use this for initialization
	void Start () {
        explosion = GetComponent<Animator>();
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
	
}
