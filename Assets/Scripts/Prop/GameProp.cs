using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProp
{
    public static readonly GameProp Inst = Singleton<GameProp>.Inst;

    public Transform MainTran;

}
