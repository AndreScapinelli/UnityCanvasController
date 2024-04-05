using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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

    private void OnEnable()
    {
        // Registra o método CallScreenListner como ouvinte do evento CallScreen
        ScreenManager.CallScreen += OnScreenCall;

    }
    private void OnDisable()
    {
        // Remove o método CallScreenListner como ouvinte do evento CallScreen
        ScreenManager.CallScreen -= OnScreenCall;

    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ScreenManager.SetCallScreen(inicialScreen);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!DEBUG_CANVAS == null)
            {
                if (DEBUG_CANVAS.alpha == 0)
                {
                    DEBUG_CANVAS.alpha = 1;
                }
                else
                {
                    DEBUG_CANVAS.alpha = 0;
                }
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            ScreenManager.CallScreen(inicialScreen);
        }

        if (currentScreen != inicialScreen)
        {
            inactiveTimer += Time.deltaTime * 1;

            if (inactiveTimer >= Config.InactiveMaxTime)
            {
                ResetGame();
            }
        }
        else
        {
            inactiveTimer = 0;
        }
        timeOut.SetText($"Time Out:{Mathf.CeilToInt(inactiveTimer)}/{Config.InactiveMaxTime}");
    }
    public void ResetGame()
    {
        Debug.Log("Tempo de inatividade extrapolado!");
        inactiveTimer = 0;
        ScreenManager.CallScreen(inicialScreen);
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
