using System;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager Instance { get; private set; }

    public static Action<string> CallScreen;
    public static string currentScreenName;
    private Dictionary<string, ScreenPrefab> screenPrefabs = new Dictionary<string, ScreenPrefab>();
    private GameObject currentScreenInstance;
    [SerializeField] private Transform screenSpawnMainParent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void RegisterScreenPrefab(string screenName, ScreenPrefab prefab)
    {
        if (!screenPrefabs.ContainsKey(screenName))
        {
            screenPrefabs.Add(screenName, prefab);
            Debug.Log($"Registered screen prefab: {screenName}");
        }
    }

    public void SetCallScreen(string name)
    {
        CallScreen?.Invoke(name);
        currentScreenName = name;
        LoadScreen(name);
    }

    public void LoadScreen(string screenName)
    {
        if (currentScreenInstance != null)
        {
            Destroy(currentScreenInstance);
        }

        if (screenPrefabs.TryGetValue(screenName, out var screenPrefab))
        {
            currentScreenInstance = Instantiate(screenPrefab.prefab, screenSpawnMainParent);

            var canvasScreen = currentScreenInstance.GetComponent<CanvasScreen>();
            if (canvasScreen != null)
            {
                canvasScreen.Setup(screenPrefab);
            }
            else
            {
                Debug.LogError($"CanvasScreen component not found on instantiated prefab for {screenName}");
            }

            Debug.Log($"Loaded screen prefab: {screenName}");
        }
        else
        {
            Debug.LogError($"Screen prefab not found for {screenName}");
        }
    }

    public ScreenPrefab GetScreenPrefab(string screenName)
    {
        screenPrefabs.TryGetValue(screenName, out var screenPrefab);
        return screenPrefab;
    }

    public void TurnOnCanvasGroup(CanvasGroup c)
    {
        c.alpha = 1;
        c.interactable = true;
        c.blocksRaycasts = true;
    }

    public void TurnOffCanvasGroup(CanvasGroup c)
    {
        c.alpha = 0;
        c.interactable = false;
        c.blocksRaycasts = false;
    }
}
