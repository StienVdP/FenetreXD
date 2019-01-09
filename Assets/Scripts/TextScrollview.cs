using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScrollview : MonoBehaviour {

	// Use this for initialization

	public UnityEngine.UI.Text prefab;
	private int compteur;

	public float repetitingTime;
	public float decalage;
	private bool itemToggle;

	public UnityEngine.UI.Text activeItem;
	void Start () {
		compteur=0;
		AddText("");
		//AddText("test2");
		//AddText("test3");
		activeItem=null;
		itemToggle=true;
		var tmp= (RectTransform)this.transform.parent;
		var tmpPos=tmp.position;
		tmpPos.y=0;
		this.transform.parent.position=tmpPos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Creer un objet text avec le text txt
	public void AddText(string txt){	
		var clone=Instantiate(prefab,new Vector3(),new Quaternion(),this.transform);
		clone.text+=txt+" ";
		//RectTransform rt = clone.GetComponent<RectTransform>();
		//rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top,decalage*compteur, rt.rect.height);

		//active Item
		if(activeItem!=null){
			activeItem.text=activeItem.text.Remove(activeItem.text.Length-1);
			CancelInvoke();
		}
		//activeItem=clone;
		var tab=this.GetComponentsInChildren<UnityEngine.UI.Text>();
		this.activeItem=tab[tab.Length-1];
		InvokeRepeating("toggleItem",repetitingTime,repetitingTime);
		Debug.Log(activeItem);
		
		//compteur
		compteur++;
	}

	void toggleItem(){
		var tab=this.GetComponentsInChildren<UnityEngine.UI.Text>();
		activeItem=tab[tab.Length-1];
		if(itemToggle){
			//alors on enleve
			activeItem.text=activeItem.text.Remove(activeItem.text.Length-1);
			itemToggle=false;
		}else{
			//alors on rajoute
			activeItem.text+="_";
			itemToggle=true;
		}
	}
}
