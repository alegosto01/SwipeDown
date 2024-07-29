using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monetaScript : MonoBehaviour {

	void Start () {
        gameObject.SetActive(true);
	}

    
    private void FixedUpdate()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pallina"))
        {
            gameObject.SetActive(false);
        }
    }
}
