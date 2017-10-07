using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControllers : MonoBehaviour {

	public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    private Rigidbody rb;

    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BrokenPiece")
        {
            if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                GrabObject(other);
            }
        }

        if (other.gameObject.tag == "BrokenPiece")
        {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                ReleaseObject(other);
            }
        }
    }


    public void GrabObject(Collider coli)
    {
        coli.gameObject.transform.SetParent(gameObject.transform);

        Rigidbody coliRb = coli.gameObject.GetComponent<Rigidbody>();
        coliRb.isKinematic = true;
        coliRb.useGravity = false;
    }

    public void ReleaseObject(Collider coli)
    {
        coli.gameObject.transform.SetParent(null);

        Rigidbody coliRb = coli.gameObject.GetComponent<Rigidbody>();
        coliRb.isKinematic = false;
        coliRb.useGravity = true;
        coliRb.velocity = device.velocity;
        Debug.Log(rb.velocity);
        coliRb.angularVelocity = device.angularVelocity;
    }
}
