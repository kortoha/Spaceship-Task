using Firebase;
using Firebase.Analytics;
using UnityEngine;

public class Analytics : MonoBehaviour
{
    public static Analytics Instance { get; private set; }

    private bool _isCanUse = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        InitializeFirebase();
    }

    private void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                _isCanUse = true;
            }
            else
            {
                Debug.LogError(System.String.Format(
                    "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
        });
    }

    private void Start()
    {
        LogGameStartEvent();
    }

    public void LogGameStartEvent()
    {
        if (_isCanUse)
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventAppOpen);
        }
    }

    public void LogCollisionEvent()
    {
        if (_isCanUse)
        {
            FirebaseAnalytics.LogEvent("collision_event");
        }
    }
}
