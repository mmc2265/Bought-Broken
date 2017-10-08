using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VaseSceneManager : MonoBehaviour {

    private GameManager gameManager;
    public int vaseItemsDone;
    public Light vaseLight;
    public Light cellPhoneSpot;
    //public Light roomLight1;
    public Light roomLight2;
    public Light roomLight3;
    public bool vaseDone;
    public bool cellDone;
    public bool forestSceneTransition;

    public float forestSceneTimer;
    public float lightFade;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cellPhoneSpot.enabled = false;
        //roomLight1.enabled = false;
        roomLight2.enabled = false;
        roomLight3.enabled = false;

        cellPhoneSpot.intensity = 0;
        //roomLight1.intensity = 0;

        roomLight2.intensity = 0;
        roomLight3.intensity = 0;

        vaseLight.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {

        vaseLight.intensity = Mathf.Lerp(vaseLight.intensity, 6, Time.deltaTime / lightFade);

        if (vaseItemsDone == 2)
        {
            vaseDone = true;
        }

        if (vaseDone)
        {
            cellPhoneSpot.enabled = true;
            cellPhoneSpot.intensity = Mathf.Lerp(cellPhoneSpot.intensity, 6, Time.deltaTime / 2);
            vaseLight.intensity = Mathf.LerpUnclamped(vaseLight.intensity, 1, Time.deltaTime / 2);
        }

        if (cellDone)
        {
            //roomLight1.enabled = true;
            //roomLight1.intensity = Mathf.Lerp(0, 6, Time.deltaTime);

            roomLight2.enabled = true;
            roomLight2.intensity = Mathf.Lerp(roomLight2.intensity, 6, Time.deltaTime / lightFade);

            roomLight3.enabled = true;
            roomLight3.intensity = Mathf.Lerp(roomLight3.intensity, 6, Time.deltaTime / lightFade);

            vaseLight.intensity = Mathf.LerpUnclamped(vaseLight.intensity, 4, Time.deltaTime / lightFade);
            cellPhoneSpot.intensity = Mathf.Lerp(cellPhoneSpot.intensity, 4, Time.deltaTime / lightFade);

            forestSceneTimer -= Time.deltaTime;
        }

        if (forestSceneTimer <= 0 && !forestSceneTransition)
        {
            //gameManager.FadeToBlack();
            SceneManager.LoadScene(1);
            forestSceneTransition = true;
        }

    }
}
