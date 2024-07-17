using HybridCLR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 离线收益计算器
/// </summary>
public class OfflineDate 
{
    public static readonly OfflineDate Inst = Singleton<OfflineDate>.Inst;
    private MyGameConfig config { get { return GameProp.Inst.MyGameConfig; } }

    private long offlineSecs = 0;//离线时长：实际秒数
    public long OffineSecs { get { return offlineSecs; } }
    private int offlineMins = 0;//离线时长：奖励分钟
    public int OfflineMins { get { return offlineMins; } }

    private float maxH = 0;//最多可以获得小时
    public float MaxH { get { return maxH + (MonthCardManager.Inst.MonthCardTwo ? 1 : 0); } }

    public float money = 0f;//每分钟的离线收益

    public float getOffMoney;//获得离线收益
    public float getOffScience;//获得离线收益:科技点1

    //先判断时间，五分钟以上按照满状态计算
    public void Awake(long _time)
    {
        //_time = PublicFunction.TimestampLongMs() - 10000000000;//测试
        offlineSecs =(long)((PublicFunction.TimestampLongMs() - _time) * 0.001f);
        DebugGame.Log("离线：" + offlineSecs);
        maxH = (ShopProp.Inst.IsPrivilegeOffline ? config.offlineTime[1] : config.offlineTime[0]);
        offlineMins = Mathf.Min((int)(60 * MaxH), (int)(offlineSecs / 60));
    }


    //先判断时间，五分钟以上按照满状态计算
    public bool Start()
    {
        var _isOff = offlineSecs >= (60 * config.offlineTime[2]);
        MapManagerProp.Inst.GetBuildingRoom().OfflineBuild(offlineSecs);

        getOffScience = ScienceManage.Inst.OfflineScienceTechnologyPointOutput(offlineMins);
        getOffMoney = GetMoney() * offlineMins;
        DebugGame.Log("离线：" + _isOff);
        return _isOff;
    }

    /// <summary>
    /// VIP重置
    /// </summary>
    public void ResetVIP()
    {
        var _newTime = (int)(offlineSecs / 60);
        if (_newTime <= 60 * config.offlineTime[0]) return;
        offlineMins = Mathf.Min((int)(60 * config.offlineTime[1]), _newTime);
        //getOffScience = ScienceManage.Inst.OfflineScienceTechnologyPointOutput(offlineMins);
        getOffMoney = GetMoney() * offlineMins;
    }

    //获得当前数据每分钟收益，按照满状态计算：30s是游戏里的一小时
    public float GetMoney()
    {
        DebugGame.Log(MapManagerProp.Inst.GetProfitPerHour());
        money = 2 * MapManagerProp.Inst.GetProfitPerHour();
        return money;
    }
}
