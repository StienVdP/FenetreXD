using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class uiFeedBackList : MonoBehaviour
{

    public List<GameObject> Composantlist;

    int composantHP;
    int composantHPMax;

    bool isWellPlaced;

    Color colorObject;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool repared = true;
        bool placed = true;

        foreach (GameObject item in Composantlist)
        {

            isWellPlaced = item.GetComponent<BaseObject>().isWellPlaced;
            composantHP = item.GetComponent<BaseObject>().HP;
            composantHPMax = item.GetComponent<BaseObject>().maxHP;
            if (!isWellPlaced)
                placed = false;
            if (!(composantHP / composantHPMax == 1))
                repared = false;
        

        }
            if (repared&&!placed)
        {
                //blanc
            colorObject = new Color(1.0f, 1.0f, 1.0f);
        }            


            else if (repared&&placed)
            {
                //vert
                colorObject = new Color(0.0f, 0.9f, 0.0f, 0.8f);
                Debug.Log("VERTYYYYY");
            }
            
            else if (!repared)
            {
                //rouge
                colorObject = new Color(0.9f, 0.0f, 0.0f, 0.8f);   
            }
        this.GetComponent<Image>().color = colorObject;
    }
}
