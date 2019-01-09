using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestNvidia : MonoBehaviour {

    public GameObject nvidio;
    private Button butTest;
    private int compt;

	// Use this for initialization
	void Start () {
        butTest = this.GetComponent<Button>();
        butTest.onClick.AddListener(freezeScreen);
        compt = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void freezeScreen()
    {
        Debug.Log("I AM IN FREEZESCREEN");
        nvidio.SetActive(true);
    }
}
