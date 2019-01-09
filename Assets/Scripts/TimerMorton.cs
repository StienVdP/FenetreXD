using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerMorton : MonoBehaviour {
    
    private int compt;
    private UnityEngine.UI.Image[] tabBlockClone;
    [Tooltip("En secondes")]
    public float gameTime;
    private float timeDelay;
    private bool computerDestroy; // Variable de victoire ou non 

    // Use this for initialization
    void Start () {
        compt = 0;
        tabBlockClone = GameObject.Find("LoadingBarreMorton").GetComponentsInChildren<UnityEngine.UI.Image>();
        for (var i = 0; i < tabBlockClone.Length; i++)
        {
            tabBlockClone[i].gameObject.SetActive(false);
        }
        Invoke("updateBlueBar", 1);

        // Temporairement la victoire est au destructeur
        computerDestroy = true;
        timeDelay=gameTime/38;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void updateBlueBar()
    {
        Debug.Log("Dans UpdateBluBar");
        for (int i = 0; i < 38; i++)
        {
            var range = Random.Range(1f, timeDelay);
            Invoke("instentiateBlueBar", timeDelay*i);// 3.15f second
        }
    }

    void instentiateBlueBar()
    {
        tabBlockClone[compt].gameObject.SetActive(true);
        compt++;
        
        if (compt == tabBlockClone.Length)
        {
            GameManager.listCreated = false;
            BaseObject.id = 0;
            // Fin du jeu Changement de scene suivant les scores
            Debug.Log("FIN DU JEU");
            Debug.Log(BaseObject.GetScore() + "bluuuuuuub");
            if (BaseObject.GetScore()<=0.75){
                SceneManager.LoadScene("BlueScreen");
            }
            else
            {
                // Mettre le booean de buttons à true
                this.transform.parent.Find("Buttons").GetComponent<WindowsButton>().conditionVictoire = true;
                GameObject.Find("Player").GetComponent<CharacterControler>().StunFinDeJeu();
            }
        }

        
    }
}
