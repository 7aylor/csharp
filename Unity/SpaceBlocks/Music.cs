using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    private static Music music = null;

	// Use this for initialization
	private void Awake () {
        if (music != null)
        {
            Destroy(gameObject);
        }
        else
        {
            music = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
	
}
