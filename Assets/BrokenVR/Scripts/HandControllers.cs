using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControllers : MonoBehaviour {

	public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    private Rigidbody rb;
    public bool isGrabbed;
    public GameObject grabbedObject;
    //public GameManager gameManager;
    public GameObject handModels;

    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per framer
	void Update () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);

        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BrokenPiece" && isGrabbed == false)
        {
            if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                GrabObject(other);
            }
        }

        if (other.gameObject.tag == "Phone" && isGrabbed == false)
        {
            if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                GrabPhone(other);

            }
        }

        if (other.gameObject.tag == "BrokenPiece" && isGrabbed == true)
        {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                ReleaseObject(other);
            }
        }

        if (other.gameObject.tag == "Phone" && isGrabbed == true)
        {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                ReleasePhone(other);
            }
        }
    }


    public void GrabObject(Collider coli)
    {
        isGrabbed = true;
        coli.gameObject.transform.SetParent(gameObject.transform);
        //coli.gameObject.transform.rotation = transform.rotation;

        if (coli.gameObject.GetComponent<Rigidbody>())
        {
            Rigidbody coliRb = coli.gameObject.GetComponent<Rigidbody>();
            coliRb.isKinematic = true;
            coliRb.useGravity = false;
        }
        
        //handModels.SetActive(false);

        coli.GetComponent<CapsuleCollider>().isTrigger = true;
    }

    public void ReleaseObject(Collider coli)
    {
        isGrabbed = false;
        coli.gameObject.transform.SetParent(null);
        if (coli.gameObject.GetComponent<Rigidbody>())
        {
            Rigidbody coliRb = coli.gameObject.GetComponent<Rigidbody>();

            coliRb.isKinematic = false;
            coliRb.useGravity = true;
            coliRb.velocity = device.velocity;
            coliRb.angularVelocity = device.angularVelocity;
        }

        //Debug.Log(rb.velocity);
        //handModels.SetActive(true);

        coli.GetComponent<CapsuleCollider>().isTrigger = false;

    }

    public void GrabPhone(Collider coli)
    {
        isGrabbed = true;
        coli.gameObject.transform.SetParent(gameObject.transform);

        if (coli.gameObject.GetComponent<Rigidbody>())
        {
            Rigidbody coliRb = coli.gameObject.GetComponent<Rigidbody>();
            coliRb.isKinematic = true;
            coliRb.useGravity = false;

        }
      

        coli.transform.localPosition = new Vector3(0, 0.03f, 0.03f);
        coli.transform.localRotation = Quaternion.Euler(3.42f, 180, 2.3f);
        coli.GetComponent<BoxCollider>().isTrigger = true;

        handModels.SetActive(false);

    }

    public void ReleasePhone(Collider coli)
    {
        isGrabbed = false;
        coli.gameObject.transform.SetParent(null);
        Rigidbody coliRb = coli.gameObject.GetComponent<Rigidbody>();
        coliRb.isKinematic = false;
        coliRb.useGravity = true;
        coliRb.velocity = device.velocity;
        //Debug.Log(rb.velocity);
        coliRb.angularVelocity = device.angularVelocity;

        coli.GetComponent<BoxCollider>().isTrigger = false;

        handModels.SetActive(true);
    }

    public void Reset()
    {
        isGrabbed = false;
        grabbedObject = null;
        handModels.SetActive(true);
    }
}
