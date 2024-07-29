using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pallinaMenu : MonoBehaviour {
    public Renderer rend;
    public buttonManagerMenù accButtonManager;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        rend.sharedMaterial = accButtonManager.colorePallinaScelto;
    }



}
