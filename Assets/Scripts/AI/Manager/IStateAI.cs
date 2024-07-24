using System.Collections;
using UnityEngine;

/// <summary>
/// AI抽象层
/// </summary>
public abstract class IStateAI
{

    //继承该接口的函数的开始、更新与退出方法会一直在StateManager中进行物理更新
    public virtual void OnEnter(AIBase _ai)
    {

    }

    public virtual void OnExit()
    {

    }

    public virtual void OnFixedUpdate()
    {

    }
}