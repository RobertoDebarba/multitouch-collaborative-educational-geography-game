using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesInfos : MonoBehaviour {

    private static GameObject statesInfoObject;
    private static GameObject canvasObject;
    private static GameObject statesObject;

    // Use this for initialization
    void Start()
    {
        statesInfoObject = GameObject.Find("_STATES_INFO");
        canvasObject = GameObject.Find("Canvas");
        statesObject = GameObject.Find("States");
    }

    public void showStatesInfo()
    {

        canvasObject.SetActive(false);
        statesObject.SetActive(false);
        statesInfoObject.SetActive(true);

    }

}
