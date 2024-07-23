using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
//UI管理器
public static class UIManager
{
    private static readonly List<string> showNameList = new List<string>();
    //显示、隐藏与删除封装空方法的列表
    private static readonly List<Action> UIShowList = new List<Action>();
    private static readonly List<Action> UIHideList = new List<Action>();
    private static readonly List<Action> UIDestroyList = new List<Action>();
    //将受到UIbase约束的无参构造函数的UI显示与更新
    public static T Show<T>(params object[] paramObjects) where T : UIBase, new()
    {
        UISingleton<T>.Show(paramObjects);  
        string name = UISingleton<T>.Name;         
        if (!showNameList.Contains(name))
        {
            showNameList.Add(name);
            UIShowList.Add(UISingleton<T>.FixedUpdate);
        } 
        return UISingleton<T>.Obj;
    }
    //将受到UIbase约束的无参构造函数的UI隐藏与更新
    public static void Hide<T>() where T : UIBase, new()
    {
        UISingleton<T>.Hide();
        UIHideList.Add(UISingleton<T>.FixedUpdate);
        showNameList.Remove(UISingleton<T>.Name);
        if (UISingleton<T>.IsDestroyWhenHide)
        {
            UIDestroyList.Add(UISingleton<T>.Destroy);
        }
    }
    //固定更新（静态方法不会固定更新，而是由初始化界面的FixedUpdate更新）
    public static void Hide<T>(T window) where T : UIBase, new()
    {      
        Hide<T>();
    }

    public static void FixedUpdate()
    {
        //显示方法列表，移除不在显示列表中的所有隐藏空方法
        for (int i = 0; i < UIShowList.Count; i++)
        {
            UIShowList[i]();
        }
        //如果action里还有Show方法即修改UIShowList会报错
        //foreach (var action in UIShowList)
        //{
        //    action();
        //}
        UIShowList.RemoveAll(item => UIHideList.Contains(item));
        UIHideList.Clear();
        //移除在删除列表中的所有空方法
        foreach (var action in UIDestroyList)
        {
            action();
        }
        UIDestroyList.Clear();
    }
    //层的坐标
    private static Transform[] Layers;
    //UI根节点物体
    private static GameObject UIRootObj;
    //加载层
    private static void LoadLayer()
    {
        //如果根节点不为空的话直接返回
        if (null != UIRootObj)
        {
            return;
        }
        //找到根节点的预制体，预制体为空的时候克隆预制体
        var prefab = Resources.Load<GameObject>("Prefabs/UI/UIRoot");
        if (null != prefab)
        {
            UIRootObj = Object.Instantiate(prefab);
            UIRootObj.name = "UIRoot";
        }
        //将根节点中的位置加载层，并将层添加到队列里面
        var list = new List<Transform>();
        foreach (Transform layer in UIRootObj.transform)
        {
            list.Add(layer);
        }
        Layers = list.ToArray();
    }
    //获取UI位置的层级
    public static Transform GetLayer(UILayer layer)
    {
        LoadLayer();
        return Layers[(int)layer];
    }
}