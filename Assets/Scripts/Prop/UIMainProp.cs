using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainProp
{
    public static readonly UIMainProp Inst = Singleton<UIMainProp>.Inst;

    //重置游戏事件
    public class ResetGameEvent : NotifyEvent
    {
        public static string Name => "ResetGameEvent";
        public int state { get; }//0:重置A，1，重置B

        public ResetGameEvent(int _state)
        {
            state = _state;
        }
    }

}
