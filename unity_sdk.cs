using UnityEngine;
using UnityEngine.Advertisements;
 
public class unity_sdk : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId; // put your Id,s here
    [SerializeField] string _iOSGameId; // put your IOS id here
    [SerializeField] bool _testMode = true; // make it True, False on ads type
    private string _gameId;
 
    void Awake()
    {
        InitializeAds();
    }
 
    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }
 
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }
 
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
