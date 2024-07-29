using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sphereScript : MonoBehaviour
{
    public Touch VariabileTouch;
    public int MonetePartita;
    public GameObject Sphere;
    public Rigidbody sfera;
    public bool pausa;
    public GameObject moneta;
    public int collisioni;
    public GameObject menùGameover;
    public float speedy = 0;
    public float speedx = 0;
    public MainCamera accCamera;
    public bool destra = false;
    public bool velMax = false;
    public sfondoScript accSfondo;
    public bool finitoMovimento = false;
    public Text punteggio;
    public float velocitàProva = 1;
    public int i = 0;
    public float intervalloRipristinoSpawn;
    public float tempoCambioDirezione;
    public GameObject CameraAlternanza;
   // public AudioClip suonoPassaggio;
    public AudioClip suonoMonete;
    public AudioSource audioPallina;
    public AudioClip soundtrack;
    public float rotazionexy = 5f;
    public bool UnAumento = false;
    public Renderer rend;
    public bool divietoMovimentoIniziale = true;
    public Material materiale2;
    public GameObject[] Glow = new GameObject [6];
    public Text monete;
    public int ScoreMonete = 0;
    public buttonManagerMenù accButtonManager;
    public Material materialeUsato;
    public bool morto = false;
    public float tempo;
    public float OreDiGioco;
    public bool spawnato = false;
    public GameObject[] allBlocchiSX = new GameObject[11];
    public GameObject[] allBlocchiDX = new GameObject[11];
    public GameObject[] allBlocchiSX50 = new GameObject[12];
    public GameObject[] allBlocchiDX50 = new GameObject[12];
    public GameObject[] allBlocchiSX100 = new GameObject[3];
    public GameObject[] allBlocchiDX100 = new GameObject[3];
    public int random;
    public int random50;
    public int random100;

    public int volumeImpostato;
    public GameObject posSX;
    public GameObject posDX;
    public GameObject posEnd;
    public GameObject posMaxSX;
    public GameObject posMaxDX;
    public Material[] materialiPalline = new Material[20];
    public Touch touch ;
    public float SpintaAllaMorte = 10f;
    int IndicatoreMonete = 0;
    public GameObject TapToChangeGMOB;
    public Rigidbody RigidSfera;
    public GameObject monetablu;
    public GameObject MenùPausa;
   public GameObject MissionCompleated;
    public bool MovimentoMissionCompleated = false;
    public GameObject[] Counter = new GameObject[3];
    public UILabel[] CountelLabel = new UILabel[3];
    public bool FinitoCounter = false;
    public buttonManager AccButtonManagerAlternanza;
    public float BloccoRestart = 3f;
    public int[] DaFareStep1 = new int[] { 50, 50, 10, 10, 10, 100, 10 };
    public int[] DaFareStep2 = new int[] { 200, 200, 50, 100, 40, 500, 50 };
    public int[] DaFareStep3 = new int[] { 500, 500, 100, 500, 75, 1000, 200 };
    public GameObject ContatoreMonete;
    public UILabel LabelContatoreMonete;
    public float TimerRestart = 1;
    public AdsManager AccAdsManager;
    
    public Vector3[] direzioni = new Vector3[4] { new Vector3(100, 0, 0), new Vector3(-100, 0, 0), new Vector3(60, -80, 0), new Vector3(-60, -80, 0) };

    private void Awake()
    {
    }
    void Start()
    {
       
        PlayerPrefs.SetInt("DistanzaPartita", 0);
        
        audioPallina = GetComponent<AudioSource>();
        rend.sharedMaterial = materialiPalline[PlayerPrefs.GetInt("ColoreScelto", 0)];
        volumeImpostato = PlayerPrefs.GetInt("VolumeONOFF");
        //sfera.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
        //accButtonManager = GameObject.FindWithTag("buttonManagerMenù").GetComponent<buttonManagerMenù>();
        if (PlayerPrefs.GetString("VolumeONOFF", "") == "" || PlayerPrefs.GetString("VolumeONOFF", "") == "on")
        {
            audioPallina.Play();
        }
        
    }
   
    private void FixedUpdate()
    {
        if (PlayerPrefs.GetString("VolumeONOFF", "") == "" || PlayerPrefs.GetString("VolumeONOFF", "") == "on")
        {
            audioPallina.volume = 1;
        }
        else
        {
            audioPallina.volume = 0;
        }
        if (ContatoreMonete.activeInHierarchy == true)
        {
            ContatoreMonete.transform.localScale = ContatoreMonete.transform.localScale + new Vector3(0.5f, 0.5f, 0) * Time.deltaTime;
            if(ContatoreMonete.transform.localScale.x > 1.5f)
            {
                ContatoreMonete.SetActive(false);
                ContatoreMonete.transform.localScale = new Vector3(1, 1, 1);
                
            }
        }
        if(morto == true)
        {
            //TimerRestart = TimerRestart - 1 * Time.deltaTime;
        }
        if(speedx < 0.39 && MenùPausa.activeInHierarchy == false)
        {
            speedx = speedx + 0.39f / 10 * Time.deltaTime;
            speedy = speedy + 0.26f / 10 * Time.deltaTime;
        }
       
        if (MenùPausa.activeInHierarchy == false)
        {
            if (FinitoCounter == false && Counter[0].activeInHierarchy == true)
            {
                if (Counter[0].transform.localScale.x <= 1.5f)
                {
                    Counter[0].transform.localScale = Counter[0].transform.localScale + new Vector3(0.5f, 0.5f, 0) * Time.deltaTime;
                }
                else
                {
                    Counter[0].SetActive(false);
                    Counter[0].transform.localScale = new Vector3(1, 1, 1);
                    Counter[1].SetActive(true);
                }
            }
            else if (FinitoCounter == false && Counter[1].activeInHierarchy == true)
            {
                if (Counter[1].transform.localScale.x <= 1.5f)
                {
                    Counter[1].transform.localScale = Counter[1].transform.localScale + new Vector3(0.5f, 0.5f, 0) * Time.deltaTime;
                }
                else
                {
                    Counter[1].SetActive(false);
                    Counter[1].transform.localScale = new Vector3(1, 1, 1);
                    Counter[2].SetActive(true);
                }
            }
            else if (FinitoCounter == false && Counter[2].activeInHierarchy == true)
            {
                if (Counter[2].transform.localScale.x <= 1.5f)
                {
                    Counter[2].transform.localScale = Counter[2].transform.localScale + new Vector3(0.5f, 0.5f, 0) * Time.deltaTime;
                }
                else
                {
                    Counter[2].SetActive(false);
                    Counter[2].transform.localScale = new Vector3(1, 1, 1);
                    FinitoCounter = true;
                }
            }
        }
       /*  if (MissionCompleated.activeInHierarchy == true )
        {
            if (MovimentoMissionCompleated == false && MissionCompleated.transform.localPosition.y > 270)
            {
                MissionCompleated.transform.localPosition = MissionCompleated.transform.localPosition - new Vector3(0, 20, 0) * Time.deltaTime;
                if(MissionCompleated.transform.localPosition.y <= 270)
                {
                    MovimentoMissionCompleated = true;
                }
            }
            else
            {
                MissionCompleated.transform.localPosition = MissionCompleated.transform.localPosition + new Vector3(0, 20, 0) * Time.deltaTime;
                if(MissionCompleated.transform.localPosition.y >= 320)
                {
                    MissionCompleated.SetActive(false);
                    MissionCompleated.transform.localPosition = new Vector3(MissionCompleated.transform.localPosition.x, 320, MissionCompleated.transform.localPosition.z);
                    MovimentoMissionCompleated = false;
                }
            }
            
        }
        */

        if(MenùPausa.activeInHierarchy == true)
        {
            audioPallina.Pause();
        }
        if (CameraAlternanza.activeSelf == true && MenùPausa.activeInHierarchy == false && FinitoCounter == true )
        {
            speedx = speedx + 0.0009f * Time.deltaTime; // 0,0006
            speedy = speedy + 0.0006f * Time.deltaTime; // 0,0004
        }
        if(tempoCambioDirezione >= 0 && Input.touchCount == 0) //&& Input.GetTouch(0).phase != TouchPhase.Stationary)
        {
            tempoCambioDirezione = tempoCambioDirezione - Time.deltaTime;
        }
        if(morto == true & audioPallina.pitch > 0)
        {
            audioPallina.pitch = audioPallina.pitch - 1 * Time.deltaTime;
            
        }
        if(audioPallina.pitch < 0)
        {
            audioPallina.pitch = 0;
            audioPallina.volume = 0;
        }
        /*
        if(speedy  < 0.2f & speedx < 0.3f)// evitare lo scatto al cambio direzione
        {
            speedx = speedx + 9 * Time.deltaTime;
            speedy = speedy + 6 * Time.deltaTime;
        }*/
       
       
        if (MenùPausa.activeInHierarchy == false)
        {
            PlayerPrefs.SetFloat("OreDiGioco", PlayerPrefs.GetFloat("OreDiGioco", 0) + Time.deltaTime);
        }
        //Glow.transform.position = Sphere.transform.position;
        //Instantiate(Glow[1], new Vector3(Sphere.transform.position.x, Sphere.transform.position.y, 0), Quaternion.identity);
        punteggio.text = PlayerPrefs.GetInt("DistanzaPartita", 0).ToString();
     /*if(PlayerPrefs.GetInt("DistanzaPartita", 0) == 5 && UnAumento == false || PlayerPrefs.GetInt("DistanzaPartita", 0) == 10 & UnAumento == false) // da sistemare unaumento == false
        {
            speedy = speedy + 0.02f ;
            speedx = speedx + 0.03f ;
            UnAumento = true;
        }
        else if (PlayerPrefs.GetInt("DistanzaPartita", 0) == 20 & UnAumento == false)
        {
                speedx = speedx + 0.02f ;
                speedy = speedy + 0.03f ;
            UnAumento = true;
        }
        if(PlayerPrefs.GetInt("DistanzaPartita", 0) == 19 || PlayerPrefs.GetInt("DistanzaPartita", 0) == 9)
        {
            UnAumento = false;
        }*/
       if(collisioni == 1)
        {
            sfera.AddForce(new Vector3(0, -SpintaAllaMorte, 0), ForceMode.Acceleration);
            if(destra == true)
            {
                destra = false;
            }
            else
            {
                destra = true;
            }
        }
       else if(collisioni == 2)
        {

            gameObject.SetActive(false);
        }

        /*if (transform.position.y != 23)
        
        {
            sfera.AddForce(new Vector3(0, -10, 0), ForceMode.Acceleration);
        }
        // Sphere.transform.Rotate(direzioni[i] * Time.deltaTime);
        //transform.position = transform.position - new Vector3(0, speedy, 0);
        /*if (finitoMovimento == false )
        {
            transform.position = transform.position + new Vector3(0, 0.1f, 0);
            if(transform.position.y > 25)
            {
                finitoMovimento = true;
            }
        }
        else
        {
            transform.position = transform.position - new Vector3(0, speedy, 0);
        }*/

        /*if (transform.position.y > 22)
        {
            divietoMovimentoIniziale = false;
        }*/

        if (transform.position.y < 40)
        {
            FinitoCounter = true;
        }
        if (FinitoCounter == false)
        {
            transform.Rotate(-5.5f, 0, 0, Space.World);

        }
        else if (destra == true)
        {
            transform.Rotate(-5.5f, -6.75f, 1.75f, Space.World);
        }
        else if (destra == false)
        {
            transform.Rotate(-5.5f, 6.75f, -1.75f, Space.World);
        }
        if (transform.position.y < 40)
        {
            impostaBool();
        }
        impostaBool();
        zigzagTap();

        RipristinaSpawnato();
    }
    private void OnCollisionEnter(Collision collision)
    {

        
        collisioni++;
        morto = true;
        AccButtonManagerAlternanza.morto = true;
        if (collision.gameObject.tag == "gameover")
        {
            morto = true;

            collisioni = 2;
        }
        if (collisioni == 2)
        {
            transform.Rotate(0, 0, 0);
        }

        if (destra == true)
        {
            if (collisioni == 1)
            {
                PlayerPrefs.SetInt("SeriePartite", PlayerPrefs.GetInt("SeriePartite", 0) + 1);
                Debug.Log(PlayerPrefs.GetInt("SeriePartite",0));
                sfera.AddForce(sfera.transform.position.x * 0.05f, 0, 0, ForceMode.Force);
                //PlayerPrefs.Save();
            }
            speedx = 0;
            speedy = 0;
            accCamera.morto_vivo = true;
            if (PlayerPrefs.GetInt("SeriePartite", 0) == 3)
            {
                AccAdsManager.ShowAd();
                Debug.Log("ele");
                PlayerPrefs.SetInt("SeriePartite", 0);
            }
            PlayerPrefs.SetInt("RecordPartiteGiocate", PlayerPrefs.GetInt("RecordPartiteGiocate", 0) + 1);
            if (PlayerPrefs.GetInt("RecordPartiteGiocate", 0) >= accButtonManager.GestioneMissione4())
            {
                MissionCompleated.SetActive(true);
            }
            MoneteTotali();
            //morto = true;

        }
        else if (destra == false)
        {
            if (collisioni == 1)
            {
                PlayerPrefs.SetInt("SeriePartite", PlayerPrefs.GetInt("SeriePartite", 0) + 1);
                Debug.Log(PlayerPrefs.GetInt("SeriePartite", 0));

                sfera.AddForce(-sfera.transform.position.x * 0.05f, 0, 0, ForceMode.Force);
            }
            speedx = 0;
            speedy = 0;
            accCamera.morto_vivo = true;
            if (PlayerPrefs.GetInt("SeriePartite",0) == 3)
            {
                
                AccAdsManager.ShowAd();
                PlayerPrefs.SetInt("SeriePartite",0);
            }
            PlayerPrefs.SetInt("RecordPartiteGiocate", PlayerPrefs.GetInt("RecordPartiteGiocate", 0) + 1);
            MoneteTotali();
            
            //morto = true;

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "moneta")
        {
            //audioPallina.PlayOneShot(suonoMonete);

            PlayerPrefs.SetInt("MoneteRaccolte", PlayerPrefs.GetInt("MoneteRaccolte", 0) + 1);
           
            PlayerPrefs.SetInt("MonetePossedute", PlayerPrefs.GetInt("MonetePossedute", 200) + 1);

            MonetePartita++;
            ContatoreMonete.SetActive(true);
            LabelContatoreMonete.text = MonetePartita.ToString();

            if (MonetePartita >= PlayerPrefs.GetInt("RecordMonetePartita",0))
            {
                PlayerPrefs.SetInt("RecordMonetePartita", MonetePartita);
            }
            if (PlayerPrefs.GetInt("MoneteRaccolte") >= GestioneMissione6())
            {
                MissionCompleated.SetActive(true);
            }
            if (MonetePartita >= GestioneMissione5())
            {
                MissionCompleated.SetActive(true);
            }

        }
        else if(other.gameObject.tag == "monetablu")

            {
           
            PlayerPrefs.SetInt("MoneteRaccolte", PlayerPrefs.GetInt("MoneteRaccolte", 0) + 5);
           
            PlayerPrefs.SetInt("MonetePossedute", PlayerPrefs.GetInt("MonetePossedute", 200) + 5);

            MonetePartita = MonetePartita + 5;
            ContatoreMonete.SetActive(true);

            LabelContatoreMonete.text = MonetePartita.ToString();

            if (PlayerPrefs.GetInt("MoneteRaccolte") >= GestioneMissione6())
            {
                MissionCompleated.SetActive(true);
            }
            if (MonetePartita >= GestioneMissione5())
            {
                MissionCompleated.SetActive(true);
            }
            if (MonetePartita >= PlayerPrefs.GetInt("RecordMonetePartita", 0))
            {
                PlayerPrefs.SetInt("RecordMonetePartita", MonetePartita);
            }
        }
        accSfondo.impostaBackground();
       
       
        if(other.gameObject.tag == "centraleDX" & spawnato == false)
        {
            if (IndicatoreMonete == 9)
            {
                Instantiate(monetablu, new Vector3(Random.Range(posDX.transform.position.x - 9, posDX.transform.position.x + 9), Random.Range(posDX.transform.position.y - 5, posDX.transform.position.y - 18), -1f), Quaternion.Euler(0, 0, 90)); // 0,0,90
                IndicatoreMonete = 0;
            }
            else
            {
                IndicatoreMonete++;
                Instantiate(moneta, new Vector3(Random.Range(posDX.transform.position.x - 9, posDX.transform.position.x + 9), Random.Range(posDX.transform.position.y -5, posDX.transform.position.y - 18), -1f), Quaternion.Euler(0, 0, 90)); // 0,0,90
            }
            spawnCasuale();
            spawnCasuale50();
            spawnCasuale100();

            Instantiate(allBlocchiDX[random], posDX.transform.position, Quaternion.identity);

            posDX.transform.position = posDX.transform.position + new Vector3(22, -25, 0);
            posSX.transform.position = posDX.transform.position + new Vector3(-44, 0, 0);
            posEnd.transform.position = posEnd.transform.position - new Vector3(25, 0, 0);
            impostaMaxBasso();
            impostaMaxDX();
            //audioPallina.PlayOneShot(suonoPassaggio);       
            PlayerPrefs.SetInt("DistanzaPercorsa", PlayerPrefs.GetInt("DistanzaPercorsa", 0) + 1);

            PlayerPrefs.SetInt("DistanzaPartita", PlayerPrefs.GetInt("DistanzaPartita", 0) + 1);
           
            if (PlayerPrefs.GetInt("DistanzaPartita", 0) > PlayerPrefs.GetInt("RecordDistanza", 0))
            {
                PlayerPrefs.SetInt("RecordDistanza", PlayerPrefs.GetInt("DistanzaPartita", 0));
            }
            spawnato = true;
            PlayerPrefs.SetInt("VolteADestra", PlayerPrefs.GetInt("VolteADestra", 0) + 1);
            if (PlayerPrefs.GetInt("DistanzaPartita", 0) == GestioneMissione3())
            {
                MissionCompleated.SetActive(true);
            }

            Destroy(other);
        }
        else if(other.gameObject.tag == "centraleSX")
        {
            if (IndicatoreMonete == 9)
            {
                Instantiate(monetablu, new Vector3(Random.Range(posSX.transform.position.x - 9, posSX.transform.position.x + 9), Random.Range(posDX.transform.position.y - 5, posDX.transform.position.y - 18), -1f), Quaternion.Euler(0, 0, 90));

                IndicatoreMonete = 0;

            }
            else
            {
                IndicatoreMonete++;
                Instantiate(moneta, new Vector3(Random.Range(posSX.transform.position.x - 9, posSX.transform.position.x + 9), Random.Range(posDX.transform.position.y - 5, posDX.transform.position.y - 18), -1f), Quaternion.Euler(0, 0, 90));
            }
            //Instantiate(moneta, new Vector3(Random.Range(posSX.transform.position.x - 9, posSX.transform.position.x + 9), Random.Range(posDX.transform.position.y, posDX.transform.position.y - 22), -1f), Quaternion.Euler(0, 0, 90));
            spawnCasuale();
            spawnCasuale50();
            spawnCasuale100();

            Instantiate(allBlocchiSX[random], posSX.transform.position, Quaternion.identity);
            

            posSX.transform.position = posSX.transform.position + new Vector3(-22, -25, 0);
            posDX.transform.position = posSX.transform.position + new Vector3(44, 0, 0);
            posEnd.transform.position = posEnd.transform.position - new Vector3(25, 0, 0);
            impostaMaxBasso();
            impostaMaxSX();
            //audioPallina.PlayOneShot(suonoPassaggio);
            PlayerPrefs.SetInt("DistanzaPercorsa", PlayerPrefs.GetInt("DistanzaPercorsa", 0) + 1);
            PlayerPrefs.SetInt("DistanzaPartita", PlayerPrefs.GetInt("DistanzaPartita", 0) + 1);
           
            if (PlayerPrefs.GetInt("DistanzaPartita", 0) > PlayerPrefs.GetInt("RecordDistanza", 0))
            {
                PlayerPrefs.SetInt("RecordDistanza", PlayerPrefs.GetInt("DistanzaPartita", 0));
            }
            spawnato = true;
            PlayerPrefs.SetInt("VolteASinistra", PlayerPrefs.GetInt("VolteASinistra", 0) + 1);
            if (PlayerPrefs.GetInt("DistanzaPartita", 0) == GestioneMissione3())
            {
                MissionCompleated.SetActive(true);
            }
            Destroy(other);
        }
        else if(other.gameObject.tag == "centraleOstacoloDX" & spawnato == false)
        {
            if (IndicatoreMonete == 9)
            {
                Instantiate(monetablu, new Vector3(Random.Range(posDX.transform.position.x - 9, posDX.transform.position.x + 9), Random.Range(posDX.transform.position.y - 5, posDX.transform.position.y - 18), -1f), Quaternion.Euler(0, 0, 90)); // 0,0,90
                IndicatoreMonete = 0;
            }
            else
            {
                IndicatoreMonete++;
                Instantiate(moneta, new Vector3(Random.Range(posDX.transform.position.x - 9, posDX.transform.position.x + 9), Random.Range(posDX.transform.position.y - 5, posDX.transform.position.y - 18), -1f), Quaternion.Euler(0, 0, 90)); // 0,0,90
            }
            

            spawnCasuale();
            spawnCasuale50();
            spawnCasuale100();

            Instantiate(allBlocchiDX[random], posDX.transform.position, Quaternion.identity);

            posDX.transform.position = posDX.transform.position + new Vector3(22, -25, 0);
            posSX.transform.position = posDX.transform.position + new Vector3(-44, 0, 0);
            posEnd.transform.position = posEnd.transform.position - new Vector3(25, 0, 0);
            impostaMaxBasso();
            impostaMaxDX();
            PlayerPrefs.SetInt("OstacoliSuperati", PlayerPrefs.GetInt("OstacoliSuperati", 0) + 1);
              
            // audioPallina.PlayOneShot(suonoPassaggio);
            PlayerPrefs.SetInt("DistanzaPercorsa", PlayerPrefs.GetInt("DistanzaPercorsa", 0) + 1);
            PlayerPrefs.SetInt("DistanzaPartita", PlayerPrefs.GetInt("DistanzaPartita", 0) + 1);
           
            if (PlayerPrefs.GetInt("DistanzaPartita", 0) > PlayerPrefs.GetInt("RecordDistanza", 0))
            {
                PlayerPrefs.SetInt("RecordDistanza", PlayerPrefs.GetInt("DistanzaPartita", 0));
            }
            spawnato = true;
            PlayerPrefs.SetInt("VolteADestra", PlayerPrefs.GetInt("VolteADestra", 0) + 1);
            if (PlayerPrefs.GetInt("OstacoliSuperati", 0) == GestioneMissione7())
            {
                MissionCompleated.SetActive(true);
            }
            if (PlayerPrefs.GetInt("DistanzaPartita", 0) == GestioneMissione3())
            {
                MissionCompleated.SetActive(true);
            }
            Destroy(other);
        }
        else if(other.gameObject.tag == "centraleOstacoloSX" & spawnato == false)
        {
            if (IndicatoreMonete == 9)
            {
                Instantiate(monetablu, new Vector3(Random.Range(posSX.transform.position.x - 9, posSX.transform.position.x + 9), Random.Range(posDX.transform.position.y - 5, posDX.transform.position.y - 18), -1f), Quaternion.Euler(0, 0, 90));
                IndicatoreMonete = 0;
            }
            else
            {
                IndicatoreMonete++;
                Instantiate(moneta, new Vector3(Random.Range(posSX.transform.position.x - 9, posSX.transform.position.x + 9), Random.Range(posDX.transform.position.y - 5, posDX.transform.position.y - 18), -1f), Quaternion.Euler(0, 0, 90));
            }
           // PlayerPrefs.SetInt("OstacoliEvitati", PlayerPrefs.GetInt("OstacoliEvitati", 0) + 1);
            spawnCasuale();
            spawnCasuale50();
            spawnCasuale100();

            Instantiate(allBlocchiSX[random], posSX.transform.position, Quaternion.identity);

            posSX.transform.position = posSX.transform.position + new Vector3(-22, -25, 0);
            posDX.transform.position = posSX.transform.position + new Vector3(44, 0, 0);
            posEnd.transform.position = posEnd.transform.position - new Vector3(25, 0, 0);
            impostaMaxBasso();
            impostaMaxSX();
            PlayerPrefs.SetInt("OstacoliSuperati", PlayerPrefs.GetInt("OstacoliSuperati", 0) + 1);
           
            // audioPallina.PlayOneShot(suonoPassaggio);
            PlayerPrefs.SetInt("DistanzaPercorsa", PlayerPrefs.GetInt("DistanzaPercorsa", 0) + 1);
            PlayerPrefs.SetInt("DistanzaPartita", PlayerPrefs.GetInt("DistanzaPartita", 0) + 1);
           
            if (PlayerPrefs.GetInt("DistanzaPartita", 0) > PlayerPrefs.GetInt("RecordDistanza", 0))
            {
                PlayerPrefs.SetInt("RecordDistanza", PlayerPrefs.GetInt("DistanzaPartita", 0));
            }
            spawnato = true;
            PlayerPrefs.SetInt("VolteASinistra", PlayerPrefs.GetInt("VolteASinistra", 0) + 1);
            if (PlayerPrefs.GetInt("OstacoliSuperati", 0) == GestioneMissione7())
            {
                MissionCompleated.SetActive(true);
            }
            if (PlayerPrefs.GetInt("DistanzaPartita", 0) == GestioneMissione3())
            {
                MissionCompleated.SetActive(true);
            }
            Destroy(other);
        }
    }
    public void VaiDXSX()
    {
        if (Input.GetKey(KeyCode.D))
        {
            /* if (GameObject.FindGameObjectWithTag("menùpausa").activeInHierarchy == false)
             {
                 Debug.Log("attiva");
                 transform.position = transform.position + new Vector3(0.3f, spostamentoYdx, 0);
             }
             else
             {

             }
            i = 2;
            transform.position = transform.position + new Vector3(0.5f, spostamentoYdx, 0);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            if (GameObject.FindGameObjectWithTag("menùpausa").activeSelf == true )
            {

            }
            else
            {
                transform.position = transform.position - new Vector3(0.3f, spostamentoYsx, 0);
            }
            i = 3;
            transform.position = transform.position - new Vector3(0.5f, spostamentoYsx, 0);
        }
        else
        {
            i = 1;
        */
        }
    }
    public void zigzagPremuto()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            transform.position = transform.position - new Vector3(speedx, speedy, 0);
        }
        else
        {
            transform.position = transform.position - new Vector3(-speedx, speedy, 0);
        }
    }
    public void zigzagTap()
    {
        if(FinitoCounter == false && MenùPausa.activeInHierarchy == false)
        {
            transform.position = transform.position - new Vector3(0, speedy, 0);
        }
        else if (morto == false && MenùPausa.activeInHierarchy == false && CameraAlternanza.activeSelf == true)
        {
            if (destra == false)
            {
                transform.position = transform.position - new Vector3(speedx, speedy, 0);
            }
            else
            {
                transform.position = transform.position - new Vector3(-speedx, speedy, 0);
            }
        }
    }
    public void impostaBool()
    {
       
     //  if (Input.GetKey(KeyCode.A) && tempoCambioDirezione < 0)
        if (Input.touchCount > 0 && tempoCambioDirezione < 0 && Input.GetTouch(0).position.y < Screen.height-300 && MenùPausa.activeInHierarchy == false)// && Input.GetTouch(0).phase != TouchPhase.Stationary || Input.GetTouch(0).phase != TouchPhase.Moved)
        {
           if(TapToChangeGMOB.activeInHierarchy == true)
            {
                TapToChangeGMOB.SetActive(false);
            }
            
                if (destra == false)
                {
                    //speedx = 0;
                    //speedy = 0;
                    destra = true;
                    tempoCambioDirezione = 0.00005f;
                }
                else if (destra == true)
                //else if (Input.GetKey(KeyCode.A) & destra == true)
                // else if (Input.GetTouch(0).phase == TouchPhase.Began & destra == true )
                {
                    //speedx = 0;
                    //speedy = 0;
                    destra = false;
                    tempoCambioDirezione = 0.00005f;
                }
        }
       /* else
        {
            if (tempoCambioDirezione < 0 && Input.GetTouch(0).phase != TouchPhase.Stationary || Input.GetTouch(0).phase != TouchPhase.Moved)
            {
                tempoCambioDirezione = 0;
            }
            else
            {
                tempoCambioDirezione = tempoCambioDirezione - 1 * Time.deltaTime;
            }
        }*/
    }
    
    public void MoneteTotali()
    {
        int MoneteTotali = PlayerPrefs.GetInt("MoneteTotali", 0);
        
        
        PlayerPrefs.SetInt("MoneteTotali", MoneteTotali + ScoreMonete);
        
    }
    public void impostaMaxSX()
    {
        if (posSX.transform.position.x < posMaxSX.transform.position.x)
        {

            posMaxSX.transform.position =posMaxSX.transform.position - new Vector3(22, 0, 0);
        }
    }
    public void impostaMaxBasso()
    {
        if (posDX.transform.position.y < posEnd.transform.position.y)
        {
            posEnd.transform.position = posEnd.transform.position - new Vector3(0, 25, 0);
        }
    }
     public void impostaMaxDX()
    {
        if (posDX.transform.position.x > posMaxDX.transform.position.x)
        {

            posMaxDX.transform.position = posMaxDX.transform.position + new Vector3(22, 0, 0);
        }
    }
    public void spawnCasuale()
    {
        random = Random.Range(0,11);
    }
    public void spawnCasuale50()
    {
        random50 = Random.Range(0, 12);
    }
    public void spawnCasuale100()
    {
        random100 = Random.Range(0, 3);
    }
    public void RipristinaSpawnato()
    {
       
        if(spawnato == true)
        {
            intervalloRipristinoSpawn = intervalloRipristinoSpawn + Time.deltaTime;
        }
        if(intervalloRipristinoSpawn > 0.4f )
        {
            spawnato = false;
            intervalloRipristinoSpawn  = 0;
        }
    }
    public void Restart()

    {
        morto = false;
        transform.position = new Vector3(-778, 40, -1.1f);
        menùGameover.SetActive(false);
        tempo = 0;
        speedx = 0.3f;
        speedy = 0.2f;
        accCamera.morto_vivo = false;
        accCamera.X = 0;
        accCamera.Y = 0;
        collisioni = 0;
        posDX.transform.position = new Vector3(-756, 17.5f, 1);
        posSX.transform.position = new Vector3(-800, 17.5f, -1);
        posEnd.transform.position = new Vector3(-778, 0, -0.5f);
        posMaxDX.transform.position = new Vector3(-756, 17.5f, 0);
        posMaxSX.transform.position = new Vector3(-800, 17.5f, 0);
        SpintaAllaMorte = 0;
        Destroy(GameObject.FindWithTag("clone"));
        Destroy(GameObject.FindWithTag("moneta"));
        RigidSfera.velocity = Vector3.zero;
    }
    public int GestioneMissione1()
    {
        if (PlayerPrefs.GetInt("1Step", 1) == 1)
        {
            return DaFareStep1[0];

        }
        else if (PlayerPrefs.GetInt("1Step", 1) == 2)
        {
            return DaFareStep2[0];
        }

        else
        {
            return DaFareStep3[0];
        }
    }
    public int GestioneMissione2()
    {
        if (PlayerPrefs.GetInt("2Step", 1) == 1)
        {
            return DaFareStep1[1];

        }
        else if (PlayerPrefs.GetInt("2Step", 1) == 2)
        {
            return DaFareStep2[1];
        }

        else
        {
            return DaFareStep3[1];
        }

    }
    public int GestioneMissione3()
    {
        if (PlayerPrefs.GetInt("3Step", 1) == 1)
        {
            return DaFareStep1[2];

        }
        else if (PlayerPrefs.GetInt("3Step", 1) == 2)
        {
            return DaFareStep2[2];
        }

        else
        {
            return DaFareStep3[2];
        }
    }
    public int GestioneMissione4()
    {
        if (PlayerPrefs.GetInt("4Step", 1) == 1)
        {
            return DaFareStep1[3];

        }
        else if (PlayerPrefs.GetInt("4Step", 1) == 2)
        {
            return DaFareStep2[3];
        }

        else
        {
            return DaFareStep3[3];
        }
    }
    public int GestioneMissione5()
    {
        if (PlayerPrefs.GetInt("5Step", 1) == 1)
        {
            return DaFareStep1[4];

        }
        else if (PlayerPrefs.GetInt("5Step", 1) == 2)
        {
            return DaFareStep2[4];
        }

        else
        {
            return DaFareStep3[4];
        }
    }
    public int GestioneMissione6()
    {
        if (PlayerPrefs.GetInt("6Step", 1) == 1)
        {
            return DaFareStep1[5];

        }
        else if (PlayerPrefs.GetInt("6Step", 1) == 2)
        {
            return DaFareStep2[5];
        }

        else
        {
            return DaFareStep3[5];
        }
    }
    public int GestioneMissione7()
    {
        if (PlayerPrefs.GetInt("7Step", 1) == 1)
        {
            return DaFareStep1[6];

        }
        else if (PlayerPrefs.GetInt("7Step", 1) == 2)
        {
            return DaFareStep2[6];
        }

        else
        {
            return DaFareStep3[6];
        }
    }
    public GameObject GestioneSpawnBlocchiDX()
    {
        if(PlayerPrefs.GetInt("DistanzaPartita",0) < 50)
        {
            return allBlocchiDX[random];
        }
        else if(PlayerPrefs.GetInt("DistanzaPartita", 0) < 100)
        {
            return allBlocchiDX50[random50];
        }
        else
        {
            return allBlocchiDX100[random100];
        }
    }
    public GameObject GestioneSpawnBlocchiSX()
    {
        if (PlayerPrefs.GetInt("DistanzaPartita", 0) < 50)
        {
            return allBlocchiSX[random];
        }
        else if (PlayerPrefs.GetInt("DistanzaPartita", 0) < 100)
        {
            return allBlocchiSX50[random50];
        }
        else
        {
            return allBlocchiSX100[random100];
        }
    }
}
