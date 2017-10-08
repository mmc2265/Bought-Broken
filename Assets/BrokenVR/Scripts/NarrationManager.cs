using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationManager : MonoBehaviour {

    public VaseSceneManager sceneManager;
    private AudioSource audio;
    public AudioClip[] clips;

    public bool afterVase;
    public bool beforePhone = true;
    public float beforePhoneTimer;
    public bool afterPhone;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        sceneManager = GameObject.Find("SceneManager").GetComponent<VaseSceneManager>();

        audio.PlayOneShot(clips[0]);
        beforePhoneTimer = clips[1].length;

    }

    // Update is called once per frame
    void Update () {
        if (sceneManager.vaseDone && !afterVase)
        {
            audio.Stop();
            audio.PlayOneShot(clips[1]);
            
            afterVase = true;
        }

        if (afterVase && beforePhoneTimer >= -1)
        {
            beforePhoneTimer -= Time.deltaTime;
            
        }

        if (afterVase && beforePhone && beforePhoneTimer < -1)
        {
            audio.Stop();
            audio.PlayOneShot(clips[2]);
            beforePhone = false;
        }

        

        if (sceneManager.cellDone && !afterPhone && !beforePhone)
        {
            audio.Stop();
            audio.PlayOneShot(clips[3]);
            afterPhone = true;
        }
		
	}
}
