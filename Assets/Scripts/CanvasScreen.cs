using System;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasScreen : MonoBehaviour
{
    [System.Serializable]
    protected class ScreenData
    {
        [Tooltip("Toda tela deve ter um nome que possa ser chamada")]
        public string screenName;
        public string previusScreenName;
        public string nextScreenName;
    }

    [Tooltip("Toda tela deve ter uma base de canvas group")]
    public CanvasGroup canvasgroup;
    [SerializeField] protected ScreenData data;

    public virtual void OnEnable()
    {
        if (canvasgroup == null)
        {
            canvasgroup = GetComponent<CanvasGroup>();
        }
        ScreenManager.CallScreen += CallScreenListner;
    }

    public virtual void OnDisable()
    {
        ScreenManager.CallScreen -= CallScreenListner;
    }

    public virtual void CallScreenListner(string screenName)
    {
        if (screenName == data.screenName)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }
    }

    public void Setup(ScreenPrefab screenPrefab)
    {
        data.screenName = screenPrefab.screenName;
        data.nextScreenName = screenPrefab.nextScreenName;
        data.previusScreenName = screenPrefab.previusScreenName;
    }

    public virtual void TurnOn()
    {
        canvasgroup.alpha = 1;
        canvasgroup.blocksRaycasts = true;
    }

    public virtual void TurnOff()
    {
        canvasgroup.alpha = 0;
        canvasgroup.blocksRaycasts = false;
        Destroy(this.gameObject);
    }

    public bool IsOn()
    {
        return canvasgroup.blocksRaycasts;
    }

    public virtual void CallNextScreen()
    {
        var nextScreenPrefab = ScreenManager.Instance.GetScreenPrefab(data.nextScreenName);
        if (nextScreenPrefab != null)
        {
            ScreenManager.Instance.SetCallScreen(data.nextScreenName);
        }
        else
        {
            Debug.LogError($"Next screen prefab not found for {data.screenName}");
        }
    }

    public virtual void CallPreviusScreen()
    {
        var previousScreenPrefab = ScreenManager.Instance.GetScreenPrefab(data.previusScreenName);
        if (previousScreenPrefab != null)
        {
            ScreenManager.Instance.SetCallScreen(data.previusScreenName);
        }
        else
        {
            Debug.LogError($"Previous screen prefab not found for {data.screenName}");
        }
    }
}
