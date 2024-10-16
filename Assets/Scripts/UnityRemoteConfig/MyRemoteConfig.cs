
using System.Threading.Tasks;
using Unity.Services.RemoteConfig;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class MyRemoteConfig : MonoBehaviour
{
    public int playerLife;
    public int maxEnemyLife;
    public float playerSpeed;
    public float enemySpeed;
    public string enemyName;

    //public EnemyNameDisplay myEND;
    //public Player player;
    //public PlayerLife playerLifeScript;
    //public EnemyLife enemyLife;
    //public TemporalEnemyBehaviour myTEB;

    public static MyRemoteConfig Instance { get ; private set; }
    public struct userAttributes { }
    public struct appAttributes { }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    async Task InitializeRemoteConfigAsync()
    {
        // initialize handlers for unity game services
        await UnityServices.InitializeAsync();

        // remote config requires authentication for managing environment information
        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
    }

    async Task Start()
    {
        // initialize Unity's authentication and core services, however check for internet connection
        // in order to fail gracefully without throwing exception if connection does not exist
        if (Utilities.CheckForInternetConnection())
        {
            await InitializeRemoteConfigAsync();
        }

        RemoteConfigService.Instance.FetchCompleted += ApplyRemoteSettings;
        RemoteConfigService.Instance.FetchConfigs(new userAttributes(), new appAttributes());
    }

    void ApplyRemoteSettings(ConfigResponse configResponse)
    {
        Debug.Log("RemoteConfigService.Instance.appConfig fetched: " + RemoteConfigService.Instance.appConfig.config.ToString());


        enemyName = RemoteConfigService.Instance.appConfig.GetString("EnemyName");
        playerLife = RemoteConfigService.Instance.appConfig.GetInt("PlayerLife");
        maxEnemyLife = RemoteConfigService.Instance.appConfig.GetInt("EnemyLife");
        playerSpeed = RemoteConfigService.Instance.appConfig.GetFloat("PlayerSpeed");
        enemySpeed = RemoteConfigService.Instance.appConfig.GetFloat("EnemySpeed");
    }
}