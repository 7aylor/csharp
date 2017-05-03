using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcebergStateController : MonoBehaviour {

    Animator anim;
    public int time;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        StartCoroutine(timeKeeper());
	}

    private IEnumerator timeKeeper()
    {
        for (int i = 1; i <= time; i++)
        {
            anim.SetInteger("Time", i);
            yield return new WaitForSeconds(1f);
        }
        
    }
}
