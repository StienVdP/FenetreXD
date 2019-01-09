using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour {


    Color colorHealthBar = new Color(0.0f, 0.0f, 0.0f);
    float health;
    float MaxHealth;
    float Healthmaisdiviser;

    float xPos;
    float yPos;
    float zPos;

    // Use this for initialization
    void Start () {
        this.GetComponent<CanvasRenderer>().SetColor(colorHealthBar);
        health = this.GetComponentInParent<BaseObject>().HP;
        MaxHealth = this.GetComponentInParent<BaseObject>().maxHP;

       xPos = this.GetComponent<RectTransform>().transform.position.x;
       yPos = this.GetComponent<RectTransform>().transform.position.y;
       zPos = this.GetComponent<RectTransform>().transform.position.z;


        Debug.Log(health/MaxHealth);
	}
	
	// Update is called once per frame
	void Update () {

        if (this.GetComponent<RectTransform>().transform.localScale.x >= 0)
        {
            health = this.GetComponentInParent<BaseObject>().HP;
            MaxHealth = this.GetComponentInParent<BaseObject>().maxHP;
            Healthmaisdiviser = health / MaxHealth;
            colorHealthBar.g = Healthmaisdiviser;
            colorHealthBar.r = 1.0f - Healthmaisdiviser;
            this.GetComponent<CanvasRenderer>().SetColor(colorHealthBar);
            //Debug.Log(this.GetComponent<RectTransform>().transform.localScale.x);
            this.GetComponent<RectTransform>().transform.localScale = new Vector3(Healthmaisdiviser, 1.0f, 1.0f);
        }
        //this.GetComponent<RectTransform>().transform.position = new Vector3(xPos - (1.0f - (Healthmaisdiviser)), yPos, zPos);
    }
}
