using UnityEngine;


public class IStateManager : MonoBehaviour
{

    private IStateAI current;
    private IStateAI next;

    private AIBase ai;
    //一个由接口约束的无参构造泛型
    public void TranslateTo<T>(AIBase _ai) where T : IStateAI, new()
    {
        next = new T();

       // if (_ai as AIRepairman != null) DebugGame.Log("check airepair TranslateTo " + next);

        ai = _ai;
    }
    //物理更新
    public void FixedUpdate()
    {
        //当现在的界面逻辑更新完的时候，进行下一个逻辑更新
        if (null != next)
        {
            current?.OnExit();
            current = next;
            next = null;
            current?.OnEnter(ai);
        }
        //循环逻辑更新
        current?.OnFixedUpdate();
    }
}
