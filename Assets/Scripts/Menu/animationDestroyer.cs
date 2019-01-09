using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationDestroyer : MonoBehaviour {


    public GameObject GO;
    public Canvas Can;
    // Use this for initialization
    void Start () {
        Can.gameObject.SetActive(false);
        StartCoroutine(Intro());
        
    }


    IEnumerator Intro()
    {
        print(Time.time);
        yield return new WaitForSeconds(9);
        print(Time.time);
        GO.SetActive(false);
        Can.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
