using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class AdsManager : MonoBehaviour
{

    [SerializeField] string gameID = "33675";
    //string adUnitId = "1714445";
    public float MoneteVinte = 40;
    public float MoneteGenerali;
    public float VelocitaIncrementoDecremento = 20;
    public GameObject Incremento;
    public UILabel IncrementoLabel;
    public int SeriePartite = 0;

    public UILabel ContatoreMonete;
    void Awake()
    {
        Advertisement.Initialize(gameID, true);
        
    }
    private void Start()
    {
            MoneteGenerali = PlayerPrefs.GetInt("MonetePossedute", 200);
    }
private void FixedUpdate()
    {
        if (Incremento.activeInHierarchy == true)
        {
            if (MoneteVinte > 1)
            {
                //MoneteGenerali = PlayerPrefs.GetInt("MonetePossedute", 200);
                MoneteGenerali = MoneteGenerali + VelocitaIncrementoDecremento * Time.deltaTime;
                ContatoreMonete.text = Mathf.Floor(MoneteGenerali).ToString();
                MoneteVinte = MoneteVinte - VelocitaIncrementoDecremento * Time.deltaTime;
                IncrementoLabel.text = "+" + (Mathf.Floor(MoneteVinte)).ToString();
            }
            else
            {
                Incremento.SetActive(false);

                PlayerPrefs.SetInt("MonetePossedute", PlayerPrefs.GetInt("MonetePossedute", 200) + 40);
                ContatoreMonete.text = PlayerPrefs.GetInt("MonetePossedute", 200).ToString();
            }
        }
    }
    public void ShowAd(string zone = "")
    {
#if UNITY_EDITOR
        StartCoroutine(WaitForAd());
#endif

       // if (string.Equals(zone, ""))
            zone = "video";

        ShowOptions options = new ShowOptions();
        options.resultCallback = AdCallbackhandler;

        if (Advertisement.IsReady(zone))
            
            Advertisement.Show(zone, options);
    }
    public void ShowRewardedVideo(string zone = "")
    {
        gameObject.GetComponent<TweenScale>().enabled = false;
#if UNITY_EDITOR
        StartCoroutine(WaitForAd());
#endif

        //if (string.Equals(zone, ""))
            zone = null;

        ShowOptions options = new ShowOptions();
        options.resultCallback = AdCallbackhandler;

        if (Advertisement.IsReady(zone))

            Advertisement.Show(zone, options);
    }
    public void ShowInterstitial(string zone = "")
    {
#if UNITY_EDITOR
        StartCoroutine(WaitForAd());
#endif

        //if (string.Equals(zone, ""))
        zone = "interstitial";

        ShowOptions options = new ShowOptions();
        options.resultCallback = AdCallbackhandlerInterstitial;

        if (Advertisement.IsReady(zone))

            Advertisement.Show(zone, options);
        print("Interstitial");
    }
    void AdCallbackhandler(ShowResult result)
    {

        switch (result)
        {
            case ShowResult.Finished:
                gameObject.GetComponent<TweenScale>().enabled = true;

                Incremento.SetActive(true);
                MoneteVinte = 40;


                break;
            case ShowResult.Skipped:
                ShowInterstitial();
                Debug.Log("Ad skipped. Son, I am dissapointed in you");
                break;
            case ShowResult.Failed:
                gameObject.GetComponent<TweenScale>().enabled = true;

                Debug.Log("I swear this has never happened to me before");
                break;
        }
    }
    void AdCallbackhandlerInterstitial(ShowResult result)
    {

        switch (result)
        {
            case ShowResult.Finished:
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad skipped. Son, I am dissapointed in you");
                break;
            case ShowResult.Failed:
                Debug.Log("I swear this has never happened to me before");
                break;
        }
    }
    IEnumerator WaitForAd()
    {
        float currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        yield return null;

        while (Advertisement.isShowing)
            yield return null;

        Time.timeScale = currentTimeScale;
    }
  /*  private void RequestInterstitial()
    {
#if UNITY_ANDROID
        adUnitId = "1714445";
#elif UNITY_IPHONE
 adUnitId = " YOUR_INTERSTITIAL_ID ";
#else
string adUnitId = "unexpected_platform";
#endif
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
        // Create an empty ad request.
        ShowAdMob();
    }
    public void ShowAdMob()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }*/

}