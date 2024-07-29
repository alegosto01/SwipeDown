using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour {

    public GameObject uno;
    public GameObject due;
    public GameObject tre;
    public GameObject quattro;
    public GameObject back;
    public GameObject nome1;
    public GameObject nome2;
    public GameObject play;
    public GameObject baule;
    public GameObject menùPalline;
    public GameObject options;
    public GameObject sfera;
    public float aumento = 0.2f;
    public float intervallo = 0;
    public bool cliccato = false;
    public Camera mainCamera;
    public Camera CameraAlternanza;
    public GameObject GMOCameraMenù;

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("CameraMenù", "Attiva");
    }
    void Start () {

        if(PlayerPrefs.GetString("CameraMenù","") != "Attiva")
        {
            GMOCameraMenù.SetActive(false);
        }
        mainCamera.aspect = (Screen.currentResolution.width/Screen.currentResolution.height);
        
        uno.SetActive(true);
        /*nome1.transform.position = new Vector3(nome1.transform.position.x * (Screen.width / native_width), nome1.transform.position.y * (Screen.height / native_height));
        nome1.transform.localScale = new Vector3(nome1.transform.localScale.x * (Screen.width / native_width), nome1.transform.localScale.y * (Screen.height / native_height));
        nome2.transform.position = new Vector3(nome2.transform.position.x * (Screen.width / native_width), nome2.transform.position.y * (Screen.height / native_height));
        nome2.transform.localScale = new Vector3(nome2.transform.localScale.x * (Screen.width / native_width), nome2.transform.localScale.y * (Screen.height / native_height));
        play.transform.position = new Vector3(play.transform.position.x * (Screen.width / native_width), play.transform.position.y * (Screen.height / native_height));
        play.transform.localScale = new Vector3(play.transform.localScale.x * (Screen.width / native_width), play.transform.localScale.y * (Screen.height / native_height));
        baule.transform.position = new Vector3(baule.transform.position.x * (Screen.width / native_width), baule.transform.position.y * (Screen.height / native_height));
        baule.transform.localScale = new Vector3(baule.transform.localScale.x * (Screen.width / native_width), baule.transform.localScale.y * (Screen.height / native_height));
        options.transform.position = new Vector3(options.transform.position.x * (Screen.width / native_width), options.transform.position.y * (Screen.height / native_height));
        options.transform.localScale = new Vector3(options.transform.localScale.x * (Screen.width / native_width), options.transform.localScale.y * (Screen.height / native_height));
        menùPalline.transform.position = new Vector3(menùPalline.transform.position.x * (Screen.width / native_width), menùPalline.transform.position.y * (Screen.height / native_height));
        menùPalline.transform.localScale = new Vector3(menùPalline.transform.localScale.x * (Screen.width / native_width), menùPalline.transform.localScale.y * (Screen.height / native_height));
        sfera.transform.position = new Vector3(sfera.transform.position.x * (Screen.width / native_width), sfera.transform.position.y * (Screen.height / native_height));
       sfera.transform.localScale = new Vector3(sfera.transform.localScale.x * (Screen.width / native_width), sfera.transform.localScale.y * (Screen.height / native_height));
       */
        //  back.transform.position = new Vector3( back.transform.position.x * (Screen.width / native_width),back.transform.position.y * (Screen.height/native_height));
        //  back.transform.localScale = new Vector3(back.transform.localScale.x * (Screen.width / native_width), back.transform.localScale.y * (Screen.height / native_height));
    }

    void Update () {
        if(uno.activeSelf == true & intervallo < 0 & aumento < 1)
        {
            uno.SetActive(false);
            tre.SetActive(true);
            if (cliccato == true)
            {
                intervallo = intervallo + aumento;
                aumento = aumento + 0.1f;
            }
            else
            {
                intervallo = 0.1f;
            }
        }
        else if(tre.activeSelf== true & intervallo < 0 & aumento < 1)
        {
            tre.SetActive(false);
            due.SetActive(true);
            if (cliccato == true)
            {
                intervallo = intervallo + aumento;
                aumento = aumento + 0.1f;
            }
            else
            {
                intervallo = 0.1f;
            }
        }
        else if(due.activeSelf == true & intervallo < 0 & aumento < 1)
        {
            due.SetActive(false);
            quattro.SetActive(true);
            if (cliccato == true)
            {
                intervallo = intervallo + aumento;
                aumento = aumento + 0.1f;
            }
            else
            {
                intervallo = 0.1f;
            }
        }
        else if(quattro.activeSelf == true & intervallo < 0 & aumento < 1)
        {
            quattro.SetActive(false);
            uno.SetActive(true);
            if (cliccato == true)
            {
                intervallo = intervallo + aumento;
                aumento = aumento + 0.1f;
            }
            else
            {
                intervallo = 0.1f;
            }
        }
        if (intervallo >= 0)
        {
            intervallo = intervallo - Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            cliccato = true;
        }
    }
}
