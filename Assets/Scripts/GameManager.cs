using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
    static public List<bool> itemsWellPlacedandRepared;
    static public List<BaseObject> objects;
    static public bool listCreated;
    static public int repareScore;
    static public int totalHp;


    void Awake () {
        listCreated = false;
        if (!listCreated)
        {
            itemsWellPlacedandRepared = new List<bool>();
            objects = new List<BaseObject>();
            listCreated = true;
        }
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        
        {
            Debug.Log(repareScore);
            Debug.Log(totalHp);
        }
    }

}
