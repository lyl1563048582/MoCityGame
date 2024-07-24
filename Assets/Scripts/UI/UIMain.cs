using System;
using UnityEngine;
using UnityEngine.UI;
//主ui
public class UIMain : UIBase
{

#region  初始化界面
 
    public override UILayer Layer => UILayer.Back;

    //点击按钮加载方法
    protected override void OnLoad()
    {
        GetComponent<Button>("Button").onClick.AddListener(OnClick);
    }

    //点击事件
    private void OnClick()
    {
        UIManager.Show<UITest>();
    }

    #endregion

    protected override void OnFixedUpdate()
    {
    }

    #region 刷新页面
    //每次显示的时候都会调用
    protected override void OnShow(object[] paramObjects)
    {        
      
    }

    //注销
    protected override void OnHide()
    {
    }

#endregion 
    
    
    
}