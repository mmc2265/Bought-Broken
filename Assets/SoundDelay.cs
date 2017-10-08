using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDelay : MonoBehaviour {

    private AudioSource audio;
    public float delay;

	// Use this for initialization
	void Start () {

        audio = GetComponent<AudioSource>();
        audio.PlayDelayed(delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
