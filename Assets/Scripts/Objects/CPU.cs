using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : BaseObject {


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        baseHeight = gameObject.transform.position.y;

        maxHP = 25;
        isRepared = true;
        repareCooldown = 1.0f;
        GameManager.itemsWellPlacedandRepared.Add(false);
        GameManager.objects.Add(this);

        itemId = id;
        id++;
    }

    // Update is called once per frame
    protected override void Update () {
        base.Update();

        if (repareCooldown > 0)
            repareCooldown -= Time.deltaTime;
	}

    public override void Destroy()
    {
        base.Destroy();
    }

    public override void Repare()
    {
        base.Repare();
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "CPUEmplacement" && transform.parent == null)
        {
            isWellPlaced = true;
            GameManager.itemsWellPlacedandRepared[itemId] = true;
                CheckItemList();
            locationParticle.StartEmitLocationParticle();

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "CPUEmplacement")
        {

            isWellPlaced = false;
            GameManager.itemsWellPlacedandRepared[itemId] = false;
            CheckItemList();
            locationParticle.StopEmitParticle();

        }
    }
}
