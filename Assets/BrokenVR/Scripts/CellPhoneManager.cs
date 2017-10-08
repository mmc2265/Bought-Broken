using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPhoneManager : MonoBehaviour {

    public HandControllers leftController;
    public HandControllers rightController;

    private AudioSource audio;
    public AudioClip groundHit;
    //public Material screenCrackedMaterial;
    public Material[] mats;
    //public Material screenNormalMaterial;
    private Renderer rend;

    public bool isCracked = true;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}



    private void OnTriggerStay(Collider other)
    {
        if (transform.parent != null && transform.parent.tag == "LeftController" && leftController.isGrabbed && other.gameObject == rightController.gameObject)
        {
            rend.materials = mats;
        }

        if (transform.parent != null && transform.parent.tag == "RightController" && rightController.isGrabbed && other.gameObject == leftController.gameObject)
        {
            rend.materials = mats;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            audio.PlayOneShot(groundHit);
        }
    }


}
