using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseCreate : MonoBehaviour {

	public GameObject rightController;
    public Vector3 upDirection;
    public GameObject staticVaseBase;
    //public SteamVR_Controller.Device device;

    public float angle;

	public GameObject brokenVase;
	public GameObject cylinder;

	// Use this for initialization
	void Start () {
        staticVaseBase.transform.forward = upDirection;
		
	}
	
	// Update is called once per frame
	void Update () {
        //device = SteamVR_Controller.Input ((int)trackedObj.index);
       
       
	}

	private void OnTriggerStay(Collider col) {
        if (upDirection == transform.forward)
        {
            transform.position = staticVaseBase.transform.position;
        }

        /*if (col.gameObject.tag == "BrokenVase") 
		{
            cylinder.transform.position = rightController.transform.position;
            cylinder.transform.rotation = rightController.transform.rotation;
			cylinder.transform.SetParent (rightController.transform);
			cylinder.SetActive (true);
            this.gameObject.SetActive(false);
			Debug.Log ("Together");

		}*/
			
	}
		
}
