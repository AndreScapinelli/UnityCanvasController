using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenCanvasController : MonoBehaviour
{
    public static ScreenCanvasController instance;

    public string previusScreen;
    public string currentScreen;
    public string inicialScreen;
    public float inactiveTimer = 0;

    public CanvasGroup DEBUG_CANVAS;
    public TMP_Text timeOut;

    [Tooltip("Lista de prefabs de telas para registrar")]
    public List<ScreenPrefab> screenPrefabs;

    private void OnEnable()
    {
        ScreenManager.CallScreen += OnScreenCall;
    }

    private void OnDisable()
    {
        ScreenManager.CallScreen -= OnScreenCall;
    }

    void Start()
    {
        instance = this;

        // Registrar os prefabs
        foreach (var screenPrefab in screenPrefabs)
        {
            if (screenPrefab.prefab != null)
            {
                ScreenManager.Instance.RegisterScreenPrefab(screenPrefab.screenName, screenPrefab);
            }
            else
            {
                Debug.LogError($"Prefab for screen {screenPrefab.screenName} is null");
            }
        }

        ScreenManager.Instance.SetCallScreen(inicialScreen);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (DEBUG_CANVAS != null)
            {
                DEBUG_CANVAS.alpha = DEBUG_CANVAS.alpha == 0 ? 1 : 0;
            }
        }

        if (currentScreen != inicialScreen)
        {
            inactiveTimer += Time.deltaTime;

            if (inactiveTimer >= Config.InactiveMaxTime)
            {
                ResetGame();
            }
        }
        else
        {
            inactiveTimer = 0;
        }

        if (timeOut != null)
        {
            timeOut.SetText($"Time Out: {Mathf.CeilToInt(inactiveTimer)}/{Config.InactiveMaxTime}");
        }
    }

    public void ResetGame()
    {
        Debug.Log("Tempo de inatividade extrapolado!");
        inactiveTimer = 0;
        ScreenManager.Instance.SetCallScreen(inicialScreen);
    }

    private void OnScreenCall(string name)
    {
        previusScreen = currentScreen;
        currentScreen = name;
    }

    public void NFCInputHandler(string obj)
    {
        inactiveTimer = 0;
    }
}
