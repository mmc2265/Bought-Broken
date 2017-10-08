using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenObjectManager : MonoBehaviour {

    public HandControllers leftController;
    public HandControllers rightController;

    public GameObject brokenPiece;
    //public GameObject brokenPiece2;

    public bool piece1;
    public bool piece2;

    public GameObject pieceSlot1;
    public GameObject pieceSlot2;

    public float upDirection;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        upDirection = Vector3.Angle(transform.position, transform.forward);
    }

    private void OnTriggerStay(Collider other)
    {
        if(transform.parent != null && transform.parent.tag == "LeftController" && leftController.isGrabbed)

        if (102 < upDirection || upDirection < 111)
        {
            if (piece1 == true && gameObject.tag == "Slot1")
            {
                transform.SetParent(null);
                gameObject.transform.position = pieceSlot1.transform.position;
                gameObject.transform.rotation = pieceSlot1.transform.rotation;
                rb.useGravity = false;
                rb.isKinematic = true;
            }
            if (piece2 == true && gameObject.tag == "Slot2")
            {
                transform.SetParent(null);
                gameObject.transform.position = pieceSlot2.transform.position;
                gameObject.transform.rotation = pieceSlot2.transform.rotation;
                rb.useGravity = false;
                rb.isKinematic = true;
            }
        }
    }
}
