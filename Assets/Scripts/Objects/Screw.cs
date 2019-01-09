using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : BaseObject {


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        maxHP = 10;
        isRepared = true;
        repareCooldown = 1.0f;
        baseHeight = gameObject.transform.position.y;
        GameManager.itemsWellPlacedandRepared.Add(false);
        GameManager.objects.Add(this);

        itemId = id;
        id++;
    }

    // Update is called once per frame
    protected override void Update()
    {
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
        if (collision.tag == "VisEmplacement" && transform.parent == null)
        {

            isWellPlaced = true;

            GameManager.itemsWellPlacedandRepared[itemId] = true;
                CheckItemList();
            
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "VisEmplacement" )
        {

            isWellPlaced = false;
            GameManager.itemsWellPlacedandRepared[itemId] = false;
            CheckItemList();

        }
    }
}
