using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPU : BaseObject {

    private bool isGPURepared;
    public GameObject nVidio;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        baseHeight = gameObject.transform.position.y;
        maxHP = 50;
        isRepared = true;
        repareCooldown = 1.0f;
        isGPURepared = false;
        GameManager.itemsWellPlacedandRepared.Add(false);
        GameManager.objects.Add(this);

        itemId = id;
        id++;
    }

    // Update is called once per frame
    protected override void  Update()
    {
        base.Update();
        if (repareCooldown > 0)
            repareCooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.G))
        {
            Repare();
        }
    }

    public override void Destroy()
    {
        base.Destroy();
    }

    public override void Repare()
    {
        base.Repare();
        if (HP == maxHP && !isGPURepared)
        {
            isGPURepared = true;
            nVidio.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "GPUEmplacement" && transform.parent == null)
        {
            isWellPlaced = true;

            GameManager.itemsWellPlacedandRepared[itemId]=true;
                CheckItemList();
            locationParticle.StartEmitLocationParticle();

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "GPUEmplacement")
        {
            isWellPlaced = false;
            GameManager.itemsWellPlacedandRepared[itemId] = false;
            CheckItemList();
            locationParticle.StopEmitParticle();

        }
    }
}
