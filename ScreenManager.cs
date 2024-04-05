using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenManager
{
    public static Action<string> CallScreen;
    public static string currentScreenName;
    public static void SetCallScreen(string name)
    {
        // Chama o evento CallScreen e passa o nome da tela desejada
        CallScreen?.Invoke(name);

        currentScreenName = name;
    }

    public static void TurnOnCanvasGroup(CanvasGroup c)
    {
        c.alpha = 1;
        c.interactable = true;
        c.blocksRaycasts = true;
    }

    public static void TurnOffCanvasGroup(CanvasGroup c)
    {
        c.alpha = 0;
        c.interactable = false;
        c.blocksRaycasts = false;
    }
}
