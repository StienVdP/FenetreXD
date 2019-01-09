using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class WindowsButton : MonoBehaviour {

    private Button[] listButtons;
    private UnityAction[] tabFonctions;
    private GameObject colomneDemarrer;
    private bool boolDemarrer;
    public GameObject[] listPopUps;
    private int comptPopUp;
    public float timePopUp;
    public GameObject panelFlou;
    private GameObject google;
    private bool boolGoogle;
    private GameObject google2;
    private bool boolGoogle2;
    private GameObject posteTravail;
    private bool boolPosteTravail;
    private GameObject diablo;
    private bool boolDiablo;
    private GameObject diabloWarning;
    private bool boolDiabloWarning;
    private GameObject photoWindow;
    private bool boolPhotoWindow;
    private GameObject beauMec;
    private bool boolBeauMec;
    private GameObject cmdPrompt;
    private bool boolCmdPrompt;
 
    private GameObject victoryPop;
    private bool boolVictoryPop;
    private GameObject forceUpdate;
    private bool boolForceUpdate;

    public bool conditionVictoire;

    public float coolDownPng;
    private bool allowClickPhoto;
    private GameObject virus1, virus2, virus3, virus4, virus5, virus6;
    private bool boolPart; 

    

    private bool ralentir1, ralentir2, ralentir3;

    // Player
    private CharacterControler player;

    //Son
    private AudioSource audioSource , audioBoot ,audioError;

    private TextScrollview contenuScroll;

    // Use this for initialization
    void Start () {


        UnityAction[] tabFonctions = { functionButtonDemarrer, functionButtonPosteTravail, functionButtonInternet, functionButtonDiablo, //fonction du bureau
                                        functionBoutonShutdown,functionButtonPosteTravail, functionButtonInternet, functionButtonDiablo, functionButtonInvCommande, functionButtonTousProgs, // fonction de demarrer
                                        functionFermer, functionButtonChance, functionButtonRecherche, // fonction de google1
                                        functionFermer, functionPrecedent,// fonction de google2
                                        functionFermer, functionButtonPhotoLouche, // fonction de poste travail
                                        functionFermer, functionButtonPlayDiablo, // fonction de diablo
                                        functionFermer, // fonction de diablo Warning
                                        functionFermer, functionPrecedent, functionButtonBeauMec, // fonction de PhotoWindow
                                        functionFermer, // fonction de BeauMec
                                        functionFermer, // FN de command Prompt
                                        functionButtonAcceptUpdate, functionButtonRefuseUpdate, // fonction de VictoryPopUp
                                        functionButtonAcceptUpdate}; // fonction de ForceUpdate
                                        
        listButtons = this.GetComponentsInChildren<Button>();
        for (int i = 0; i < listButtons.Length; i++)
        {
            listButtons[i].onClick.AddListener(tabFonctions[i]);
            listButtons[i].onClick.AddListener(playClick);
        }
        Debug.Log(listButtons.Length);

        panelFlou.SetActive(false);

        allowClickPhoto = true;
        ralentir1 = true;
        ralentir2 = true;
        ralentir3 = true;

        player = GameObject.Find("Player").GetComponent<CharacterControler>();

        contenuScroll = GameObject.Find("Content").GetComponent<TextScrollview>();

        // Colomne Démarrer Initialisation
        colomneDemarrer = this.transform.Find("colomneDemarrer").gameObject;
        boolDemarrer = false;
        colomneDemarrer.SetActive(boolDemarrer);

        // Google Initialisation
        google = this.transform.Find("Google").gameObject;
        boolGoogle = false;
        google.SetActive(boolGoogle);
        google2 = this.transform.Find("ChanceResult").gameObject;
        boolGoogle2 = false;
        google2.SetActive(boolGoogle2);

        //sons
        audioSource=GetComponents<AudioSource>()[0];
        audioBoot = GetComponents<AudioSource>()[1];
        audioError = GetComponents<AudioSource>()[2];
        audioBoot.Play();



        // Poste de Travail Initialisation
        posteTravail = this.transform.Find("PostTravail").gameObject;
        boolPosteTravail = false;
        posteTravail.SetActive(boolPosteTravail);

        // Diablo Initialisation
        diablo = this.transform.Find("Diablo").gameObject;
        boolDiablo = false;
        diablo.SetActive(boolDiablo);

        // Diablo Warning Initialisation
        diabloWarning = this.transform.Find("Warning").gameObject;
        boolDiabloWarning = false;
        diabloWarning.SetActive(boolDiabloWarning);

        // PhotoWindow Initialisation
        photoWindow = this.transform.Find("PhotoWindow").gameObject;
        boolPhotoWindow = false;
        photoWindow.SetActive(boolPhotoWindow);

        cmdPrompt = this.transform.Find("commandPrompt").gameObject;
        boolCmdPrompt = false;
        cmdPrompt.SetActive(boolCmdPrompt);

        // BeauMec.png Initialisation
        beauMec = this.transform.Find("BeauMec").gameObject;
        boolBeauMec = false;
        beauMec.SetActive(boolBeauMec);

        
        // VictoryPopUp Initialisation
        victoryPop = this.transform.Find("VictoryPopUp").gameObject;
        boolVictoryPop = false;
        victoryPop.SetActive(boolVictoryPop);

        // ForceUpdate Initialisation
        forceUpdate = this.transform.Find("ForceUpdate").gameObject;
        boolForceUpdate = false;
        forceUpdate.SetActive(boolForceUpdate);
        
        // Desactiver virus dans la scene 
        virus1 = GameObject.Find("ParticulePoussiere1");
        virus2 = GameObject.Find("ParticulePoussiere2");
        virus3 = GameObject.Find("ParticulePoussiere3");
        virus4 = GameObject.Find("ParticulePoussiere4");
        virus5 = GameObject.Find("ParticulePoussiere5");
        virus6 = GameObject.Find("ParticulePoussiere6");
        boolPart = false;
        virus1.SetActive(boolPart);
        virus2.SetActive(boolPart);
        virus3.SetActive(boolPart);
        virus4.SetActive(boolPart);
        virus5.SetActive(boolPart);
        virus6.SetActive(boolPart);
    }
	
	// Update is called once per frame
	void Update () {
		if (conditionVictoire)
        {
            functionVictoire(); // Affiche PopUp Update Fenetre10
        }
	}

    void functionButtonDemarrer()
    {
        Debug.Log("Test bouton demarrer réussi !");
        if (boolDemarrer) // Cacher demarrer
        {
            boolDemarrer = false;
            colomneDemarrer.SetActive(boolDemarrer);
        }
        else if (!boolDemarrer) // Afficher Demarrer
        {
            boolDemarrer = true;
            colomneDemarrer.SetActive(boolDemarrer);
        }
    }

    void functionButtonPosteTravail()
    {
        Debug.Log("Test bouton Poste de Travail reussi !");
        if (!boolPosteTravail)
        {
            boolPosteTravail = true;
            posteTravail.SetActive(boolPosteTravail);
            boolPosteTravail = false;
        }
        if (boolDemarrer) // Cacher demarrer
        {
            boolDemarrer = false;
            colomneDemarrer.SetActive(boolDemarrer);
        }
    }

    void functionButtonPhotoLouche()
    {
        if (!boolPhotoWindow)
        {
            boolPhotoWindow = true;
            photoWindow.SetActive(boolPhotoWindow);
            boolPhotoWindow = false;
        }
    }

    void functionButtonBeauMec()
    {
        if (!boolBeauMec && allowClickPhoto)
        {
            boolBeauMec = true;
            beauMec.SetActive(boolBeauMec);
            boolBeauMec = false;
            // Liver le jeu pour stun l'anti virus
            player.Stun();
            contenuScroll.AddText("Ce fichier est corrompu. Analyse de l'anti-virus");
            StartCoroutine(coolDown());
        }
    }

    void functionButtonInternet()
    {
        Debug.Log("Test bouton internet réussi !");
        if (!boolGoogle)
        {
            boolGoogle = true;
            google.SetActive(boolGoogle);
            boolGoogle = false;
        }
        if (boolDemarrer) // Cacher demarrer
        {
            boolDemarrer = false;
            colomneDemarrer.SetActive(boolDemarrer);
        }
        if (ralentir1)
        {
            player.ralentir();
            ralentir1 = false;
        }
    }

    void functionFermer()
    {
        Debug.Log("Ne doit rien faire (Fermer)");
    }

    void functionPrecedent()
    {
        Debug.Log("Ne doit rien faire (Retour)");
    }

    void functionButtonChance()
    {
        if (!boolGoogle2) // Ouvre nouvelle page google2
        {
            boolGoogle2 = true;
            google2.SetActive(boolGoogle2);
            boolGoogle2 = false;
            if (boolGoogle) // Ferme l'ancienne page (google1)
            {
                boolGoogle = false;
                google.SetActive(boolGoogle);
                boolGoogle = true;
            }
        }
        if (ralentir2)
        {
            player.ralentir();
            ralentir2 = false;
        }
    }

    void functionButtonRecherche()
    {
        comptPopUp = 0;
        Invoke("pupUps", 0);
        Invoke("pupUps", timePopUp);
        Invoke("pupUps", timePopUp * 2);
        comptPopUp = 0;

        contenuScroll.AddText("Votre historique est vraiment obscure Connexion ralentie...");

        if (ralentir3)
        {
            player.ralentir();
            ralentir3 = false;
        }
    }

    void pupUps()
    {
        //son ici
        audioError.Play();
        Instantiate(listPopUps[comptPopUp], this.transform);
        comptPopUp++;
    }

    void functionButtonDiablo()
    {
        Debug.Log("Test bouton diablo reussi !");
        if (!boolDiablo)
        {
            boolDiablo = true;
            diablo.SetActive(boolDiablo);
            boolDiablo = false;
        }
        if (boolDemarrer) // Cacher demarrer
        {
            boolDemarrer = false;
            colomneDemarrer.SetActive(boolDemarrer);
        }
    }

    void functionButtonInvCommande()
    {
        Debug.Log("Test bouton Invite de commande reussi !");
        if (boolDemarrer) // Cacher demarrer
        {
            boolDemarrer = false;
            colomneDemarrer.SetActive(boolDemarrer);
        
            boolPart = true;
            virus1.SetActive(boolPart);
            virus2.SetActive(boolPart);
            virus3.SetActive(boolPart);
            virus4.SetActive(boolPart);
            virus5.SetActive(boolPart);
            virus6.SetActive(boolPart);
            contenuScroll.AddText("Virus detectés ! Ils tentent de vous barrer la route !");
        }
        boolCmdPrompt = true;
        cmdPrompt.SetActive(cmdPrompt);
    }

    void functionButtonTousProgs()
    {
        Debug.Log("Test bouton Tous les progs reussi !");
    }

    void functionButtonPlayDiablo()
    {
        Debug.Log("Test bouton Tous les progs reussi !");
        if (!boolDiabloWarning) // Afficher Demarrer
        {
            // Lier le jeu avec une fonction qui casse la carte graphique
            boolDiabloWarning = true;
            diabloWarning.SetActive(boolDiabloWarning);
            //boolDiabloWarning = false;
            GameObject.Find("GPU").GetComponent<GPU>().Destroy(); // Destroy GPU
            contenuScroll.AddText("La carte graphique n'est plus détectée. Allez la réparer");
            StartCoroutine(flou());
        }
    }

    void functionVictoire()
    {
        listButtons = this.GetComponentsInChildren<Button>();
        for (int i = 0; i < listButtons.Length; i++)
        {
            if(listButtons[i].name != "Accepter" && listButtons[i].name != "Cancel" && listButtons[i].name != "OK")
            {
                listButtons[i].enabled = false;
            }
        }
        var index = victoryPop.transform.GetSiblingIndex();
        victoryPop.transform.SetSiblingIndex(index+4);
        if (!boolVictoryPop)
        {
            boolVictoryPop = true;
            victoryPop.SetActive(boolVictoryPop);
            boolVictoryPop = false;
            conditionVictoire = false;
        }
    }

    void functionButtonAcceptUpdate()
    {
        SceneManager.LoadScene("menu2");
    }

    void functionButtonRefuseUpdate()
    {
        var index = forceUpdate.transform.GetSiblingIndex();
        forceUpdate.transform.SetSiblingIndex(index + 4);
        if (!boolForceUpdate)
        {
            boolVictoryPop = false;
            victoryPop.SetActive(boolVictoryPop);
            boolForceUpdate = true;
            forceUpdate.SetActive(boolForceUpdate);
            boolForceUpdate = false;
        }
    }

    void functionBoutonShutdown() {
        Debug.Log("SHUTDOWN");
       Application.Quit();
    }

    IEnumerator flou()
    {
        panelFlou.SetActive(true);
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
        panelFlou.SetActive(false);

    }

    IEnumerator coolDown()
    {
        allowClickPhoto = false;
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
        allowClickPhoto = true;

    }

    void playClick(){
        audioSource.Play();
    }
}
