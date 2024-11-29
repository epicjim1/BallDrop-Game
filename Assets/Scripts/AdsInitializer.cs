using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = false;
    private string _gameId;

    [SerializeField] InterstitialAdsButton interstitialAdsButton;
    [SerializeField] RewardedAdsButton rewardedAdsButton;

    public GameObject skipMenu;
    public bool rewardAdInitilized = false;

    void Awake()
    {
        interstitialAdsButton = GameObject.Find("RetryCounter").GetComponent<InterstitialAdsButton>();
        InitializeAds();
    }

    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;
        Advertisement.Initialize("4735468", _testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        interstitialAdsButton.LoadAd();
        //rewardedAdsButton.LoadAd();
    }

    private void Update()
    {
        if (skipMenu.activeInHierarchy)
        {
            if (!rewardAdInitilized)
            {
                rewardedAdsButton.LoadAd();
                rewardAdInitilized = true;
            }
        }
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}