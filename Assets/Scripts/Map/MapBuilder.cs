using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    //����ͼ����
    public Transform tranMap;
    public void StartMap()
    {
        Debug.Log("��ʼ������ͼ");
        tranMap = GameProp.Inst.MainTran.Find("MapManager");
        MapManager.Inst.path = tranMap.Find("path");
    

        Debug.Log("��ͼ�������");
    }
}
