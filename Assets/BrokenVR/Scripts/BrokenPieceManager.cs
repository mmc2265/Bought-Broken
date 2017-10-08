using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPieceManager : MonoBehaviour {

    public HandControllers leftController;
    public HandControllers rightController;
    private VaseSceneManager sceneManager;
    public GameObject brokenPiece;
    //public GameObject brokenPiece2;
    private AudioSource audio;
    public AudioClip groundHit;
    public AudioClip snapSound;
    //public bool piece1;
    //public bool piece2;

    public GameObject pieceSlot;
    //public GameObject pieceSlot2;

    public float upDirection;
    public Vector3 localUp;
    private Vector3 startPos;
    private Quaternion startRot;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        sceneManager = GameObject.Find("SceneManager").GetComponent<VaseSceneManager>();
        audio = GetComponent<AudioSource>();
        startPos = transform.position;
        startRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        upDirection = Vector3.Dot(transform.up, Vector3.up);
        //localUp = transform.worldToLocalMatrix.MultiplyVector(transform.up);
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (102 < upDirection || upDirection < 111)
        {
            if (piece1 == true && gameObject.tag == "Slot1")
            {
                gameObject.transform.position = pieceSlot1.transform.position;
                gameObject.transform.rotation = pieceSlot1.transform.rotation;
                rb.useGravity = false;
                rb.isKinematic = true;
                //gameObject.tag = "done";
            }
            if (piece2 == true && gameObject.tag == "Slot2"r)
            {
                gameObject.transform.position = pieceSlot2.transform.position;
                gameObject.transform.rotation = pieceSlot2.transform.rotation;
                //gameObject.tag = "done";
                rb.useGravity = false;
                rb.isKinematic = true;
            }
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (upDirection > .91f && gameObject.tag != "DoneObject")
        {
            // If other has a parent, and it is currently being grabbed, and it is interacting with the slot that it is supposed to
            if (transform.parent.tag == "LeftController" && leftController.isGrabbed && other.gameObject == pieceSlot.gameObject && gameObject.tag == "BrokenPiece")
            {
                leftController.Reset();
                gameObject.transform.SetParent(null);
                gameObject.transform.position = pieceSlot.transform.position;
                gameObject.transform.rotation = pieceSlot.transform.rotation;
                rb.useGravity = false;
                rb.isKinematic = true;
                Destroy(rb);
                sceneManager.vaseItemsDone++;
                //audio.PlayOneShot(snapSound);

                gameObject.tag = "DoneObject";
            }
            if (transform.parent.tag == "RightController" && rightController.isGrabbed && other.gameObject == pieceSlot.gameObject && gameObject.tag == "BrokenPiece")
            {
                rightController.Reset();
                gameObject.transform.SetParent(null);
                gameObject.transform.position = pieceSlot.transform.position;
                gameObject.transform.rotation = pieceSlot.transform.rotation;
                rb.useGravity = false;
                rb.isKinematic = true;
                Destroy(rb);
                sceneManager.vaseItemsDone++;
                //audio.PlayOneShot(snapSound);

                gameObject.tag = "DoneObject";
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "BrokenPiece")
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
