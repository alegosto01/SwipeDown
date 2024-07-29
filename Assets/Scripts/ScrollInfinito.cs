using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollInfinito : MonoBehaviour {


    public Transform posizione;
    public UIButton[] PallineMenù = new UIButton[20];
    public GameObject[] SferaGMOB = new GameObject[22];

    public float ScrollViewPosition = 100;
    public int i = 12;
    public int h = 11;
    public int IncrementoPosizione = 2100;
    public int IncrementoPosizioneIndietro = 2100;
    public UIScrollView Scroll;
    public bool FinitoMovimento = true;
    public bool SpinCliccato = false;
    public float SpintaSpin = 3000;
    public UIPanel Panel;
    public float xScrollView;
    public int RangeFermaPallina;
    public Material[] materialiPalline = new Material[20];
    public Renderer[] PallineMenùRenderer = new Renderer[20];
    public int C = 0;// contatore che aumenta per verificare se una pallina è sbloccata allo start
    public UILabel ContatoreMonete;
    public GameObject Incremento;
    public UILabel IncrementoLabel;
    public GameObject Decremento;
    public UILabel DecrementoLabel;
    public AudioSource SuonoScroll;
    public AudioSource SuonoMonete;
    public AudioSource SuonoSbloccoPallina;
    public float MoneteVinte;
    public float MoneteGenerali;
    public float VelocitaIncrementoDecremento;
    public float TempoAspetta = 0;





    private void Start()
    {

        SuonoScroll = GetComponent<AudioSource>();
        C = 0;
        AssegnamentoMaterialiPalline();
        Debug.Log("assegnamento fatto");
        ContatoreMonete.text = PlayerPrefs.GetInt("MonetePossedute", 200).ToString();
        // SferaGMOB[10].transform.localRotation = new Quaternion(120, 120, 120, 120);
        RotazionePalline();



    }

    void FixedUpdate()
    {
        if (TempoAspetta > 0)
        {
            TempoAspetta = TempoAspetta - Time.deltaTime;
        }
       
        if (PlayerPrefs.GetString("VolumeONOFF", "") == "off")
        {
            SuonoMonete.volume = 0;
            SuonoSbloccoPallina.volume = 0;
            SuonoScroll.volume = 0;
        }
        else
        {
            SuonoMonete.volume = 1;
            SuonoSbloccoPallina.volume = 1;
            SuonoScroll.volume = 1;
        }

        if (Incremento.activeInHierarchy == true)
        {
            if (MoneteVinte > 1)
            {
                MoneteGenerali = MoneteGenerali + VelocitaIncrementoDecremento * Time.deltaTime;
                ContatoreMonete.text = Mathf.Floor(MoneteGenerali).ToString();
                MoneteVinte = MoneteVinte - VelocitaIncrementoDecremento * Time.deltaTime;
                IncrementoLabel.text = "+" + (Mathf.Floor(MoneteVinte)).ToString();
                if(MoneteVinte < 1)
                {

                    if (PlayerPrefs.GetString("VolumeONOFF", "") == "" || PlayerPrefs.GetString("VolumeONOFF", "") == "on")
                    {
                       SuonoMonete.Play();

                    }

                }
            }

            else
            {

                Incremento.SetActive(false);
                ContatoreMonete.text = PlayerPrefs.GetInt("MonetePossedute", 200).ToString();

            }
        }
        /*
        if (Incremento.transform.localPosition.y < 274)
        {
            Incremento.transform.localPosition = Incremento.transform.localPosition + new Vector3(0, 15, 0) * Time.deltaTime;
        }
        else
        {
            Incremento.SetActive(false);
            Incremento.transform.localPosition = new Vector3(130, 255, 0);
            ContatoreMonete.text = PlayerPrefs.GetInt("MonetePossedute").ToString();
        }
        */


        if (Decremento.activeInHierarchy == true)
        {
            if (MoneteVinte > 1)
            {
                MoneteGenerali = MoneteGenerali - VelocitaIncrementoDecremento * Time.deltaTime; 
                ContatoreMonete.text = Mathf.Floor(MoneteGenerali).ToString();
                MoneteVinte = MoneteVinte - VelocitaIncrementoDecremento * Time.deltaTime;
                DecrementoLabel.text = "-" + Mathf.Floor(MoneteVinte).ToString();
            }
            else
            {
                Decremento.SetActive(false);
                ContatoreMonete.text = PlayerPrefs.GetInt("MonetePossedute",200).ToString();
            }
        }
           
           
            /*
            if (Decremento.transform.localPosition.y > 255)
            {
                Decremento.transform.localPosition = Decremento.transform.localPosition - new Vector3(0, 15, 0) * Time.deltaTime;
            }
            else
            {
                Decremento.SetActive(false);
                Decremento.transform.localPosition = new Vector3(130, 276, 0);
            }
            */
        
        SferaGMOB[PlayerPrefs.GetInt("ColoreScelto")].transform.Rotate(-5.5f, -6.75f, 1.75f, Space.World);
       

        if (SpinCliccato == true && FinitoMovimento == false)
        {
            if(TempoAspetta == 0)
            {
                TempoAspetta = 1;
            }
            if (TempoAspetta <= 0)
            {
                Panel.alpha = 0;
                transform.localPosition = transform.localPosition + new Vector3(SpintaSpin, 0, 0) * Time.deltaTime;
                if (SpintaSpin > 200)
                {
                    SpintaSpin = SpintaSpin - 500 * Time.deltaTime;
                }
                else if (transform.localPosition.x + PallineMenù[PlayerPrefs.GetInt("NPallinaEstratta")].transform.localPosition.x > -1 && transform.localPosition.x + PallineMenù[PlayerPrefs.GetInt("NPallinaEstratta")].transform.localPosition.x < 1)
                {
                    SpinCliccato = false;
                    SpintaSpin = 3000;
                    Panel.clipOffset = new Vector2(-transform.localPosition.x, 0);
                    FinitoMovimento = true;
                    Panel.alpha = 1;
                    if (PlayerPrefs.GetString("Palla" + PlayerPrefs.GetInt("NPallinaEstratta"), "Bloccata") == "Sbloccata")
                    {
                        if (PlayerPrefs.GetInt("NPallinaEstratta") <= 10)
                        {
                            //PlayerPrefs.SetInt("MonetePossedute", PlayerPrefs.GetInt("MonetePossedute") + 15);
                            Incremento.SetActive(true);
                            MoneteVinte = 15;
                            PlayerPrefs.SetInt("MonetePossedute", PlayerPrefs.GetInt("MonetePossedute", 200) + 15);
                            VelocitaIncrementoDecremento = 15;
                        }
                        else if (PlayerPrefs.GetInt("NPallinaEstratta") <= 17)
                        {

                            // PlayerPrefs.SetInt("MonetePossedute", PlayerPrefs.GetInt("MonetePossedute") + 40);
                            Incremento.SetActive(true);
                            MoneteVinte = 40;
                            PlayerPrefs.SetInt("MonetePossedute", PlayerPrefs.GetInt("MonetePossedute", 200) + 40);

                            VelocitaIncrementoDecremento = 20;
                        }
                        else if (PlayerPrefs.GetInt("NPallinaEstratta") <= 21)
                        {
                            PlayerPrefs.SetInt("MonetePossedute", PlayerPrefs.GetInt("MonetePossedute", 200) + 75);
                            Incremento.SetActive(true);
                            MoneteVinte = 75;
                            VelocitaIncrementoDecremento = 30;

                        }
                    }
                    else
                    {

                        if (PlayerPrefs.GetString("VolumeONOFF", "") == "" || PlayerPrefs.GetString("VolumeONOFF", "") == "on")
                        {
                            SuonoSbloccoPallina.Play();

                        }
                        PlayerPrefs.SetString("Palla" + PlayerPrefs.GetInt("NPallinaEstratta").ToString(), "Sbloccata");
                        PallineMenùRenderer[PlayerPrefs.GetInt("NPallinaEstratta")].sharedMaterial = materialiPalline[PlayerPrefs.GetInt("NPallinaEstratta")];

                    }
                }
            }
        }
        if (transform.localPosition.x < -ScrollViewPosition)
        {
            if (i == 0)
            {
                PallineMenù[i].transform.localPosition = new Vector3(IncrementoPosizione, 0, 0);

                i = i + 1;
                if (h == 21)
                {
                    h = 0;
                }
                else
                {
                    h = h + 1;
                }
                IncrementoPosizione = IncrementoPosizione + 100;
                IncrementoPosizioneIndietro = IncrementoPosizioneIndietro - 100;
                ScrollViewPosition = ScrollViewPosition + 100;
            }
            else if (i != 21)
            {
                PallineMenù[i].transform.localPosition = new Vector3(IncrementoPosizione, 0, 0);

                i = i + 1;
                if(h == 21)
                {
                    h = 0;
                }
                else
                {
                h = h + 1;
                }
                IncrementoPosizione = IncrementoPosizione + 100;
                IncrementoPosizioneIndietro = IncrementoPosizioneIndietro - 100;
                ScrollViewPosition = ScrollViewPosition + 100;

            }
            else
            {
                PallineMenù[i].transform.localPosition = new Vector3(IncrementoPosizione, 0, 0);

                i = 0;
                if (h == 21)
                {
                    h = 0;
                }
                else
                {
                    h = h + 1;
                }
                IncrementoPosizione = IncrementoPosizione + 100;
                IncrementoPosizioneIndietro = IncrementoPosizioneIndietro - 100;
                ScrollViewPosition = ScrollViewPosition + 100;

            }
        }
        if(transform.localPosition.x > -ScrollViewPosition + 100)
        {
            if (h == 0)
            {
                PallineMenù[h].transform.localPosition = new Vector3(-IncrementoPosizioneIndietro, 0, 0);
                if(FinitoMovimento == false)
                {

                    if (PlayerPrefs.GetString("VolumeONOFF", "") == "" || PlayerPrefs.GetString("VolumeONOFF", "") == "on")
                    {
                    SuonoScroll.Play();

                    }

                }

                h = 21;
                if (i == 0)
                {
                    i = 21;
                }
                else
                {
                    i = i - 1;

                }
                IncrementoPosizioneIndietro = IncrementoPosizioneIndietro + 100;
                IncrementoPosizione = IncrementoPosizione - 100;
                ScrollViewPosition = ScrollViewPosition - 100;

            }
            else if (h != 21)
            {
                PallineMenù[h].transform.localPosition = new Vector3(-IncrementoPosizioneIndietro, 0, 0);
                if (FinitoMovimento == false)
                {

                    if (PlayerPrefs.GetString("VolumeONOFF", "") == "" || PlayerPrefs.GetString("VolumeONOFF", "") == "on")
                    {
                    SuonoScroll.Play();

                    }

                }
                h = h - 1;
                if(i == 0)
                {
                    i = 21;
                }
                else
                {
                i = i - 1;

                }

                IncrementoPosizioneIndietro = IncrementoPosizioneIndietro + 100;
                IncrementoPosizione = IncrementoPosizione - 100;
                ScrollViewPosition = ScrollViewPosition - 100;
            }
            else
            {
                PallineMenù[h].transform.localPosition = new Vector3(-IncrementoPosizioneIndietro, 0, 0);
                if (FinitoMovimento == false)
                {
                    SuonoScroll.Play();

                }
                h = h -1;
                if (i == 0)
                {
                    i = 21;
                }
                else
                {
                    i = i - 1;
                }
                IncrementoPosizioneIndietro = IncrementoPosizioneIndietro + 100;
                IncrementoPosizione = IncrementoPosizione - 100;
                ScrollViewPosition = ScrollViewPosition - 100;
            }
        }
    }
    public void Resetto1()
    {
        SpringPanel.Begin(gameObject, new Vector3(0, 0, 0), 8f);
    }
    public void Resetto2()
    {
        ScrollViewPosition = 3000;
        IncrementoPosizione = 15000;
        i = 0;
       /* PallineMenù[0].transform.localPosition = new Vector3(-100, 0, 0);
        PallineMenù[1].transform.localPosition = new Vector3(0, 0, 0);
        PallineMenù[2].transform.localPosition = new Vector3(100, 0, 0);
        PallineMenù[3].transform.localPosition = new Vector3(6000, 0, 0);
        PallineMenù[4].transform.localPosition = new Vector3(9000, 0, 0);
        PallineMenù[5].transform.localPosition = new Vector3(12000, 0, 0);
        */
    }
    public void AssegnamentoMaterialiPalline()
    {
        if (PlayerPrefs.GetString("Palla0","Sbloccata") == "Sbloccata")
        {
            PallineMenùRenderer[0].sharedMaterial = materialiPalline[0];
        }
        if (PlayerPrefs.GetString("Palla1") == "Sbloccata")
        {
            PallineMenùRenderer[1].sharedMaterial = materialiPalline[1];
        }
        if (PlayerPrefs.GetString("Palla2") == "Sbloccata")
        {
            PallineMenùRenderer[2].sharedMaterial = materialiPalline[2];
        }
        if (PlayerPrefs.GetString("Palla3") == "Sbloccata")
        {
            PallineMenùRenderer[3].sharedMaterial = materialiPalline[3];
        }
        if (PlayerPrefs.GetString("Palla4") == "Sbloccata")
        {
            PallineMenùRenderer[4].sharedMaterial = materialiPalline[4];
        }
        if (PlayerPrefs.GetString("Palla5") == "Sbloccata")
        {
            PallineMenùRenderer[5].sharedMaterial = materialiPalline[5];
        }
        if (PlayerPrefs.GetString("Palla6") == "Sbloccata")
        {
            PallineMenùRenderer[6].sharedMaterial = materialiPalline[6];
        }
        if (PlayerPrefs.GetString("Palla7") == "Sbloccata")
        {
            PallineMenùRenderer[7].sharedMaterial = materialiPalline[7];
        }
        if (PlayerPrefs.GetString("Palla8") == "Sbloccata")
        {
            PallineMenùRenderer[8].sharedMaterial = materialiPalline[8];
        }
        if (PlayerPrefs.GetString("Palla9") == "Sbloccata")
        {
            PallineMenùRenderer[9].sharedMaterial = materialiPalline[9];
        }
        if (PlayerPrefs.GetString("Palla10") == "Sbloccata")
        {
            PallineMenùRenderer[10].sharedMaterial = materialiPalline[10];
        }
        if (PlayerPrefs.GetString("Palla11") == "Sbloccata")
        {
            PallineMenùRenderer[11].sharedMaterial = materialiPalline[11];
        }
        if (PlayerPrefs.GetString("Palla12") == "Sbloccata")
        {
            PallineMenùRenderer[12].sharedMaterial = materialiPalline[12];
        }
        if (PlayerPrefs.GetString("Palla13") == "Sbloccata")
        {
            PallineMenùRenderer[13].sharedMaterial = materialiPalline[13];
        }
        if (PlayerPrefs.GetString("Palla14") == "Sbloccata")
        {
            PallineMenùRenderer[14].sharedMaterial = materialiPalline[14];
        }
        if (PlayerPrefs.GetString("Palla15") == "Sbloccata")
        {
            PallineMenùRenderer[15].sharedMaterial = materialiPalline[15];
        }
        if (PlayerPrefs.GetString("Palla16") == "Sbloccata")
        {
            PallineMenùRenderer[16].sharedMaterial = materialiPalline[16];
        }
        if (PlayerPrefs.GetString("Palla17") == "Sbloccata")
        {
            PallineMenùRenderer[17].sharedMaterial = materialiPalline[17];
        }
        if (PlayerPrefs.GetString("Palla18") == "Sbloccata")
        {
            PallineMenùRenderer[18].sharedMaterial = materialiPalline[18];
        }
        if (PlayerPrefs.GetString("Palla19" ) == "Sbloccata")
        {
            PallineMenùRenderer[19].sharedMaterial = materialiPalline[19];
            C++;
        }
        if (PlayerPrefs.GetString("Palla20") == "Sbloccata")
        {
            PallineMenùRenderer[20].sharedMaterial = materialiPalline[20];
            C++;
        }
        if (PlayerPrefs.GetString("Palla21") == "Sbloccata")
        {
            PallineMenùRenderer[21].sharedMaterial = materialiPalline[21];
            C++;
        }

    }
    public void RotazionePalline()
    {
        SferaGMOB[0].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[1].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[2].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[3].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[4].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[5].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[6].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[7].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[8].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[9].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[10].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[11].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[12].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[13].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[14].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[15].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[16].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[17].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[18].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[19].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[20].transform.localRotation = new Quaternion(0, 0, 0, 0);
        SferaGMOB[21].transform.localRotation = new Quaternion(0, 0, 0, 0);



    }
   
}
