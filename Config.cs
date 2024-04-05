using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEngine;
public class Config
{
    public static float InactiveMaxTime
    {
        get { return JSONFile.Configclass.timeout; }
    }

    public static int PlayerAmountSelectionMaxTime
    {
        get { return JSONFile.Configclass.playerAmountSelectionMaxTime;  }
    }

    public static float ScreenFeedbackTime
    {
        get { return JSONFile.Configclass.feedbackScreenTime; }
    }

    public static float ChallangeMaxTime
    {
        get { return JSONFile.Configclass.challangeMaxTime; }
    }
}
