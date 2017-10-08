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
    private Vector3 startPos;
    private Quaternion startRot;

    public VaseSceneManager sceneManager;

    public bool isCracked = true;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        audio = GetComponent<AudioSource>();
        sceneManager = GameObject.Find("SceneManager").GetComponent<VaseSceneManager>();
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}



    private void OnTriggerStay(Collider other)
    {
        if (transform.parent != null && transform.parent.tag == "LeftController" && leftController.isGrabbed && other.gameObject == rightController.gameObject)
        {
            rend.materials = mats;
            sceneManager.cellDone = true;
        }

        if (transform.parent != null && transform.parent.tag == "RightController" && rightController.isGrabbed && other.gameObject == leftController.gameObject)
        {
            rend.materials = mats;
            sceneManager.cellDone = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            audio.PlayOneShot(groundHit);
        }

        if (collision.gameObject.tag == "Walls")
        {
            transform.position = startPos;
            transform.rotation = startRot;
        }
    }


}
