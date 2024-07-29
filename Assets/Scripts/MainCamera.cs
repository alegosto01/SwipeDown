using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public GameObject pallina;    
    public float Area;
    public float X;
    public float Y;
    public float Distanza;
    public bool morto_vivo = false;
    public float angolo = 5.88f;
    public float altezza = 40;
    public Camera Camera;
    public GameObject posEnd;
    public GameObject posMaxDX;
    public GameObject posMaxSX;
    static float t = 1f;
    public GameObject SferaAlternanza;
    public GameObject menupausa;
    public sphereScript AccSfera;

    void Start () {

        t = 1;
        PlayerPrefs.SetString("CameraMenù", "Attiva");
        SferaAlternanza.SetActive(true);
        

    }

    void Update () {
        posizioneCam();
        calcolaY(Y);
        calcolaX(X);
	}
   
    
  
    public void posizioneCam()
    {
        if(morto_vivo == true )
        {
            if(transform.position != new Vector3(calcolaX(X), calcolaY(Y), -altezza))
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(calcolaX(X), calcolaY(Y), -altezza),t);
            }
            if (PlayerPrefs.GetInt("DistanzaPartita", 0) == 1 )
            {
                if (Camera.orthographicSize != (posEnd.transform.position.y / 2) * -1 + 40f)
                {
                    Camera.orthographicSize = Mathf.Lerp((posEnd.transform.position.y / 2) * -1 + 40f, 25, t);
                }
            }
              if (Camera.orthographicSize != PiùGrande() + 50f & PlayerPrefs.GetInt("DistanzaPartita", 0) > 1)
            {
                Camera.orthographicSize = Mathf.Lerp((posEnd.transform.position.y / 2) * -1 + 50f, 25, t);
            }
                 t -= 0.02f;
            //new Rect(transform.position.x,transform.position.y, 20,20);
        } //(GameObject.FindGameObjectWithTag("posEnd").transform.position.y / 2) * -1 + 12.5f
        else 
        {
            transform.position = new Vector3(pallina.transform.position.x, pallina.transform.position.y, -40);//si puo fare con il tag come i pos
        }
    }
    public float calcolaX(float X)
    {
        X = (posMaxDX.transform.position.x + posMaxSX.transform.position.x) / 2 ;
        
        return X;
    }
    public float calcolaY(float Y)
    {
        Y = (posEnd.transform.position.y + 42) / 2;
        //Y = y;
        return Y;
    }
    public float PiùGrande()
    {
        if (((posEnd.transform.position.y / 2) * -1) < (posMaxDX.transform.position.x - posMaxSX.transform.position.x))
            {
            return (posMaxDX.transform.position.x - posMaxSX.transform.position.x);
        }
        else
        {
            return ((posEnd.transform.position.y / 2) * -1);
        }
    }
    
    

}
