using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfondoScript : MonoBehaviour {
    public MainCamera accMainCamera;
    public float latoX = 11.5f;
    public float latoY = 17.5f;
    public GameObject posMaxSX;
    public GameObject posMaxDX;
    public GameObject posEnd;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
       // transform.position = transform.position + new Vector3(accMainCamera.calcolaX(accMainCamera.X), latoY,0 );
      // transform.position = new Vector3(accMainCamera.calcolaX(accMainCamera.X), 0,accMainCamera.calcolaY(accMainCamera.Y)*-1);
    }
   /* public void impostaSfondo()
    {
        transform.position = transform.position - new Vector3(0, latoY, 0);
       // transform.localScale = transform.localScale + new Vector3//impostare aumento x solo se aumenta posmaxdxsx, 0, 4.7f);
    }*/
    public void impostaBackground()
    {
        transform.localScale = transform.localScale + new Vector3(6, 0, 4);
        transform.position = new Vector3((posMaxDX.transform.position.x + posMaxSX.transform.position.x)/2, (posEnd.transform.position.y + 23)/2, 0);
    }
   
}
