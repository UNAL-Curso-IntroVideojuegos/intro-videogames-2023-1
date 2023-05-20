using UnityEngine;
using Object=System.Object;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static bool applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting) {
                return null;
            }

            if (Object.ReferenceEquals(_instance, null)) {
                _instance = (T) FindObjectOfType(typeof(T));

                if (_instance == null) {
                    GameObject singleton = new GameObject();
                    _instance = singleton.AddComponent<T>();

                    singleton.name = typeof(T).ToString();

                    DontDestroyOnLoad(singleton);

                    _instance.SendMessage("Init", null, SendMessageOptions.DontRequireReceiver);
                }
            }

            return _instance;
        }
    }

    public static bool HasInstance()
    {
        return !applicationIsQuitting;
    }

    private bool hasInitialized = false;

    public virtual void Init()
    {
        if (this.HasInitialized()) {
            return;
        }

        this.hasInitialized = true;

        Application.quitting += delegate {
            applicationIsQuitting = true;
        };

        this.OnInit();
    }

    public virtual void OnInit()
    {
    }

    public virtual void OnDestroy()
    {
        applicationIsQuitting = true;
    }

    public virtual bool HasInitialized()
    {
        return this.hasInitialized;
    }
}