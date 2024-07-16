using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class GameConfiguration 
    {
        public static readonly GameConfiguration Instance = Singleton<GameConfiguration>.Instance;

        public bool IsOpenDebug;
    }