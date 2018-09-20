using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {

    GameObject statesContainer;
    
    void Awake()
    {
        statesContainer = GameObject.Find("States");
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Close()
    {
        Application.Quit();
    }
}
