using HybridCLR;
using System;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat.Storage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 读写脚本：该脚本不再处理除存写之外的逻辑
/// </summary>
public class ReadWrite
{
    public static readonly ReadWrite Inst = Singleton<ReadWrite>.Inst;

    /// <summary>
    /// 定义本地持久化类型
    /// </summary>
    public enum DateKey
    {
        XXXXXXXO,//游戏ID
       
        XOXOXOOO,//TODO:
    }

    private SingletonDate<int> gameID = new SingletonDate<int>(DateKey.XXXXXXXO);
   

    public SingletonDate<int> GameID { get => gameID; set => gameID = value; }
   

    public void Start()
    {
        Debug.Log("start read loacl data");

        GameID.Read(true);
      
    }

   

    #region 常用的类型转换
    public int SetBool(bool _bool) { return _bool ? 1 : 0; }
    public bool GetBool(int _int) { return _int == 1 ? true : false; }

    /// <summary>
    /// 存入其它类型
    /// </summary>
    public string PackagingTList<T>(List<T> _list, string _separator = ",")
    {
        var _str = "";
        for (var idx = 0; idx < _list.Count; idx++)
        {
            if (_str != "") _str += _separator + _list[idx];
            else _str = "" + _list[idx];
        }
        return _str;
    }

    /// <summary>
    /// 解析其它类型
    /// </summary>
    public List<T> UnpackList<T>(string _str, char _separator = ',')
    {
        List<T> m_list = new List<T>();
        string[] _sArray = _str.Split(_separator);
        foreach (string _i in _sArray)
        {
            T _ret = (T)Convert.ChangeType(_i, typeof(T));
            m_list.Add(_ret);
        }
        return m_list;
    }

    #endregion



}

/// <summary>
/// 唯一数据
/// </summary>
public class SingletonDate<T>
{
    public T date;

    public SingletonDate(ReadWrite.DateKey _name) { name = _name.ToString(); }

    public string name;

    /// <summary>
    /// 读取：是否首次读取
    /// </summary>
    public T Read(bool _isStart = false)
    {
        if (!_isStart) return date;
        bool _isHas = ObscuredPrefs.HasKey(name);
        //DebugGame.LogError(_isHas+" : "+name);
        //DebugGame.LogError("type : " + typeof(T).Name);
        switch (typeof(T).Name)
        {
            case "Int32": date = (T)Convert.ChangeType(_isHas ? ObscuredPrefs.GetInt(name) : 0, typeof(T)); break;
            case "Single": date = (T)Convert.ChangeType(_isHas ? ObscuredPrefs.GetFloat(name) : 0f, typeof(T)); break;
            case "String":
            default: date = (T)Convert.ChangeType(_isHas ? ObscuredPrefs.GetString(name) : "", typeof(T)); break;
        }
        if (!_isHas) Write(date);
        return date;
    }

    public void Write(T _t)
    {
        switch (typeof(T).Name)
        {
            case "Int32": ObscuredPrefs.SetInt(name, Convert.ToInt32(_t)); break;
            case "Single": ObscuredPrefs.SetFloat(name, Convert.ToSingle(_t)); break;
            case "String":
            default: ObscuredPrefs.SetString(name, Convert.ToString(_t)); break;
        }
        ObscuredPrefs.HasKey(name);//模拟器问题
        //DebugGame.LogError(ObscuredPrefs.HasKey(name)+"###");
        date = (T)Convert.ChangeType(_t, typeof(T));
    }

}