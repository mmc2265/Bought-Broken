using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPieceManager : MonoBehaviour {

    public GameObject brokenPiece;
    //public GameObject brokenPiece2;

    public bool piece1;
    public bool piece2;

    public GameObject pieceSlot1;
    public GameObject pieceSlot2;

    public float upDirection;
    Vector3 localUp;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();	


	}
	
	// Update is called once per frame
	void Update () {
        //upDirection = Vector3.Dot(transform.localRotation, Vector3.up);
        localUp = transform.worldToLocalMatrix.MultiplyVector(transform.up);
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

    private void OnCollisionEnter(Collision collision)
    {
        //if (transform.parent != null)
        {
            if (piece1 == true && collision.gameObject.tag == "Slot1")
            {
                gameObject.transform.SetParent(null);
                gameObject.transform.position = pieceSlot1.transform.position;
                gameObject.transform.rotation = pieceSlot1.transform.rotation;
                rb.useGravity = false;
                rb.isKinematic = true;
                gameObject.tag = "Player";
                Destroy(rb);
            }
            if (piece2 == true && collision.gameObject.tag == "Slot2")
            {
                gameObject.transform.position = pieceSlot2.transform.position;
                gameObject.transform.rotation = pieceSlot2.transform.rotation;
                gameObject.tag = "Player";
                rb.useGravity = false;
                rb.isKinematic = true;
                Destroy(rb);
            }
        }
    }
}
