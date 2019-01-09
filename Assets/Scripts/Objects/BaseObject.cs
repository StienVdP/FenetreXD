using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObject : MonoBehaviour {

    static public int id=0;
    public int itemId;
    public int HP;
    public bool isRepared;
    public int maxHP;
    public float repareCooldown;
    public Collider repareCollider;
    public Collider endroitCollider; 
    public float baseHeight;
    public RepareParticleEmitter repareParticle;
    public DestroyParticleEmitter destroyParticle;
    public CorrectLocationParticleEmitter locationParticle;

    public bool isWellPlaced;


    private AudioSource sonRepare;

    private void Awake()
    {


        sonRepare=GameObject.Find("Player").GetComponents<AudioSource>()[1];
    }

    // Use this for initialization
    protected virtual void Start ()
    {

        //itemsWellPlacedandRepared = new List<bool>();
    }
	
	// Update is called once per frame
	protected virtual void Update () {
        if (HP < maxHP)
        {
            isRepared = false;
            
        }
    }

    public virtual void Destroy()
    {
        HP -=30;
        if(HP<0){
            HP=0;
        }
        isRepared = false;
        CheckItemList();
        destroyParticle.StartEmitDestroyParticle();
    }

    public virtual void Rotate(int angle)
    {
        gameObject.transform.Rotate(new Vector3(0, angle, 0));
    }

    public virtual void Repare()
    {
        if (repareCooldown <= 0 && !isRepared)
        {
            HP += 5;
            repareCooldown = 1;
            sonRepare.Play();
            StartCoroutine("RepareTimer");
            if (HP == maxHP)
            {
                isRepared = true;

                    CheckItemList();
                
                repareParticle.StopEmitParticle();
                destroyParticle.StopEmitParticle();
            }              
        }
    }

    public virtual void CheckItemList()
    {
        GameManager.repareScore = 0;
        GameManager.totalHp = 0;
        for(int i=0;i< GameManager.itemsWellPlacedandRepared.Count;i++)
        {
            GameManager.totalHp += GameManager.objects[i].maxHP;
            Debug.Log(GameManager.objects[i].maxHP);
            if (GameManager.itemsWellPlacedandRepared[i] == true)
            {
                //Debug.Log(i);
                GameManager.repareScore += GameManager.objects[i].HP;
            }        
        }
        Debug.Log(GameManager.totalHp);
        Debug.Log(GameManager.repareScore);
    }

    IEnumerator RepareTimer()
    {
        repareParticle.StartEmitParticle();
        yield return new WaitForSeconds(repareCooldown);
        repareParticle.StopEmitParticle();
    }

    public static float GetScore()
    {
        return (float)GameManager.repareScore / (float)GameManager.totalHp;
    }
}
