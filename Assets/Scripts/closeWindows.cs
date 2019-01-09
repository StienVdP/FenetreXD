using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeWindows : MonoBehaviour {

    public Button close;
    public Button precedent;
    public GameObject pagePrecedent;

    // Use this for initialization
    void Start () {
        close.onClick.AddListener(functionFermer);
        if (pagePrecedent != null)
        {
            precedent.onClick.AddListener(functionPrecedent);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void functionFermer()
    {
        this.gameObject.SetActive(false);
        if (pagePrecedent != null && pagePrecedent.active == true)
        {
            pagePrecedent.SetActive(false);
        }
    }

    void functionPrecedent()
    {
        this.gameObject.SetActive(false);
        pagePrecedent.SetActive(true);
    }
}
