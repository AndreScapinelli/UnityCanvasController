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
}
