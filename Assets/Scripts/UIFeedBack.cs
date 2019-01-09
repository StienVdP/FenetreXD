using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIFeedBack : MonoBehaviour {

    public GameObject Composant;

    int composantHP;
    int composantHPMax;

    bool isWellPlaced;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        isWellPlaced = Composant.GetComponent<BaseObject>().isWellPlaced;
        composantHP = Composant.GetComponent<BaseObject>().HP;
        composantHPMax = Composant.GetComponent<BaseObject>().maxHP;

        if (composantHP/composantHPMax != 1 )
        {
            //rouge
            this.GetComponent<Image>().color = new Color(0.9f, 0.0f, 0.0f, 0.8f);
        }
        else if(isWellPlaced && composantHP/composantHPMax == 1 )
        {
            //vert
            this.GetComponent<Image>().color = new Color(0.0f, 0.9f, 0.0f, 0.8f);
        }
        else
        {
            //blanc
            this.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        }
        
	}
}
