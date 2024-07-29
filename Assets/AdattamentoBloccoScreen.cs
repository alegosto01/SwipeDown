using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdattamentoBloccoScreen : MonoBehaviour {

   public float X;
    float Y;
    public float Rapporto;
    public Camera Camera;
    void Start () {

        // X = ((Screen.width - 720) * 2) / 405;
        if (Screen.height / Screen.width >= 2 && Screen.width > 1000)
        {
            X = 26;
        }
        else
        {
            X = 25;
        }
        AdattamentoCameraSize();
        print(Screen.width);
       
    }
	
	// Update is called once per frame
	void Update () {

    }
    public void AdattamentoCameraSize()
    {
       
        Camera = gameObject.GetComponent<Camera>();
        Camera.orthographicSize = X;
    }
}
