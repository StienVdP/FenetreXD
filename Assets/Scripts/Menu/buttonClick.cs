using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonClick : MonoBehaviour {

    private Button[] listButtons;
    private UnityAction[] tabFonctions;
    private GameObject dlcWindows , tutoWindow, tutoWindow2;
    private bool boolWindows , boolTutoWindows, boolTutoWindows2;
    private AudioSource sound;


    // Use this for initialization
    void Start () {
        UnityAction[] tabFonctions = {  functionButtonUser1 , functionButtonUser2 , functionButtonClose , functionButtonTuto,// fonction des premiers boutons
                                        functionButtonFermer , // fonction de dlcWindows
   
                                        functionButtonNext,functionButtonFermer }; // fonction de TutoLayout

        listButtons = this.GetComponentsInChildren<Button>();
        for (int i = 0; i < listButtons.Length; i++)
        {
            listButtons[i].onClick.AddListener(tabFonctions[i]);
            listButtons[i].onClick.AddListener(playClick);
        }
        Debug.Log(listButtons.Length);

        dlcWindows = this.transform.Find("dlcWindows").gameObject;
        boolWindows = false;
        dlcWindows.SetActive(boolWindows);

        tutoWindow = this.transform.Find("TutoLayout").gameObject;
        boolTutoWindows = false;
        tutoWindow.SetActive(boolTutoWindows);

        tutoWindow2 = this.transform.Find("TutoLayout2").gameObject;
        boolTutoWindows2 = false;
        tutoWindow2.SetActive(boolTutoWindows2);

        //init sound

        sound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    void functionButtonUser1()
    {
        sound.Play();
        Debug.Log("Test bouton User1 réussi !");
        //SceneManager.LoadScene("testWindows");
        SceneManager.LoadScene("scene bordel");
    }

    void functionButtonUser2()
    {

        Debug.Log("wololo");
        if (!boolWindows)
        {
            boolWindows = true;
            dlcWindows.SetActive(boolWindows);
            boolWindows = !boolWindows;
        }
    }
    
    void functionButtonClose()
    {
        Debug.Log("Test bouton FERMER réussi !");
        Application.Quit();
    }

    void functionButtonTuto()
    {
        if (!boolWindows)
        {
            boolTutoWindows = true;
            tutoWindow.SetActive(boolTutoWindows);
            boolWindows = !boolTutoWindows;
        }
    }
    void functionButtonNext()
    {
        if (!boolTutoWindows2)
        {
            boolTutoWindows2 = true;
           // tutoWindow.SetActive(boolTutoWindows);
            tutoWindow2.SetActive(boolTutoWindows2);
            boolTutoWindows2 = !boolTutoWindows2;
        }
    }
    void functionButtonFermer()
    {
        Debug.Log("Bouton fermer ne doit rien renvoyer !");
    }

    void playClick() {
        sound.Play();
    }

}
