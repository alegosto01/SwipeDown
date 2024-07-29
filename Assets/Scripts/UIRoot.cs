using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIroot : MonoBehaviour {

    public GameObject paolo;

    void Start () {
        paolo.transform.position = new Vector3( Screen.width / 2,Screen.height/2, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
