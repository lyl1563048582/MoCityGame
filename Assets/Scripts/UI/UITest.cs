using System;
using UnityEngine;
using UnityEngine.UI;
//主ui
public class UITest : UIBase
{

#region  初始化界面
 
    public override UILayer Layer => UILayer.Message;
  
    //点击按钮加载方法
    protected override void OnLoad()
    {
        GetComponent<Button>("Button").onClick.AddListener(OnClick);
    }

    //点击事件
    private void OnClick()
    {
        Debug.Log("点击事件");
        UIManager.Show<UITest>();
    }

    #endregion

    protected override void OnFixedUpdate()
    {
        //Debug.LogError(Time.time);
        if (Input.GetKeyDown(KeyCode.A)) GlobalNotifier.Notify(UIMainProp.ResetGameEvent.Name, new UIMainProp.ResetGameEvent(0));
        if (Input.GetKeyDown(KeyCode.B)) { UIManager.Hide<UITest>(); UIManager.Hide<UIMain>(); }
    }

    #region 刷新页面
    //每次显示的时候都会调用
    protected override void OnShow(object[] paramObjects)
    {
        Debug.Log("启动");
        //注册消息
        //GlobalNotifier.Attach(UIMainProp.ResetGameEvent.Name, OnPropChange);
    }
    protected override void OnAttach(object[] paramObjects)
    {
        Debug.Log("注册消息");
        //注册消息
        GlobalNotifier.Attach(UIMainProp.ResetGameEvent.Name, OnPropChange);
    }

    //注销
    protected override void OnHide()
    {
        GlobalNotifier.Detach(UIMainProp.ResetGameEvent.Name, OnPropChange);
    }

    //接受消息(订阅者)，接受之后调用的方法
    private void OnPropChange(NotifyEvent notifyEvent)
    {
        var _updateEvent = notifyEvent as UIMainProp.ResetGameEvent;
        if (_updateEvent != null)
        {
            switch (_updateEvent.state)
            {
                case 0: Debug.Log("重置A"); break;
                case 1: Debug.Log("重置B"); break;
            }
        }
    }
#endregion 
    
    
    
}