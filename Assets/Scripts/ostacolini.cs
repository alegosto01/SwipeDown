using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ostacolini : MonoBehaviour {

    public Transform posSpawn;
    // Use this for initialization
    void Start() {
        posSpawn.position = transform.position;
    }
    // Update is called once per frame
    private void FixedUpdate()
    
        
    
        {
        if (transform.position.y - posSpawn.position.y < 30 && PlayerPrefs.GetString("pausa", "nonattiva") != "Attiva")
        {
            transform.position = transform.position + new Vector3(0, 5, 0) * Time.deltaTime;
        }
        if (transform.position.y - posSpawn.position.y >= 30)
        {
            gameObject.SetActive(false);
        }
        
    }
}
