using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 订阅通知类：使用函数Attach、Detach、Notify
/// 一个回调函数
/// </summary>
public static class GlobalNotifier
{
    private static readonly Dictionary<string, Action<NotifyEvent>> _dictionary = new Dictionary<string, Action<NotifyEvent>>();
    
    /// <summary>
    /// 附加消息列表
    /// </summary>
    /// <param name="附加命令"></param>
    /// <param name="回调函数"></param>
    public static void Attach(string command, Action<NotifyEvent> callback)
    {
        Action<NotifyEvent> action;
        //如果获取到与指定命令关联的方法，将返回添加到方法中，并将其放入到列表中；否则直接将命令添加到列表中
        if (_dictionary.TryGetValue(command, out action))
        {
            action += callback;
            _dictionary[command] = action;
        }
        else
        {
            _dictionary.Add(command, callback);
        }
    }

    /// <summary>
    /// 分离消息列表
    /// </summary>
    /// <param name="执行命令"></param>
    /// <param name="回调函数"></param>
    public static void Detach(string command, Action<NotifyEvent> callback)
    {
        //如果字典中包含了指定命令，则将其在列表中删除
        if (_dictionary.ContainsKey(command))
        {
            _dictionary[command] -= callback;
        }
    }
    
    //通知消息队列
    public static void Notify(string command, NotifyEvent notifyEvent)
    {
        Action<NotifyEvent> action;
        //如果获取到与指定命令关联的方法，则调用通知事件
        if (_dictionary.TryGetValue(command, out action))
        {
            action(notifyEvent);
        }
    }
}