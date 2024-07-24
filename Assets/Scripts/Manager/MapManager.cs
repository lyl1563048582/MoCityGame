using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager 
{
    public static readonly MapManager Inst = Singleton<MapManager>.Inst;

    //��ͼ���������
    private MapBuilder mapCreat;

    private Transform transform;

    public Transform path;

    public void Born(Transform _tran)
    {
        transform = _tran;
        mapCreat = transform.gameObject.AddComponent<MapBuilder>();
        mapCreat.StartMap();
    }
}
