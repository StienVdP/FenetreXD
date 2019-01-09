using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmmiter : MonoBehaviour {

    public ParticleSystem repareParticle;
    public ParticleSystem destroyedParticle;
    public BoxCollider box;
	// Use this for initialization
	void Start () {
        var rsh = repareParticle.shape;
        var dsh = repareParticle.shape;
        //rsh.position = new Vector3(0, 0, 0);
        rsh.scale = box.size;
        dsh.scale = box.size;
        if (!GetComponentInParent<BaseObject>().isRepared)
        {
            var dem = destroyedParticle.emission;
            dem.enabled = true;
        }
	}
	
    public void StartEmitParticle(int i)
    {
        switch(i)
        {
            case 1:
                var rem = repareParticle.emission;
                rem.enabled = true; break;
            case 2:
                var dem = destroyedParticle.emission;
                dem.enabled = true; break;
        }   
    }

    public void StopEmitParticle(int i)
    {
        switch (i)
        {
            case 1:
                var rem = destroyedParticle.emission;
                rem.enabled = false; break;
            case 2:
                var dem = destroyedParticle.emission;
                dem.enabled = false; break;
        }
    }
}
