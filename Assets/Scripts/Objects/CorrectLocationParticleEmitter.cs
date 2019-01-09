using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectLocationParticleEmitter : MonoBehaviour {


    public ParticleSystem locationParticle;
    public BoxCollider box;
    // Use this for initialization
    void Start()
    {
        box = transform.parent.GetComponent<BoxCollider>();
        var dsh = locationParticle.shape;
        dsh.scale = new Vector3(box.size.x, box.size.z, box.size.y);
    }

    private void Update()
    {

    }

    public void StartEmitLocationParticle()
    {
        locationParticle.Play();
    }

    public void StopEmitParticle()
    {
        locationParticle.Stop();
    }
}
