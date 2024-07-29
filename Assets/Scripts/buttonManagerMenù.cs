using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;




    public class buttonManagerMenù : MonoBehaviour
    {

        public int step = 1;
        public int volteADestra = 10;
        public int volteASinistra = 10;
        public int PunteggioDaRaggiungere = 10;
        public int OstacoliDaEvitare = 2;
        public buttonManager accButtonManager;
        public GameObject missione;
        public GameObject menùPalline;
        public GameObject[] Testi = new GameObject[9];
        public sphereScript accSphere;
        public Renderer rend;
        public Material[] materialiPalline = new Material[20];
        public Renderer[] pallineMenù = new Renderer[8];
        public GameObject[] Choose = new GameObject[7];
        public GameObject[] PallineMenù = new GameObject[20];
        public GameObject BloccoMenù;
        public bool Missione1Sbloccata = false;
        public bool Missione2Sbloccata = false;
        public bool Missione3Sbloccata = false;
        public bool Missione4Sbloccata = false;
        public bool Missione5Sbloccata = false;
        public bool Missione6Sbloccata = false;
        public bool Missione7Sbloccata = false;
        public bool QuelloVero = false;
        public UILabel PartiteGiocate;
        public UILabel MoneteRaccolte;
        public UILabel DistanzaPercorsa;
        public UILabel VolteASinistra;
        public UILabel VolteADestra;
        public UILabel OreDiGioco;
        public UILabel MediaPunteggio;
        public UIPanel MenùStats;
        public GameObject GMJMenuStats;
        public GameObject baule;
        public Material colorePallinaScelto;
        public bool click = false;
        public GameObject CameraAlternanza;
        public GameObject CameraMenù;
        public Camera CameraMenùComponent;
        public GameObject UIMenù;
        public GameObject UIGioco;
        public UISprite suoniBTN;
        public Texture volumeON;
        public Texture volumeOFF;
        public GameObject MenùOptions;
        public Text MoneteMenu;
        public GameObject SferaAlternanza;
        public GameObject SferaMenù;
        public ScrollInfinito AccScroll;
        public GameObject Scroll;
        public bool FinitoSpin = true;
        public float SpintaSpin = 9000;
        public GameObject PannelloConferma;
        public GameObject TestoComune;
        public GameObject TestoRaro;
        public GameObject TestoEpico;
        public GameObject ConfermaComune;
        public GameObject ConfermaRaro;
        public GameObject ConfermaEpico;
        public GameObject AnnullaBTN;
        public UILabel ContatoreMonete;
        public UILabel ContatoreMoneteMissioni;
        public UILabel ContatoreMoneteMenùPrincipale;
        public GameObject PannelloNoMoney;
        public int NumeroEstratto;
        public GameObject UIMenùPrincipale;
        public GameObject MenùMissioni;
        // public UILabel[] Fatti = new UILabel[1];
        public UILabel[] FattoLabel = new UILabel[7];
        public UILabel[] DaFareLabel = new UILabel[7];
        public int[] DaFareStep1 = new int[] { 50, 50, 10, 10, 10, 100, 20 };
        public int[] DaFareStep2 = new int[] { 500, 500, 50, 100, 40, 500, 100 };
        public int[] DaFareStep3 = new int[] { 1000, 1000, 100, 500, 75, 1000, 400 };
        public GameObject[] info = new GameObject[3];
        public GameObject[] Ricompensa = new GameObject[8];
        public GameObject[] FattoGMOB = new GameObject[7];
        public GameObject[] DaFareGMOB = new GameObject[7];
        public GameObject PannelloRicompensa50;
        public GameObject PannelloRicompensa100;
        public GameObject PannelloRicompensa250;
        public int[] DaBattere = new int[] { 50, 50, 10, 10, 10, 100, 10 };
        public UILabel RecordMenù;
        public GameObject PannelloSpinComune;
        public GameObject PannelloSpinRaro;
        public GameObject PannelloSpinEpico;
        public Color[] ColoriSpin = new Color[2];
        public UILabel[] RiscattaLabels = new UILabel[7];
        public GameObject[] CompletedTXT = new GameObject[7];
        public UILabel[] ContatoreSpinOmaggio = new UILabel[3];
        public GameObject[] ContatoreSpinOmaggioGMOB = new GameObject[3];
        public GameObject AreUSurePanel;
        public GameObject ScrittaExitGame;
        public GameObject[] x = new GameObject[3];
        public GameObject HowToPlayPanel;
        public GameObject BTNVolumeOptions;
        public GameObject BTNExitGame;
        public GameObject BTNHowToPlay;
        public GameObject[] PagineHowToPlay = new GameObject[5];
        public UILabel PaginaCorrenteTXT;
        public int ConteggioPaginaCorrente = 0;
        public GameObject BackMenuOptions;
        public GameObject BackHowToPlay;
        public GameObject Freccia1;
        public GameObject Freccia2;
        public GameObject[] Frecce = new GameObject[9];
        public GameObject BackDailyReward;
        public GameObject ImmagineSpinGMOB;
        public UISprite ImmagineSpin;
        public UILabel NumeroSpin;
        public UILabel Day;
        public GameObject PiuTrenta;
        public float TempoAspetta = 0;
        

        // public AdsManager AccAdsManager;

        private void Awake()
        {

            if (PlayerPrefs.GetString("CameraMenù", "Attiva") != "Attiva")
            {
                CameraMenù.SetActive(false);
                CameraAlternanza.SetActive(true);
                UIGioco.SetActive(true);
                UIMenù.SetActive(false);
            }
            else
            {
                CameraMenù.SetActive(true);
            }
        }
        void Start()
        {
            //  PlayerPrefs.SetInt("ContatoreSpinComune", 6);

            /*  if (PlayerPrefs.GetString("PrimoAccesso", "si") == "No") daily reward
              {
                  DayCheck();
              }
              else
              {
                  PlayerPrefs.SetString("PlayDate", System.DateTime.Now.ToString());
              }*/
            // PlayerPrefs.GetString("PermessoDayCheck", "Si");

            //print(PlayerPrefs.GetString("PrimoAccesso"));

            Frecce[0].SetActive(false);
            Frecce[1].SetActive(false);
            Frecce[2].SetActive(false);
            Frecce[3].SetActive(false);
            Frecce[4].SetActive(false);
            Frecce[5].SetActive(false);
            Frecce[6].SetActive(false);
            Frecce[7].SetActive(false);
            AttivazioneStartFrecce();

            RecordMenù.text = PlayerPrefs.GetInt("RecordDistanza").ToString();
            //PlayerPrefs.SetInt("MonetePossedute", 9999);
            /*
             PlayerPrefs.SetInt("VolteADestra", 0);
              PlayerPrefs.SetInt("VolteASinistra", 0);
              PlayerPrefs.SetInt("RecordPartiteGiocate", 0);
              PlayerPrefs.SetInt("RecordDistanza", 0);
              PlayerPrefs.SetInt("MoneteRaccolte", 0);
              PlayerPrefs.SetInt("RecordMonetePartita", 0);
              */

            //PlayerPrefs.SetInt("1Step", 1);
            //RecordMenù.text = PlayerPrefs.GetInt("RecordDistanza").ToString();
            //MoneteMenu.text = PlayerPrefs.GetInt("MonetePossedute", 100).ToString();
            PartiteGiocate.text = PlayerPrefs.GetInt("RecordPartiteGiocate", 0).ToString();
            VolteADestra.text = PlayerPrefs.GetInt("VolteADestra", 0).ToString();
            VolteASinistra.text = PlayerPrefs.GetInt("VolteASinistra", 0).ToString();
            DistanzaPercorsa.text = PlayerPrefs.GetInt("DistanzaPercorsa", 0).ToString();
            MoneteRaccolte.text = PlayerPrefs.GetInt("MoneteRaccolte", 0).ToString();
            //MediaPunteggio.text = Mathf.Round(PlayerPrefs.GetInt("DistanzaPercorsa", 0) / PlayerPrefs.GetInt("RecordPartiteGiocate", 0)).ToString();
            // OreDiGioco.text = ("H  " + Mathf.Round(PlayerPrefs.GetFloat("OreDiGioco", 0) / 3600) + "   MIN " + Mathf.Round((PlayerPrefs.GetFloat("OreDiGioco", 0) - 60 * Mathf.Round(PlayerPrefs.GetFloat("OreDiGioco", 0) / 3600)) / 60));

            OreDiGioco.text = (Mathf.Floor((PlayerPrefs.GetFloat("OreDiGioco", 0) / 60) / 60) + " h " + (Mathf.Floor(PlayerPrefs.GetFloat("OreDiGioco", 0) / 60) - (Mathf.Floor((PlayerPrefs.GetFloat("OreDiGioco", 0) / 60) / 60) * 60) + " min "));

            ContatoreMoneteMenùPrincipale.text = PlayerPrefs.GetInt("MonetePossedute", 200).ToString();
            if (PlayerPrefs.GetString("VolumeONOFF", "") == "off")
            {
                suoniBTN.spriteName = "volumeOFF";
            }
            else
            {
                suoniBTN.spriteName = "volumeON";
            }
            //PlayerPrefs.SetString("pausa", "attiva");

            if (PlayerPrefs.GetString("CameraMenù", "Attiva") != "Attiva")
            {
                CameraMenù.SetActive(false);
                CameraAlternanza.SetActive(true);
                UIGioco.SetActive(true);
            }
            else
            {
                CameraMenù.SetActive(true);
            }
            checkMissioni();

        }
        private void FixedUpdate()
        {

            rend.sharedMaterial = materialiPalline[PlayerPrefs.GetInt("ColoreScelto", 0)];
            //PallineMenù[PlayerPrefs.GetInt("ColoreScelto",0)].transform.Rotate(-5.5f, 6.75f, -1.75f, Space.World);
        }
        public void ChiudiInfo50()
        {
            info[0].SetActive(false);
            PannelloSpinComune.SetActive(true);
            AnnullaBTN.SetActive(true);

        }
        public void ChiudiInfo100()
        {
            info[1].SetActive(false);
            PannelloSpinRaro.SetActive(true);
            AnnullaBTN.SetActive(true);


        }
        public void ChiudiInfo250()
        {
            info[2].SetActive(false);
            PannelloSpinEpico.SetActive(true);
            AnnullaBTN.SetActive(true);


        }
        public void ChiudiInfo()
        {
            info[0].SetActive(false);
            info[1].SetActive(false);
            info[2].SetActive(false);

        }
        public void Info50()
        {
            ChiudiInfo();
            info[0].SetActive(true);
            PannelloSpinComune.SetActive(false);
            // ChiudiPannelloRicompensa100();
            PannelloNoMoney.SetActive(false);
            AnnullaBTN.SetActive(false);

        }
        public void Info100()
        {
            ChiudiInfo();
            info[1].SetActive(true);
            PannelloSpinRaro.SetActive(false);
            //ChiudiPannelloRicompensa100();
            PannelloNoMoney.SetActive(false);
            AnnullaBTN.SetActive(false);

        }
        public void Info250()
        {
            ChiudiInfo();
            info[2].SetActive(true);
            PannelloSpinEpico.SetActive(false);
            //ChiudiPannelloRicompensa100();
            PannelloNoMoney.SetActive(false);
            AnnullaBTN.SetActive(false);

        }
        public void ResettoRotazione()
        {
            AccScroll.RotazionePalline();
        }
        public void EsciMenùPalline()
        {
            if (AccScroll.FinitoMovimento == true && AccScroll.SpinCliccato == false)
            {
                ChiudiInfo();

                AccScroll.Resetto1();
                AccScroll.Resetto2();

                menùPalline.SetActive(false);
            }
            /*
                    if (PlayerPrefs.GetString("PrimoAccesso", "si") == "no")
                    {
                        AccAdsManager.ShowInterstitial();
                    }
                    */
        }
        public void AvvioSpinRicompensa50()
        {
            estrazioneComune();
            AccScroll.TempoAspetta = 0;
            AccScroll.MoneteGenerali = Mathf.Floor(PlayerPrefs.GetInt("MonetePossedute", 200));
            AccScroll.SpinCliccato = true;
            AccScroll.FinitoMovimento = false;
        }
        public void AvvioSpinRicompensa100()
        {

            estrazioneRara();
            AccScroll.TempoAspetta = 0;

            AccScroll.MoneteGenerali = Mathf.Floor(PlayerPrefs.GetInt("MonetePossedute", 200));
            AccScroll.SpinCliccato = true;
            AccScroll.FinitoMovimento = false;
        }
        public void AvvioSpinRicompensa250()
        {

            estrazioneEpica();
            AccScroll.TempoAspetta = 0;

            AccScroll.MoneteGenerali = Mathf.Floor(PlayerPrefs.GetInt("MonetePossedute", 200));
            AccScroll.SpinCliccato = true;
            AccScroll.FinitoMovimento = false;
        }
        public void SpinComune()
        {
            if (PlayerPrefs.GetInt("NAccesso", 0) == 4)
            {
                Frecce[4].SetActive(false);
                PlayerPrefs.SetInt("NFrecciaAttiva", PlayerPrefs.GetInt("NFrecciaAttiva", 0) + 1);
                if (PlayerPrefs.GetInt("NAccesso", 0) < 10)
                {
                    PlayerPrefs.SetInt("NAccesso", PlayerPrefs.GetInt("NAccesso", 0) + 1);
                }
                AttivazioneStartFrecce();



            }
            AnnullaBTN.SetActive(true);
            ChiudiInfo();
            PannelloNoMoney.SetActive(false);

            if (AccScroll.FinitoMovimento == true && AccScroll.SpinCliccato == false)
            {
                if (PlayerPrefs.GetInt("ContatoreSpinComune", 1) > 0)
                {
                    AvvioSpinRicompensa50();
                    PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune", 1) - 1);
                    ContatoreSpinOmaggio[0].text = PlayerPrefs.GetInt("ContatoreSpinComune", 1).ToString();
                    if (PlayerPrefs.GetInt("ContatoreSpinComune", 1) == 0)
                    {
                        x[0].SetActive(false);
                        ContatoreSpinOmaggioGMOB[0].SetActive(false);
                    }
                }
                else if (PlayerPrefs.GetInt("MonetePossedute", 200) >= 50)
                {
                    PannelloConferma.SetActive(true);
                    PannelloSpinComune.SetActive(true);
                    PannelloSpinEpico.SetActive(false);
                    PannelloSpinRaro.SetActive(false);
                }
                else
                {
                    PannelloConferma.SetActive(true);
                    PannelloNoMoney.SetActive(true);
                    PannelloSpinComune.SetActive(false);
                    PannelloSpinEpico.SetActive(false);
                    PannelloSpinRaro.SetActive(false);
                    AnnullaBTN.SetActive(false);
                }

            }

        }
        public void SpinRaro()
        {
            AnnullaBTN.SetActive(true);
            ChiudiInfo();
            PannelloNoMoney.SetActive(false);

            if (AccScroll.FinitoMovimento == true && AccScroll.SpinCliccato == false)
            {
                if (PlayerPrefs.GetInt("ContatoreSpinRaro") > 0)
                {
                    AvvioSpinRicompensa100();
                    PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") - 1);
                    ContatoreSpinOmaggio[1].text = PlayerPrefs.GetInt("ContatoreSpinRaro", 0).ToString();
                    if (PlayerPrefs.GetInt("ContatoreSpinRaro") == 0)
                    {
                        x[1].SetActive(false);
                        ContatoreSpinOmaggioGMOB[1].SetActive(false);
                    }
                }
                else if (PlayerPrefs.GetInt("MonetePossedute", 200) >= 250)
                {

                    PannelloConferma.SetActive(true);
                    PannelloSpinComune.SetActive(false);
                    PannelloSpinEpico.SetActive(false);
                    PannelloSpinRaro.SetActive(true);

                }
                else
                {
                    PannelloConferma.SetActive(true);

                    PannelloNoMoney.SetActive(true);
                    PannelloSpinComune.SetActive(false);
                    PannelloSpinEpico.SetActive(false);
                    PannelloSpinRaro.SetActive(false);
                    AnnullaBTN.SetActive(false);

                }
            }

        }
        public void SpinEpico()
        {
            AnnullaBTN.SetActive(true);
            ChiudiInfo();
            PannelloNoMoney.SetActive(false);

            if (AccScroll.FinitoMovimento == true && AccScroll.SpinCliccato == false)
            {
                if (PlayerPrefs.GetInt("ContatoreSpinEpico") > 0)
                {
                    AvvioSpinRicompensa250();
                    PlayerPrefs.SetInt("ContatoreSpinEpico", PlayerPrefs.GetInt("ContatoreSpinEpico") - 1);
                    ContatoreSpinOmaggio[2].text = PlayerPrefs.GetInt("ContatoreSpinEpico", 0).ToString();
                    if (PlayerPrefs.GetInt("ContatoreSpinEpico") == 0)
                    {
                        x[2].SetActive(false);
                        ContatoreSpinOmaggioGMOB[2].SetActive(false);
                    }
                }
                else if (PlayerPrefs.GetInt("MonetePossedute", 100) >= 500)
                {

                    PannelloConferma.SetActive(true);
                    PannelloSpinComune.SetActive(false);
                    PannelloSpinEpico.SetActive(true);
                    PannelloSpinRaro.SetActive(false);
                }
                else
                {
                    PannelloConferma.SetActive(true);
                    PannelloNoMoney.SetActive(true);
                    PannelloSpinComune.SetActive(false);
                    PannelloSpinEpico.SetActive(false);
                    PannelloSpinRaro.SetActive(false);
                    AnnullaBTN.SetActive(false);

                }
            }

        }
        public void ApriHowToPlay()
        {
            if (PlayerPrefs.GetInt("NAccesso", 0) == 1)
            {
                Frecce[1].SetActive(false);
                PlayerPrefs.SetInt("NFrecciaAttiva", PlayerPrefs.GetInt("NFrecciaAttiva", 0) + 1);
                if (PlayerPrefs.GetInt("NAccesso", 0) < 10)
                {
                    PlayerPrefs.SetInt("NAccesso", PlayerPrefs.GetInt("NAccesso", 0) + 1);
                }
                AttivazioneStartFrecce();

            }

            HowToPlayPanel.SetActive(true);
            BTNExitGame.SetActive(false);
            BTNVolumeOptions.SetActive(false);
            BTNHowToPlay.SetActive(false);
            BackMenuOptions.SetActive(false);
            BackHowToPlay.SetActive(true);
            PagineHowToPlay[0].SetActive(true);
            PagineHowToPlay[1].SetActive(false);
            PagineHowToPlay[2].SetActive(false);
            PagineHowToPlay[3].SetActive(false);
            PagineHowToPlay[4].SetActive(false);
            ConteggioPaginaCorrente = 0;
        }
        public void ChiudiHowToPlay()
        {
            HowToPlayPanel.SetActive(false);
            BTNExitGame.SetActive(true);
            BTNVolumeOptions.SetActive(true);
            BTNHowToPlay.SetActive(true);
            BackMenuOptions.SetActive(true);
            BackHowToPlay.SetActive(false);
        }
        public void ProssimaSlide()
        {
            if (ConteggioPaginaCorrente < 4)
            {
                PagineHowToPlay[ConteggioPaginaCorrente].SetActive(false);
                ConteggioPaginaCorrente++;
                PaginaCorrenteTXT.text = (ConteggioPaginaCorrente + 1).ToString();
                PagineHowToPlay[ConteggioPaginaCorrente].SetActive(true);
            }
        }
        public void PrecedenteSlide()
        {
            if (ConteggioPaginaCorrente > 0)
            {
                PagineHowToPlay[ConteggioPaginaCorrente].SetActive(false);
                ConteggioPaginaCorrente--;
                PaginaCorrenteTXT.text = (ConteggioPaginaCorrente + 1).ToString();
                PagineHowToPlay[ConteggioPaginaCorrente].SetActive(true);
            }
        }
        public void EsciPannelloNoMoney()
        {
            PannelloNoMoney.SetActive(false);
        }
        public void AvvioSpinComune()
        {
            AccScroll.MoneteGenerali = Mathf.Floor(PlayerPrefs.GetInt("MonetePossedute", 200));
            PlayerPrefs.SetInt("MonetePossedute", PlayerPrefs.GetInt("MonetePossedute", 200) - 50);
            AccScroll.Decremento.SetActive(true);
            AccScroll.MoneteVinte = 50;
            AccScroll.VelocitaIncrementoDecremento = 20;
            // ContatoreMonete.text = PlayerPrefs.GetInt("MonetePossedute",200).ToString();

            estrazioneComune();
            PannelloConferma.SetActive(false);

            AccScroll.SpinCliccato = true;
            AccScroll.FinitoMovimento = false;

        }
        public void AvvioSpinRaro()
        {
            AccScroll.MoneteGenerali = Mathf.Floor(PlayerPrefs.GetInt("MonetePossedute", 200));

            PlayerPrefs.SetInt("MonetePossedute", PlayerPrefs.GetInt("MonetePossedute", 200) - 250);

            //ContatoreMonete.text = PlayerPrefs.GetInt("MonetePossedute",200).ToString();
            AccScroll.Decremento.SetActive(true);
            AccScroll.MoneteVinte = 250;
            AccScroll.VelocitaIncrementoDecremento = 100;
            estrazioneRara();
            PannelloConferma.SetActive(false);

            AccScroll.SpinCliccato = true;
            AccScroll.FinitoMovimento = false;

        }
        public void AvvioSpinEpica()
        {
            AccScroll.MoneteGenerali = Mathf.Floor(PlayerPrefs.GetInt("MonetePossedute", 200));

            PlayerPrefs.SetInt("MonetePossedute", PlayerPrefs.GetInt("MonetePossedute", 200) - 500);

            //ContatoreMonete.text = PlayerPrefs.GetInt("MonetePossedute",200).ToString();
            AccScroll.Decremento.SetActive(true);
            AccScroll.MoneteVinte = 500;
            AccScroll.VelocitaIncrementoDecremento = 200;
            estrazioneEpica();
            PannelloConferma.SetActive(false);

            AccScroll.SpinCliccato = true;
            AccScroll.FinitoMovimento = false;

        }
        public void AnnullaAcquisto()
        {
            Scroll.SetActive(true);
            PannelloConferma.SetActive(false);
            PannelloSpinEpico.SetActive(false);
            PannelloSpinRaro.SetActive(false);
            PannelloSpinComune.SetActive(false);
            AnnullaBTN.SetActive(true);
        }
        public void ChiudiRicompensa50()
        {
            PannelloRicompensa50.SetActive(false);
        }
        public void ChiudiPannelloRicompensa100()
        {
            PannelloRicompensa100.SetActive(false);
        }
        public void ChiudiPannelloRicompensa250()
        {
            PannelloRicompensa250.SetActive(false);
        }
        public void Riscatta1()
        {
            if (PlayerPrefs.GetInt("1Step", 1) == 1)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                menuPalline();

                Ricompensa[0].SetActive(false);
                FattoGMOB[0].SetActive(true);
                DaFareGMOB[0].SetActive(true);
                PlayerPrefs.SetInt("1Step", 2);
            }
            else if (PlayerPrefs.GetInt("1Step", 1) == 2)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                menuPalline();


                Ricompensa[0].SetActive(false);
                FattoGMOB[0].SetActive(true);
                DaFareGMOB[0].SetActive(true);
                PlayerPrefs.SetInt("1Step", 3);
            }
            else if (PlayerPrefs.GetInt("1Step", 1) == 3)
            {
                ChiudiMenùMissioni();
                // PannelloRicompensa250.SetActive(true);
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                PlayerPrefs.SetInt("ContatoreSpinEpico", PlayerPrefs.GetInt("ContatoreSpinEpico") + 1);
                menuPalline();

                Ricompensa[0].SetActive(false);
                FattoGMOB[0].SetActive(false);
                DaFareGMOB[0].SetActive(false);
                PlayerPrefs.SetInt("1Step", 4);

            }
        }
        public void Riscatta2()

        {
            if (PlayerPrefs.GetInt("2Step", 1) == 1)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                menuPalline();

                Ricompensa[1].SetActive(false);
                FattoGMOB[1].SetActive(true);
                DaFareGMOB[1].SetActive(true);
                PlayerPrefs.SetInt("2Step", 2);
            }
            else if (PlayerPrefs.GetInt("2Step", 1) == 2)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                menuPalline();

                Ricompensa[1].SetActive(false);
                FattoGMOB[1].SetActive(true);
                DaFareGMOB[1].SetActive(true);
                PlayerPrefs.SetInt("2Step", 3);
            }
            else if (PlayerPrefs.GetInt("2Step", 1) == 3)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                PlayerPrefs.SetInt("ContatoreSpinEpico", PlayerPrefs.GetInt("ContatoreSpinEpico") + 1);
                menuPalline();

                Ricompensa[1].SetActive(false);
                FattoGMOB[1].SetActive(false);
                DaFareGMOB[1].SetActive(false);
                PlayerPrefs.SetInt("2Step", 4);

            }
        }
        public void Riscatta3()
        {
            if (PlayerPrefs.GetInt("3Step", 1) == 1)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                menuPalline();

                Ricompensa[2].SetActive(false);
                FattoGMOB[2].SetActive(true);
                DaFareGMOB[2].SetActive(true);
                PlayerPrefs.SetInt("3Step", 2);
            }
            else if (PlayerPrefs.GetInt("3Step", 1) == 2)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                menuPalline();

                Ricompensa[2].SetActive(false);
                FattoGMOB[2].SetActive(true);
                DaFareGMOB[2].SetActive(true);
                PlayerPrefs.SetInt("3Step", 3);
            }
            else if (PlayerPrefs.GetInt("3Step", 1) == 3)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                PlayerPrefs.SetInt("ContatoreSpinEpico", PlayerPrefs.GetInt("ContatoreSpinEpico") + 1);
                menuPalline();

                Ricompensa[2].SetActive(false);
                FattoGMOB[2].SetActive(false);
                DaFareGMOB[2].SetActive(false);
                PlayerPrefs.SetInt("3Step", 4);

            }
        }
        public void Riscatta4()
        {
            if (PlayerPrefs.GetInt("4Step", 1) == 1)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                menuPalline();

                Ricompensa[3].SetActive(false);
                FattoGMOB[3].SetActive(true);
                DaFareGMOB[3].SetActive(true);
                PlayerPrefs.SetInt("4Step", 2);
            }
            else if (PlayerPrefs.GetInt("4Step", 1) == 2)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                menuPalline();

                Ricompensa[3].SetActive(false);
                FattoGMOB[3].SetActive(false);
                DaFareGMOB[3].SetActive(false);
                PlayerPrefs.SetInt("4Step", 3);
            }
            else if (PlayerPrefs.GetInt("4Step", 1) == 3)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                PlayerPrefs.SetInt("ContatoreSpinEpico", PlayerPrefs.GetInt("ContatoreSpinEpico") + 1);
                menuPalline();

                Ricompensa[3].SetActive(false);
                FattoGMOB[3].SetActive(false);
                DaFareGMOB[3].SetActive(false);
                PlayerPrefs.SetInt("4Step", 4);

            }
        }
        public void Riscatta5()
        {
            if (PlayerPrefs.GetInt("5Step", 1) == 1)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                menuPalline();

                Ricompensa[4].SetActive(false);
                FattoGMOB[4].SetActive(true);
                DaFareGMOB[4].SetActive(true);
                PlayerPrefs.SetInt("5Step", 2);
            }
            else if (PlayerPrefs.GetInt("5Step", 1) == 2)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                menuPalline();

                Ricompensa[4].SetActive(false);
                FattoGMOB[4].SetActive(true);
                DaFareGMOB[4].SetActive(true);
                PlayerPrefs.SetInt("5Step", 3);
            }
            else if (PlayerPrefs.GetInt("5Step", 1) == 3)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                PlayerPrefs.SetInt("ContatoreSpinEpico", PlayerPrefs.GetInt("ContatoreSpinEpico") + 1);
                menuPalline();

                Ricompensa[4].SetActive(false);
                FattoGMOB[4].SetActive(false);
                DaFareGMOB[4].SetActive(false);
                PlayerPrefs.SetInt("5Step", 4);

            }
        }
        public void Riscatta6()
        {
            if (PlayerPrefs.GetInt("6Step", 1) == 1)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                menuPalline();

                Ricompensa[5].SetActive(false);
                FattoGMOB[5].SetActive(true);
                DaFareGMOB[5].SetActive(true);
                PlayerPrefs.SetInt("6Step", 2);
            }
            else if (PlayerPrefs.GetInt("6Step", 1) == 2)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                menuPalline();

                Ricompensa[5].SetActive(false);
                FattoGMOB[5].SetActive(true);
                DaFareGMOB[5].SetActive(true);
                PlayerPrefs.SetInt("6Step", 3);
            }
            else if (PlayerPrefs.GetInt("6Step", 1) == 3)
            {
                ChiudiMenùMissioni();

                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                PlayerPrefs.SetInt("ContatoreSpinEpico", PlayerPrefs.GetInt("ContatoreSpinEpico") + 1);
                menuPalline();

                Ricompensa[5].SetActive(false);
                FattoGMOB[5].SetActive(false);
                DaFareGMOB[5].SetActive(false);
                PlayerPrefs.SetInt("6Step", 4);

            }
        }
        public void Riscatta7()
        {
            if (PlayerPrefs.GetInt("7Step", 1) == 1)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                menuPalline();

                Ricompensa[6].SetActive(false);
                FattoGMOB[6].SetActive(true);
                DaFareGMOB[6].SetActive(true);
                PlayerPrefs.SetInt("7Step", 2);
            }
            else if (PlayerPrefs.GetInt("7Step", 1) == 2)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                menuPalline();

                Ricompensa[6].SetActive(false);
                FattoGMOB[6].SetActive(true);
                DaFareGMOB[6].SetActive(true);
                PlayerPrefs.SetInt("7Step", 3);
            }
            else if (PlayerPrefs.GetInt("7Step", 1) == 3)
            {
                ChiudiMenùMissioni();
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                PlayerPrefs.SetInt("ContatoreSpinEpico", PlayerPrefs.GetInt("ContatoreSpinEpico") + 1);
                menuPalline();

                Ricompensa[6].SetActive(false);
                FattoGMOB[6].SetActive(false);
                DaFareGMOB[6].SetActive(false);
                PlayerPrefs.SetInt("7Step", 4);
            }
        }
        public void ApriMenùMissioni()
        {
            Ricompensa[0].SetActive(false);
            Ricompensa[1].SetActive(false);
            Ricompensa[2].SetActive(false);
            Ricompensa[3].SetActive(false);
            Ricompensa[4].SetActive(false);
            Ricompensa[5].SetActive(false);
            Ricompensa[6].SetActive(false);
            FattoGMOB[0].SetActive(true);
            FattoGMOB[1].SetActive(true);
            FattoGMOB[2].SetActive(true);
            FattoGMOB[3].SetActive(true);
            FattoGMOB[4].SetActive(true);
            FattoGMOB[5].SetActive(true);
            FattoGMOB[6].SetActive(true);
            DaFareGMOB[0].SetActive(true);
            DaFareGMOB[1].SetActive(true);
            DaFareGMOB[2].SetActive(true);
            DaFareGMOB[3].SetActive(true);
            DaFareGMOB[4].SetActive(true);
            DaFareGMOB[5].SetActive(true);
            DaFareGMOB[6].SetActive(true);


            ContatoreMoneteMissioni.text = PlayerPrefs.GetInt("MonetePossedute", 200).ToString();
            if (PlayerPrefs.GetInt("1Step", 1) == 2)
            {
                DaFareLabel[0].text = DaFareStep2[0].ToString();
                // DaBattere[0] = DaFareStep2[0];
            }
            else if (PlayerPrefs.GetInt("1Step", 1) == 3)
            {
                DaFareLabel[0].text = DaFareStep3[0].ToString();
                // DaBattere[0] = DaFareStep3[0];
            }
            else if (PlayerPrefs.GetInt("1Step", 1) == 4)
            {
                FattoGMOB[0].SetActive(false);
                DaFareGMOB[0].SetActive(false);
                CompletedTXT[0].SetActive(true);
            }
            if (PlayerPrefs.GetInt("2Step", 1) == 2)
            {
                DaFareLabel[1].text = DaFareStep2[1].ToString();
                //DaBattere[1] = DaFareStep2[1];
            }
            else if (PlayerPrefs.GetInt("2Step", 1) == 3)
            {
                DaFareLabel[1].text = DaFareStep3[1].ToString();
                //   DaBattere[1] = DaFareStep3[1];
            }
            else if (PlayerPrefs.GetInt("2Step", 1) == 4)
            {
                FattoGMOB[1].SetActive(false);
                DaFareGMOB[1].SetActive(false);
                CompletedTXT[1].SetActive(true);
            }
            if (PlayerPrefs.GetInt("3Step", 1) == 2)
            {
                DaFareLabel[2].text = DaFareStep2[2].ToString();
                //  DaBattere[3] = DaFareStep2[3];
            }
            else if (PlayerPrefs.GetInt("3Step", 1) == 3)
            {
                DaFareLabel[2].text = DaFareStep3[2].ToString();
                // DaBattere[3] = DaFareStep3[3];
            }
            else if (PlayerPrefs.GetInt("3Step", 1) == 4)
            {
                FattoGMOB[2].SetActive(false);
                DaFareGMOB[2].SetActive(false);
                CompletedTXT[2].SetActive(true);
            }
            if (PlayerPrefs.GetInt("4Step", 1) == 2)
            {
                DaFareLabel[3].text = DaFareStep2[3].ToString();
                //   DaBattere[4] = DaFareStep2[4];
            }
            else if (PlayerPrefs.GetInt("4Step", 1) == 3)
            {
                DaFareLabel[3].text = DaFareStep3[3].ToString();
                //  DaBattere[4] = DaFareStep3[4];
            }
            else if (PlayerPrefs.GetInt("4Step", 1) == 4)
            {
                FattoGMOB[3].SetActive(false);
                DaFareGMOB[3].SetActive(false);
                CompletedTXT[3].SetActive(true);
            }
            if (PlayerPrefs.GetInt("5Step", 1) == 2)
            {
                DaFareLabel[4].text = DaFareStep2[4].ToString();
                //  DaBattere[5] = DaFareStep2[5];
            }
            else if (PlayerPrefs.GetInt("5Step", 1) == 3)
            {
                DaFareLabel[4].text = DaFareStep3[4].ToString();
                //DaBattere[5] = DaFareStep3[5];
            }
            else if (PlayerPrefs.GetInt("5Step", 1) == 4)
            {
                FattoGMOB[4].SetActive(false);
                DaFareGMOB[4].SetActive(false);
                CompletedTXT[4].SetActive(true);
            }
            if (PlayerPrefs.GetInt("6Step", 1) == 2)
            {
                DaFareLabel[5].text = DaFareStep2[5].ToString();
                //  DaBattere[6] = DaFareStep2[6];
            }
            else if (PlayerPrefs.GetInt("6Step", 1) == 3)
            {
                DaFareLabel[5].text = DaFareStep3[5].ToString();
                //DaBattere[6] = DaFareStep3[6];
            }
            else if (PlayerPrefs.GetInt("6Step", 1) == 4)
            {
                FattoGMOB[5].SetActive(false);
                DaFareGMOB[5].SetActive(false);
                CompletedTXT[5].SetActive(true);
            }
            if (PlayerPrefs.GetInt("7Step", 1) == 2)
            {
                DaFareLabel[6].text = DaFareStep2[6].ToString();
                //DaBattere[7] = DaFareStep2[7];
            }
            else if (PlayerPrefs.GetInt("7Step", 1) == 3)
            {
                DaFareLabel[6].text = DaFareStep3[6].ToString();
                // DaBattere[7] = DaFareStep3[7];
            }
            else if (PlayerPrefs.GetInt("7Step", 1) == 4)
            {
                FattoGMOB[6].SetActive(false);
                DaFareGMOB[6].SetActive(false);
                CompletedTXT[6].SetActive(true);
            }
            MenùMissioni.SetActive(true);
            UIMenùPrincipale.SetActive(false);
            SferaMenù.SetActive(false);
            BloccoMenù.SetActive(false);
            FattoLabel[0].text = PlayerPrefs.GetInt("VolteADestra").ToString() + " /";
            FattoLabel[1].text = PlayerPrefs.GetInt("VolteASinistra").ToString() + " /";
            FattoLabel[2].text = PlayerPrefs.GetInt("RecordDistanza").ToString() + " /";
            FattoLabel[3].text = PlayerPrefs.GetInt("RecordPartiteGiocate").ToString() + " /";
            FattoLabel[4].text = PlayerPrefs.GetInt("RecordMonetePartita").ToString() + " /";
            FattoLabel[5].text = PlayerPrefs.GetInt("MoneteRaccolte").ToString() + " /";
            FattoLabel[6].text = PlayerPrefs.GetInt("OstacoliSuperati", 0).ToString() + " /";

            if (PlayerPrefs.GetInt("VolteADestra", 0) >= GestioneMissione1() && PlayerPrefs.GetInt("1Step", 1) != 4)
            {
                Ricompensa[0].SetActive(true);
                RiscattaLabels[0].color = ColoriSpin[(PlayerPrefs.GetInt("1Step", 1)) - 1];
                FattoGMOB[0].SetActive(false);
                DaFareGMOB[0].SetActive(false);
            }
            if (PlayerPrefs.GetInt("VolteASinistra", 0) >= GestioneMissione2() && PlayerPrefs.GetInt("2Step", 1) != 4)
            {
                Ricompensa[1].SetActive(true);
                RiscattaLabels[1].color = ColoriSpin[(PlayerPrefs.GetInt("2Step", 1)) - 1];

                FattoGMOB[1].SetActive(false);
                DaFareGMOB[1].SetActive(false);
            }
            if (PlayerPrefs.GetInt("RecordDistanza", 0) >= GestioneMissione3() && PlayerPrefs.GetInt("3Step", 1) != 4)
            {
                Ricompensa[2].SetActive(true);
                RiscattaLabels[2].color = ColoriSpin[(PlayerPrefs.GetInt("3Step", 1)) - 1];

                FattoGMOB[2].SetActive(false);
                DaFareGMOB[2].SetActive(false);
            }
            if (PlayerPrefs.GetInt("RecordPartiteGiocate", 0) >= GestioneMissione4() && PlayerPrefs.GetInt("4Step", 1) != 4)
            {
                Ricompensa[3].SetActive(true);
                RiscattaLabels[3].color = ColoriSpin[(PlayerPrefs.GetInt("4Step", 1)) - 1];

                FattoGMOB[3].SetActive(false);
                DaFareGMOB[3].SetActive(false);
            }
            if (PlayerPrefs.GetInt("RecordMonetePartita", 0) >= GestioneMissione5() && PlayerPrefs.GetInt("5Step", 1) != 4)
            {
                Ricompensa[4].SetActive(true);
                RiscattaLabels[4].color = ColoriSpin[(PlayerPrefs.GetInt("5Step", 1)) - 1];

                FattoGMOB[4].SetActive(false);
                DaFareGMOB[4].SetActive(false);
            }
            if (PlayerPrefs.GetInt("MoneteRaccolte", 0) >= GestioneMissione6() && PlayerPrefs.GetInt("6Step", 1) != 4)
            {
                Ricompensa[5].SetActive(true);
                RiscattaLabels[5].color = ColoriSpin[(PlayerPrefs.GetInt("6Step", 1)) - 1];

                FattoGMOB[5].SetActive(false);
                DaFareGMOB[5].SetActive(false);
            }
            if (PlayerPrefs.GetInt("OstacoliSuperati", 0) >= GestioneMissione7() && PlayerPrefs.GetInt("7Step", 1) != 4)
            {
                Ricompensa[6].SetActive(true);
                RiscattaLabels[6].color = ColoriSpin[(PlayerPrefs.GetInt("7Step", 1) - 1)];

                FattoGMOB[6].SetActive(false);
                DaFareGMOB[6].SetActive(false);

            }
        }
        public void ChiudiMenùMissioni()
        {
            /*
             if (PlayerPrefs.GetString("PrimoAccesso", "si") == "no")
             {
                 AccAdsManager.ShowInterstitial();
             }
             */

            if (PlayerPrefs.GetInt("NAccesso", 0) == 5)
            {
                Frecce[5].SetActive(false);
                PlayerPrefs.SetInt("NFrecciaAttiva", PlayerPrefs.GetInt("NFrecciaAttiva", 0) + 1);
                PlayerPrefs.SetInt("NAccesso", PlayerPrefs.GetInt("NAccesso", 0) + 1);

                AttivazioneStartFrecce();

            }

            MenùMissioni.SetActive(false);
            UIMenùPrincipale.SetActive(true);
            SferaMenù.SetActive(true);
            BloccoMenù.SetActive(true);

        }

        public void MenùBaule()
        {
            baule.SetActive(true);
        }
        public void EsciMenùBaule()
        {
            baule.SetActive(false);
        }
        public void NewGameBtn(string newGamegioco)
        {
            SceneManager.LoadScene(newGamegioco); //caricamento altra scena
        }
        public void play()
        {
            if (PlayerPrefs.GetInt("NAccesso", 0) == 7 || PlayerPrefs.GetInt("NAccesso", 0) > 7)
            {
                Frecce[7].SetActive(false);
                PlayerPrefs.SetInt("NFrecciaAttiva", PlayerPrefs.GetInt("NFrecciaAttiva", 0) + 1);
                if (PlayerPrefs.GetInt("NAccesso", 0) < 10)
                {
                    PlayerPrefs.SetInt("NAccesso", PlayerPrefs.GetInt("NAccesso", 0) + 1);
                }
                if (PlayerPrefs.GetString("PrimoAccesso", "si") == "si")
                {
                    PlayerPrefs.SetString("PrimoAccesso", "no");
                }
                AttivazioneStartFrecce();


                SferaMenù.SetActive(false);
                UIMenù.SetActive(false);
                CameraAlternanza.SetActive(true);
                CameraMenù.SetActive(false);
                UIGioco.SetActive(true);
                SferaAlternanza.SetActive(true);
                PlayerPrefs.SetString("pausa", "nonattiva");
                PlayerPrefs.SetString("CameraMenù", "NonAttiva");
                
            }
        }
        public void InfoGenerali()
        {
            if (PlayerPrefs.GetInt("NAccesso", 0) == 3)
            {
                Frecce[3].SetActive(false);
                PlayerPrefs.SetInt("NFrecciaAttiva", PlayerPrefs.GetInt("NFrecciaAttiva", 0) + 1);
                if (PlayerPrefs.GetInt("NAccesso", 0) < 10)
                {
                    PlayerPrefs.SetInt("NAccesso", PlayerPrefs.GetInt("NAccesso", 0) + 1);
                }
                AttivazioneStartFrecce();

            }

            info[0].SetActive(true);
            PannelloConferma.SetActive(false);

        }
        public void missioni()
        {
            missione.SetActive(true);
        }
        public void palla0()
        {
            if (PlayerPrefs.GetString("Palla0", "Sbloccata") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 0);
            }
        }
        public void palla1()
        {

            if (PlayerPrefs.GetString("Palla1") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 1);
            }
        }
        public void palla2()
        {

            if (PlayerPrefs.GetString("Palla2") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 2);
            }
        }
        public void palla3()
        {
            if (PlayerPrefs.GetString("Palla3") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 3);
            }
        }
        public void palla4()
        {
            if (PlayerPrefs.GetString("Palla4") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 4);
            }
        }
        public void palla5()
        {
            if (PlayerPrefs.GetString("Palla5") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 5);
            }
        }
        public void palla6()
        {
            if (PlayerPrefs.GetString("Palla6") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 6);
            }
        }
        public void palla7()
        {
            if (PlayerPrefs.GetString("Palla7") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 7);
            }
        }
        public void palla8()
        {
            if (PlayerPrefs.GetString("Palla8") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 8);
            }
        }
        public void palla9()
        {
            if (PlayerPrefs.GetString("Palla9") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 9);
            }
        }
        public void palla10()
        {
            if (PlayerPrefs.GetString("Palla10") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 10);
            }
        }
        public void palla11()
        {
            if (PlayerPrefs.GetString("Palla11") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 11);
            }
        }
        public void palla12()
        {
            if (PlayerPrefs.GetString("Palla12") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 12);
            }
        }
        public void palla13()
        {
            if (PlayerPrefs.GetString("Palla13") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 13);
            }
        }
        public void palla14()
        {
            //if (pallineMenù[0].sharedMaterial == materialiPalline[7] & pallineMenù[6].sharedMaterial == materialiPalline[13] & pallineMenù[5].sharedMaterial == materialiPalline[12] & pallineMenù[4].sharedMaterial == materialiPalline[11] & pallineMenù[3].sharedMaterial == materialiPalline[10] & pallineMenù[2].sharedMaterial == materialiPalline[9] & pallineMenù[1].sharedMaterial == materialiPalline[8])

            if (PlayerPrefs.GetString("Palla14") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 14);
            }
        }
        public void palla15()
        {
            if (PlayerPrefs.GetString("Palla15") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 15);
            }
        }
        public void palla16()
        {
            if (PlayerPrefs.GetString("Palla16") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 16);
            }
        }
        public void palla17()
        {
            if (PlayerPrefs.GetString("Palla17") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 17);
            }
        }
        public void palla18()
        {
            if (PlayerPrefs.GetString("Palla18") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 18);
            }
        }
        public void palla19()
        {
            if (PlayerPrefs.GetString("Palla19") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 19);
            }
        }
        public void palla20()
        {
            if (PlayerPrefs.GetString("Palla20") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 20);
            }
        }
        public void palla21()
        {
            if (PlayerPrefs.GetString("Palla21") == "Sbloccata")
            {
                PlayerPrefs.SetInt("ColoreScelto", 21);
            }
        }
        public void tornaMenuPalline()
        {

            if (AccScroll.FinitoMovimento == true && AccScroll.SpinCliccato == false)
            {
                // missione.SetActive(false);
                menùPalline.SetActive(false);
                UIMenùPrincipale.SetActive(true);
                SferaMenù.SetActive(true);
                BloccoMenù.SetActive(true);


                /*
             if (PlayerPrefs.GetString("PrimoAccesso", "si") == "no")
             {
                 AccAdsManager.ShowInterstitial();
             }
             */


            }

            /*Testi[1].SetActive(false);
            Testi[2].SetActive(false);
            Testi[3].SetActive(false);
            Testi[4].SetActive(false);
            Testi[5].SetActive(false);
            Testi[6].SetActive(false);
            Testi[7].SetActive(false);
            Testi[8].SetActive(false);
            Choose[0].SetActive(false);
            Choose[0].SetActive(false);
            Choose[0].SetActive(false);
            Choose[0].SetActive(false);
            Choose[0].SetActive(false);
            Choose[0].SetActive(false);
            Choose[0].SetActive(false);
            Choose[0].SetActive(false);
            Choose[0].SetActive(false);*/

        }
        public void menuPalline()
        {
            if (PlayerPrefs.GetInt("NAccesso", 0) == 2 || PlayerPrefs.GetInt("NAccesso", 0) > 7)
            {
                Frecce[2].SetActive(false);
                PlayerPrefs.SetInt("NFrecciaAttiva", PlayerPrefs.GetInt("NFrecciaAttiva", 0) + 1);
                if (PlayerPrefs.GetInt("NAccesso", 0) < 10)
                {
                    PlayerPrefs.SetInt("NAccesso", PlayerPrefs.GetInt("NAccesso", 0) + 1);
                }
                AttivazioneStartFrecce();



                if (PlayerPrefs.GetInt("ContatoreSpinComune", 1) > 0)
                {
                    x[0].SetActive(true);
                    ContatoreSpinOmaggioGMOB[0].SetActive(true);
                    ContatoreSpinOmaggio[0].text = PlayerPrefs.GetInt("ContatoreSpinComune", 1).ToString();
                }
                else
                {
                    x[0].SetActive(false);
                    ContatoreSpinOmaggioGMOB[0].SetActive(false);
                }
                if (PlayerPrefs.GetInt("ContatoreSpinRaro", 0) > 0)
                {
                    x[1].SetActive(true);
                    ContatoreSpinOmaggioGMOB[1].SetActive(true);
                    ContatoreSpinOmaggio[1].text = PlayerPrefs.GetInt("ContatoreSpinRaro").ToString();

                }
                else
                {
                    x[1].SetActive(false);
                    ContatoreSpinOmaggioGMOB[1].SetActive(false);
                }
                if (PlayerPrefs.GetInt("ContatoreSpinEpico", 0) > 0)
                {
                    x[2].SetActive(true);
                    ContatoreSpinOmaggioGMOB[2].SetActive(true);
                    ContatoreSpinOmaggio[2].text = PlayerPrefs.GetInt("ContatoreSpinEpico").ToString();

                }
                else
                {
                    x[2].SetActive(false);
                    ContatoreSpinOmaggioGMOB[2].SetActive(false);
                }
                menùPalline.SetActive(true);
                UIMenùPrincipale.SetActive(false);
                SferaMenù.SetActive(false);
                BloccoMenù.SetActive(false);
                ContatoreMonete.text = PlayerPrefs.GetInt("MonetePossedute", 200).ToString();
                // Image1.transform.position = transform.position - new Vector3(1200, 0, 0);
                //Image2.transform.position = new Vector3(-1200, transform.position.y, transform.position.z);
            }
        }
        public void tornaMenuPrincipale()
        {
            if (AccScroll.FinitoMovimento == true && AccScroll.SpinCliccato == false)
            {
                RecordMenù.text = PlayerPrefs.GetInt("RecordDistanza").ToString();

                menùPalline.SetActive(false);
                /*Testi[1].SetActive(false);
                Testi[2].SetActive(false);
                Testi[3].SetActive(false);
                Testi[4].SetActive(false);
                Testi[5].SetActive(false);
                Testi[6].SetActive(false);
                Testi[7].SetActive(false);
                Testi[8].SetActive(false);
                missione.SetActive(false);*/
                UIMenù.SetActive(true);
                UIMenùPrincipale.SetActive(true);
                SferaMenù.SetActive(true);
                BloccoMenù.SetActive(true);
                ChiudiInfo();
                ChiudiPannelliSpin();
                ChiudiRicompensa50();
                ChiudiPannelloRicompensa250();
                ChiudiPannelloRicompensa100();
                ContatoreMoneteMenùPrincipale.text = PlayerPrefs.GetInt("MonetePossedute", 200).ToString();
            }

            /*
                    if (PlayerPrefs.GetString("PrimoAccesso", "si") == "no")
                    {
                        AccAdsManager.ShowInterstitial();
                    }
                    */

        }
        public void EscimenùStats()
        {

            if (PlayerPrefs.GetInt("NAccesso", 0) == 6)
            {
                Frecce[6].SetActive(false);
                PlayerPrefs.SetInt("NFrecciaAttiva", PlayerPrefs.GetInt("NFrecciaAttiva", 0) + 1);
                if (PlayerPrefs.GetInt("NAccesso", 0) < 10)
                {
                    PlayerPrefs.SetInt("NAccesso", PlayerPrefs.GetInt("NAccesso", 0) + 1);
                }

                AttivazioneStartFrecce();

            }
            GMJMenuStats.SetActive(false);
            UIMenùPrincipale.SetActive(true);
            SferaMenù.SetActive(true);
            BloccoMenù.SetActive(true);

            /*
               if (PlayerPrefs.GetString("PrimoAccesso", "si") == "no")
               {
                   AccAdsManager.ShowInterstitial();
               }
               */

        }
        public void missione1()
        {
            missione.SetActive(true);
            Testi[1].SetActive(true);
            Testi[2].SetActive(false);
            Testi[3].SetActive(false);
            Testi[4].SetActive(false);
            Testi[5].SetActive(false);
            Testi[6].SetActive(false);
            Testi[7].SetActive(false);
            Testi[8].SetActive(false);
        }
        public void missione2()
        {

            missione.SetActive(true);
            Testi[2].SetActive(true);
            Testi[1].SetActive(false);
            Testi[3].SetActive(false);
            Testi[4].SetActive(false);
            Testi[5].SetActive(false);
            Testi[6].SetActive(false);
            Testi[7].SetActive(false);
            Testi[8].SetActive(false);

        }
        public void missione3()
        {

            missione.SetActive(true);
            Testi[3].SetActive(true);
            Testi[2].SetActive(false);
            Testi[1].SetActive(false);
            Testi[4].SetActive(false);
            Testi[5].SetActive(false);
            Testi[6].SetActive(false);
            Testi[7].SetActive(false);
            Testi[8].SetActive(false);
        }
        public void missione4()
        {

            missione.SetActive(true);
            Testi[4].SetActive(true);
            Testi[2].SetActive(false);
            Testi[3].SetActive(false);
            Testi[1].SetActive(false);
            Testi[5].SetActive(false);
            Testi[6].SetActive(false);
            Testi[7].SetActive(false);
            Testi[8].SetActive(false);
        }
        public void missione5()
        {

            missione.SetActive(true);
            Testi[5].SetActive(true);
            Testi[2].SetActive(false);
            Testi[3].SetActive(false);
            Testi[4].SetActive(false);
            Testi[1].SetActive(false);
            Testi[6].SetActive(false);
            Testi[7].SetActive(false);
            Testi[8].SetActive(false);
        }
        public void missione6()
        {

            missione.SetActive(true);
            Testi[6].SetActive(true);
            Testi[2].SetActive(false);
            Testi[3].SetActive(false);
            Testi[4].SetActive(false);
            Testi[5].SetActive(false);
            Testi[1].SetActive(false);
            Testi[7].SetActive(false);
            Testi[8].SetActive(false);
        }
        public void missione7()
        {

            missione.SetActive(true);
            Testi[7].SetActive(true);
            Testi[2].SetActive(false);
            Testi[3].SetActive(false);
            Testi[4].SetActive(false);
            Testi[5].SetActive(false);
            Testi[6].SetActive(false);
            Testi[1].SetActive(false);
            Testi[8].SetActive(false);
        }
        public void missione8()
        {
            missione.SetActive(true);
            Testi[8].SetActive(true);
            Testi[2].SetActive(false);
            Testi[3].SetActive(false);
            Testi[4].SetActive(false);
            Testi[5].SetActive(false);
            Testi[6].SetActive(false);
            Testi[7].SetActive(false);
            Testi[1].SetActive(false);
        }
        public void ChiudiOptions()
        {
            // RecordMenù.text = PlayerPrefs.GetInt("RecordDistanza").ToString();

            //GMJMenuStats.SetActive(false);
            MenùOptions.SetActive(false);
            UIMenùPrincipale.SetActive(true);
            SferaMenù.SetActive(true);
            BloccoMenù.SetActive(true);

            /*
                    if (PlayerPrefs.GetString("PrimoAccesso", "si") == "no")
                    {
                        AccAdsManager.ShowInterstitial();
                    }
                    */

        }
        public void ApriOptions()
        {
            if (PlayerPrefs.GetInt("NAccesso", 0) == 0 || PlayerPrefs.GetInt("NAccesso", 0) > 7)
            {
                Frecce[0].SetActive(false);
                PlayerPrefs.SetInt("NFrecciaAttiva", PlayerPrefs.GetInt("NFrecciaAttiva", 0) + 1);
                if (PlayerPrefs.GetInt("NAccesso", 0) < 10)
                {
                    PlayerPrefs.SetInt("NAccesso", PlayerPrefs.GetInt("NAccesso", 0) + 1);
                }

                AttivazioneStartFrecce();



                MenùOptions.SetActive(true);
                UIMenùPrincipale.SetActive(false);
                SferaMenù.SetActive(false);
                BloccoMenù.SetActive(false);
            }

            /*while (MenùStats.alpha != 1)
               {
                   MenùStats.alpha = MenùStats.alpha + 0.0001f;
               }*/


        }
        public void ApriStats()
        {


            GMJMenuStats.SetActive(true);
            UIMenùPrincipale.SetActive(false);
            SferaMenù.SetActive(false);
            BloccoMenù.SetActive(false);


        }
        public void ChiudiExitGame()
        {
            AreUSurePanel.SetActive(false);
            ScrittaExitGame.SetActive(true);
        }
        public void ApriExitGame()
        {
            AreUSurePanel.SetActive(true);
            ScrittaExitGame.SetActive(false);

        }
        public void checkMissioni()
        {
            if (PlayerPrefs.GetInt("VolteASinistra", 0) >= volteASinistra)
            {
                pallineMenù[0].sharedMaterial = materialiPalline[7];
            }
            if (PlayerPrefs.GetInt("VolteADestra", 0) >= volteADestra)
            {
                pallineMenù[1].sharedMaterial = materialiPalline[8];
            }
            if (PlayerPrefs.GetInt("RecordDistanza", 0) >= PunteggioDaRaggiungere)
            {
                pallineMenù[2].sharedMaterial = materialiPalline[9];
            }
            if (PlayerPrefs.GetInt("RecordPartiteGiocate", 0) >= 10)
            {
                pallineMenù[3].sharedMaterial = materialiPalline[10];
            }
            if (PlayerPrefs.GetInt("RecordMonetePartita", 0) >= 10)
            {
                pallineMenù[4].sharedMaterial = materialiPalline[11];
            }
            if (PlayerPrefs.GetInt("MoneteRaccolte", 0) >= 10)
            {
                pallineMenù[5].sharedMaterial = materialiPalline[12];
            }
            if (PlayerPrefs.GetInt("OstacoliSuperati", 0) >= OstacoliDaEvitare)

            {
                pallineMenù[6].sharedMaterial = materialiPalline[13];
            }

            /*if (pallineMenù[0].sharedMaterial == materialiPalline[7] & pallineMenù[6].sharedMaterial == materialiPalline[13] & pallineMenù[5].sharedMaterial == materialiPalline[12] & pallineMenù[4].sharedMaterial == materialiPalline[11] & pallineMenù[3].sharedMaterial == materialiPalline[10] &pallineMenù[2].sharedMaterial == materialiPalline[9]  & pallineMenù[1].sharedMaterial == materialiPalline[8])
            {
                pallineMenù[7].sharedMaterial = materialiPalline[7];
            }*/
        }
        public void trovaPallina()
        {
            click = true;
        }
        public void BTNSuoni()
        {
            if (PlayerPrefs.GetString("VolumeONOFF", "") == "on" || PlayerPrefs.GetString("VolumeONOFF", "") == "")
            {
                suoniBTN.spriteName = "volumeOFF";
                PlayerPrefs.SetString("VolumeONOFF", "off");
                //  volumeImpostato = PlayerPrefs.GetString("VolumeONOFF");
            }
            else if (PlayerPrefs.GetString("VolumeONOFF", "") == "off")
            {
                suoniBTN.spriteName = "volumeON";
                PlayerPrefs.SetString("VolumeONOFF", "on");
                //  volumeImpostato = PlayerPrefs.GetString("VolumeONOFF");
            }
        }
        public void estrazioneComune()
        {
            NumeroEstratto = UnityEngine.Random.Range(1, 136);

            if (NumeroEstratto <= 10)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 0);
                if (PlayerPrefs.GetString("Palla1") == "Sbloccata")
                {
                    PlayerPrefs.SetInt("MonetePossedute", PlayerPrefs.GetInt("MonetePossedute") + 15);
                }
                else
                {
                    PlayerPrefs.SetString("Palla1", "Sbloccata");

                }
            }
            else if (NumeroEstratto <= 20)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 1);

            }
            else if (NumeroEstratto <= 30)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 2);

            }
            else if (NumeroEstratto <= 40)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 3);

            }
            else if (NumeroEstratto <= 50)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 4);

            }
            else if (NumeroEstratto <= 60)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 5);

            }
            else if (NumeroEstratto <= 70)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 6);

            }
            else if (NumeroEstratto <= 80)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 7);

            }
            else if (NumeroEstratto <= 90)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 8);

            }
            else if (NumeroEstratto <= 100)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 9);

            }
            else if (NumeroEstratto <= 110)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 10);

            }
            else if (NumeroEstratto <= 113)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 11);

            }
            else if (NumeroEstratto <= 116)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 12);

            }
            else if (NumeroEstratto <= 119)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 13);

            }
            else if (NumeroEstratto <= 122)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 14);

            }
            else if (NumeroEstratto <= 125)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 15);

            }
            else if (NumeroEstratto <= 128)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 16);

            }
            else if (NumeroEstratto <= 131)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 17);

            }
            else if (NumeroEstratto <= 132)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 18);

            }
            else if (NumeroEstratto <= 133)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 19);

            }
            else if (NumeroEstratto <= 134)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 20);

            }
            else if (NumeroEstratto <= 135)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 21);

            }
        }
        public void estrazioneRara()
        {
            NumeroEstratto = UnityEngine.Random.Range(1, 61);
            if (NumeroEstratto <= 8)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 11);

            }
            else if (NumeroEstratto <= 16)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 12);

            }
            else if (NumeroEstratto <= 24)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 13);

            }
            else if (NumeroEstratto <= 32)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 14);

            }
            else if (NumeroEstratto <= 40)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 15);

            }
            else if (NumeroEstratto <= 48)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 16);

            }
            else if (NumeroEstratto <= 56)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 17);

            }
            else if (NumeroEstratto <= 57)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 18);

            }
            else if (NumeroEstratto <= 58)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 19);

            }
            else if (NumeroEstratto <= 59)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 20);

            }
            else if (NumeroEstratto <= 60)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 21);

            }
        }
        public void estrazioneEpica()
        {
            NumeroEstratto = UnityEngine.Random.Range(1, 5);
            if (NumeroEstratto <= 1)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 18);

            }
            else if (NumeroEstratto <= 2)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 19);

            }
            else if (NumeroEstratto <= 3)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 20);

            }
            else if (NumeroEstratto <= 4)
            {
                PlayerPrefs.SetInt("NPallinaEstratta", 21);

            }
        }
        public void ChiudiPannelliSpin()
        {
            PannelloConferma.SetActive(false);
            PannelloSpinComune.SetActive(true);
            PannelloSpinEpico.SetActive(false);
            PannelloSpinRaro.SetActive(false);


        }
        public int GestioneMissione1()
        {
            if (PlayerPrefs.GetInt("1Step", 1) == 1)
            {
                DaBattere[0] = DaFareStep2[0];
                return DaFareStep1[0];

            }
            else if (PlayerPrefs.GetInt("1Step", 1) == 2)
            {
                DaBattere[0] = DaFareStep3[0];
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
        public void EsciGioco()
        {
            Application.Quit();
        }
        public void AttivazioneStartFrecce()
        {
            if (PlayerPrefs.GetInt("NFrecciaAttiva", 0) == 0)
            {
                Frecce[0].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("NFrecciaAttiva", 1) == 1)
            {
                Frecce[1].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("NFrecciaAttiva", 2) == 2)
            {
                Frecce[2].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("NFrecciaAttiva", 3) == 3)
            {
                Frecce[3].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("NFrecciaAttiva", 4) == 4)
            {
                Frecce[4].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("NFrecciaAttiva", 5) == 5)
            {
                Frecce[5].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("NFrecciaAttiva", 6) == 6)
            {
                Frecce[6].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("NFrecciaAttiva", 7) == 7)
            {
                Frecce[7].SetActive(true);
            }

        }
        public void DayCheck()
        {

            DateTime oldDate;


            string newStringDate;

            string stringDate = PlayerPrefs.GetString("PlayDate", " ");



            DateTime newDate = System.DateTime.Now;
            /*if (!DateTime.TryParse(stringDate, out oldDate))
            {
                print("Failure");
            }*/
            oldDate = DateTime.Parse(stringDate);
            print(oldDate);
            // Debug.Log("LastDay: " + oldDate);
            //Debug.Log("CurrDay: " + newDate);

            int difference = newDate.Subtract(oldDate).Days;
            print(difference);
            if (difference >= 2)
            {
                print("diff2");
                PlayerPrefs.SetInt("Day", 1);
                BackDailyReward.SetActive(true);

            }
            else if (difference >= 1)
            {
                Debug.Log("New Reward!");
                newStringDate = Convert.ToString(newDate);
                PlayerPrefs.SetString("PlayDate", newStringDate);
                BackDailyReward.SetActive(true);
                if (PlayerPrefs.GetInt("Day", 1) < 7)
                {
                    PlayerPrefs.SetInt("Day", PlayerPrefs.GetInt("Day", 1) + 1);
                }
                else
                {
                    PlayerPrefs.SetInt("Day", 1);
                }

                Day.text = "Day " + PlayerPrefs.GetInt("Day", 1).ToString();
            }
            if (PlayerPrefs.GetInt("Day", 1) == 1 || PlayerPrefs.GetInt("Day", 1) == 2 && PlayerPrefs.GetInt("Day", 1) == 3)
            {
                ImmagineSpin.spriteName = "SPIN50";
                NumeroSpin.text = "50";
            }
            else if (PlayerPrefs.GetInt("Day", 1) == 4 || PlayerPrefs.GetInt("Day", 1) == 5 && PlayerPrefs.GetInt("Day", 1) == 6)
            {
                ImmagineSpin.spriteName = "SPIN100";
                NumeroSpin.text = "100";
            }
            else if (PlayerPrefs.GetInt("Day", 1) == 7)
            {
                ImmagineSpin.spriteName = "SPIN250";
                NumeroSpin.text = "250";
            }
            if (PlayerPrefs.GetInt("Day", 1) == 2 || PlayerPrefs.GetInt("Day", 1) == 5)
            {
                ImmagineSpinGMOB.SetActive(false);

            }
        }
        public void DailyReward()
        {
            print("ciao");
            if (PlayerPrefs.GetInt("Day", 1) == 1)
            {
                BackDailyReward.SetActive(false);
                menùPalline.SetActive(true);
                UIMenùPrincipale.SetActive(false);
                SferaMenù.SetActive(false);
                BloccoMenù.SetActive(false);
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                ContatoreSpinOmaggio[0].text = PlayerPrefs.GetInt("ContatoreSpinComune", 1).ToString();

            }
            else if (PlayerPrefs.GetInt("Day", 1) == 2)
            {
                int step = 1;
                if (step == 1)
                {
                    PlayerPrefs.SetInt("MonetePossedute", PlayerPrefs.GetInt("MonetePossedute", 200) + 30);
                    ContatoreMonete.text = PlayerPrefs.GetInt("MonetePossedute", 200).ToString();
                    PiuTrenta.GetComponent<TweenAlpha>().PlayForward();
                    ImmagineSpinGMOB.SetActive(true);

                    ImmagineSpin.GetComponent<TweenAlpha>().PlayForward();
                    step++;
                }
                else if (step == 2)
                {
                    PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                    ContatoreSpinOmaggio[0].text = PlayerPrefs.GetInt("ContatoreSpinComune", 1).ToString();
                    BackDailyReward.SetActive(false);
                    menùPalline.SetActive(true);
                    UIMenùPrincipale.SetActive(false);
                    SferaMenù.SetActive(false);
                    BloccoMenù.SetActive(false);
                }
            }
            else if (PlayerPrefs.GetInt("Day", 1) == 3)
            {
                BackDailyReward.SetActive(false);
                menùPalline.SetActive(true);
                UIMenùPrincipale.SetActive(false);
                SferaMenù.SetActive(false);
                BloccoMenù.SetActive(false);
                PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 2);
                ContatoreSpinOmaggio[0].text = PlayerPrefs.GetInt("ContatoreSpinComune", 1).ToString();
            }
            else if (PlayerPrefs.GetInt("Day", 1) == 4)
            {
                BackDailyReward.SetActive(false);
                menùPalline.SetActive(true);
                UIMenùPrincipale.SetActive(false);
                SferaMenù.SetActive(false);
                BloccoMenù.SetActive(false);
                PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                ContatoreSpinOmaggio[1].text = PlayerPrefs.GetInt("ContatoreSpinRaro", 1).ToString();
            }
            else if (PlayerPrefs.GetInt("Day", 1) == 5)
            {
                int step = 1;
                if (step == 1)
                {
                    PlayerPrefs.SetInt("MonetePossedute", PlayerPrefs.GetInt("MonetePossedute", 200) + 30);
                    ContatoreMonete.text = PlayerPrefs.GetInt("MonetePossedute", 200).ToString();
                    PiuTrenta.GetComponent<TweenAlpha>().PlayForward();
                    ImmagineSpinGMOB.SetActive(true);
                    ImmagineSpin.GetComponent<TweenAlpha>().PlayForward();
                    step++;
                }
                else if (step == 2)
                {
                    PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                    ContatoreSpinOmaggio[1].text = PlayerPrefs.GetInt("ContatoreSpinRaro", 1).ToString();
                    BackDailyReward.SetActive(false);
                    menùPalline.SetActive(true);
                    UIMenùPrincipale.SetActive(false);
                    SferaMenù.SetActive(false);
                    BloccoMenù.SetActive(false);
                }
            }
            else if (PlayerPrefs.GetInt("Day", 1) == 6)
            {

                if (step == 1)
                {
                    PlayerPrefs.SetInt("ContatoreSpinComune", PlayerPrefs.GetInt("ContatoreSpinComune") + 1);
                    ContatoreSpinOmaggio[0].text = PlayerPrefs.GetInt("ContatoreSpinComune", 1).ToString();
                    ImmagineSpin.GetComponent<TweenAlpha>().PlayForward();
                    step++;
                    CambioImmagineComuneRaro();
                    ImmagineSpin.GetComponent<TweenAlpha>().PlayReverse();

                }
                else if (step == 2)
                {
                    PlayerPrefs.SetInt("ContatoreSpinRaro", PlayerPrefs.GetInt("ContatoreSpinRaro") + 1);
                    ContatoreSpinOmaggio[1].text = PlayerPrefs.GetInt("ContatoreSpinRaro", 1).ToString();
                    BackDailyReward.SetActive(false);
                    menùPalline.SetActive(true);
                    UIMenùPrincipale.SetActive(false);
                    SferaMenù.SetActive(false);
                    BloccoMenù.SetActive(false);
                }
            }
            else if (PlayerPrefs.GetInt("Day", 1) == 7)
            {
                BackDailyReward.SetActive(false);
                menùPalline.SetActive(true);
                UIMenùPrincipale.SetActive(false);
                SferaMenù.SetActive(false);
                BloccoMenù.SetActive(false);
                PlayerPrefs.SetInt("ContatoreSpinEpico", PlayerPrefs.GetInt("ContatoreSpinEpico") + 1);
                ContatoreSpinOmaggio[2].text = PlayerPrefs.GetInt("ContatoreSpinEpico", 1).ToString();
            }

        }
        public void CambioImmagineComuneRaro()
        {
            if (step == 1)
            {
                ImmagineSpin.spriteName = "SPIN100";
                NumeroSpin.text = "100";
            }
        }
        public IEnumerator AspettaAccentramento()
        {
            float i = 1;
            print("poli");
            while (i > 0)
            {
                i = i - Time.deltaTime;
                yield return null;
            }
            yield return null;
        }
       
    }


