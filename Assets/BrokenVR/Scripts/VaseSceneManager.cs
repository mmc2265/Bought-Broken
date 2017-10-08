using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseSceneManager : MonoBehaviour {

    private GameManager gameManager;
    public int vaseItemsDone;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (vaseItemsDone == 2)
        {
            //gameManager.FadeToBlack();
            //turn on spotlight for cell phone 
        }
		
	}
}
