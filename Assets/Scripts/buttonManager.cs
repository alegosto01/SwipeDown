using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class buttonManager : MonoBehaviour {

    // Use this for initialization

    public GameObject menu;
    public UISprite suoniBTN;
    public Texture volumeON;
    public Texture volumeOFF;
    public bool QuelloVero = false;
    public string volumeImpostato;
    public sphereScript AccSphere;
    public GameObject SferaMenù;
    public GameObject SferaAlternanza;
    public GameObject Pallina;
    public GameObject CameraMenù;
    public GameObject CameraAlternanza;
    public GameObject UIGioco;
    public GameObject UIMenù;
    public GameObject MenùGMOV;
    public GameObject MenùPausa;
    public UILabel Punteggiopartita;
    public UILabel TapToChange;
    public GameObject TapToChangeGMOB;
    public UILabel ContatoreMonetePausa;
    public bool Alpha = false;
    public bool morto;
    public float TimerRestart = 1;
    public AdsManager AccAdsManager;
    
   
    public void Start()
    {
        PlayerPrefs.SetString("pausa", "nonattiva");

        //volumeImpostato = PlayerPrefs.GetString("VolumeONOFF");
        if (PlayerPrefs.GetString("VolumeONOFF", "on") == "off")
        {
            suoniBTN.spriteName = "volumeOFF";
        }
        else
        {
            suoniBTN.spriteName = "volumeON";
        }
    }
    private void FixedUpdate()
    {
        if (morto == true)
        {
            TimerRestart = TimerRestart - 1 * Time.deltaTime;
        }
       if(TimerRestart < 0 && Input.touchCount > 0 && Input.GetTouch(0).position.y < Screen.height - 300 && MenùPausa.activeInHierarchy == false)
        {
            Restart();
        }
        Punteggiopartita.text = PlayerPrefs.GetInt("DistanzaPartita").ToString();
        //  TapToChange.color.a = TapToChange.color.a + 
        if (TapToChangeGMOB.activeInHierarchy == true &&TapToChange.alpha > 0 && Alpha == false)
        {
            TapToChange.alpha = TapToChange.alpha - 2 * Time.deltaTime;
            if(TapToChange.alpha <= 0)
            {
                Alpha = true;
            }
        }
        else if (TapToChangeGMOB.activeInHierarchy== true&& TapToChange.alpha <= 1 && Alpha == true)

        {
            TapToChange.alpha = TapToChange.alpha + 2 * Time.deltaTime;
            if(TapToChange.alpha > 1)
            {
                Alpha = false;
            }
        }
    }
    public void altraScena(string nuovascena)
    {
        
        SceneManager.LoadScene(nuovascena,LoadSceneMode.Single);
    }
    public void VaiMenu()
    {
        PlayerPrefs.SetString("pausa", "NonAttiva");
        MenùPausa.SetActive(false);
        PlayerPrefs.SetString("CameraMenù", "Attiva");
        SceneManager.LoadScene("menù principale");
        /*SferaMenù.SetActive(true);
        UIMenù.SetActive(true);
        CameraAlternanza.SetActive(false);
        CameraMenù.SetActive(true);
        UIGioco.SetActive(false);
        SferaAlternanza.SetActive(false);*/
      
            AccAdsManager.ShowInterstitial();
        

    }
    public void SpegniPausa()
    {
        PlayerPrefs.SetString("pausa", "NonAttiva");
    }
    public void exitgamebtn()//tasto exit
    {
        Application.Quit();
    }
    public void Restart()
    {
        PlayerPrefs.SetString("CameraMenù", "NonAttiva");
        SceneManager.LoadScene("menù principale");
        PlayerPrefs.SetString("pausa", "NonAttiva");
        MenùPausa.SetActive(false);

    }
    public void pausa()
    {
        ContatoreMonetePausa.text = PlayerPrefs.GetInt("MonetePossedute", 200).ToString();
        if (MenùGMOV.activeSelf == false)
        {
            MenùPausa.SetActive(true);
            if (PlayerPrefs.GetString("VolumeONOFF", volumeImpostato) == "off")
            {
                suoniBTN.spriteName   = "volumeOFF";
            }
            else
            {
                suoniBTN.spriteName = "volumeON";
            }
            PlayerPrefs.SetString("pausa", "attiva");
        }
    }
    public void resume()
    {
        MenùPausa.SetActive(false);
        PlayerPrefs.SetString("pausa", "NonAttiva");
        MenùPausa.SetActive(false);
        AccSphere.audioPallina.Play();
    }
   
    
    public void BTNSuoni()
    {
        if (PlayerPrefs.GetString("VolumeONOFF","") == "on" || PlayerPrefs.GetString("VolumeONOFF","") == "")
        {
            suoniBTN.spriteName = "volumeOFF";
            PlayerPrefs.SetString("VolumeONOFF", "off");
          //  volumeImpostato = PlayerPrefs.GetString("VolumeONOFF");
        }
        else if (PlayerPrefs.GetString("VolumeONOFF","") == "off")
        {
            suoniBTN.spriteName  = "volumeON";
            PlayerPrefs.SetString("VolumeONOFF","on");
          //  volumeImpostato = PlayerPrefs.GetString("VolumeONOFF");
        }
    }
    

}
