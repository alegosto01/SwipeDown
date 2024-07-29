using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chiusuraBasso : MonoBehaviour {

    public Transform posBarrieraFinaleB;
	void Start () {
		
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(transform.position.y < posBarrieraFinaleB.position.y)
        {
            transform.position = transform.position + new Vector3(0, 1, 0) * Time.deltaTime;
            if (transform.localScale.z  < 20)
            {
                transform.localScale = transform.localScale + new Vector3(0, 0, 1.99f) * Time.deltaTime;
            }
            }
    }
}
