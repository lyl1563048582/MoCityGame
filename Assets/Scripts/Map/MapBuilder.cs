using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    //主地图物体
    public Transform tranMap;
    public void StartMap()
    {
        Debug.Log("开始创建新图");
        tranMap = GameProp.Inst.MainTran.Find("MapManager");
        MapManager.Inst.path = tranMap.Find("path");
    

        Debug.Log("新图创建完毕");
    }
}
