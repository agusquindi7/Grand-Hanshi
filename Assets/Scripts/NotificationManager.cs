using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance { get; private set; }

    private AndroidNotificationChannel notichannel;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
