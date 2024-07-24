using System;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 进入游戏
/// </summary>
public class UILogin : UIBase
{
    public override UILayer Layer => UILayer.Normal;
    public override bool IsDestroyWhenHide => true;//关闭的时候删除

    private Image amount;
    private bool isStart = false;

    protected override void OnLoad()
    {
        amount = GetComponent<Image>("amount");
        amount.fillAmount = 0;
    }

    protected override void OnFixedUpdate()
    {
        if (isStart) return;
        amount.fillAmount += 0.4f*Time.deltaTime;
        if (amount.fillAmount >= 1)
        {
            UIManager.Show<UIMain>();
            UIManager.Hide<UILogin>();
            isStart = true;
        }
    }

}