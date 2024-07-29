using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ostacoloRotante : MonoBehaviour {
    public Transform posSpawn;
    
	
	void Start () {
        transform.position = posSpawn.position;
	}

    private void FixedUpdate()
    {
        if (transform.position.y - posSpawn.position.y < 30 && PlayerPrefs.GetString("pausa", "nonattiva") != "Attiva") 
            {
                transform.position = transform.position + new Vector3(0, 0.15f, 0);
                transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
            }
        if(transform.position.y - posSpawn.position.y >= 30)
        {
            gameObject.SetActive(false);
        }
           
    }
}
