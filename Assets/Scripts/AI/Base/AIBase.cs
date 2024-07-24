using UnityEngine;


public class AIBase : InterfaceAI
{


    protected int id;
    public int ID { get { return id; } }

    protected Transform tran;
    public Transform Tran { get { return tran; } }

    protected Collider colTools;//碰撞器

    protected IStateManager MyStateManager;//状态机


    public void Born(Transform _tran, int _id)
    {
        tran = _tran;
        id = _id;
        MyStateManager = new IStateManager();

        OnBorn();
    }
    protected virtual void OnBorn() { }
    /// <summary>
    /// 死亡
    /// </summary>
    public virtual void Die()
    {
        if (colTools != null) GameObject.Destroy(colTools);
        OnDie();
    }
    protected virtual void OnDie()
    {

    }

    /// <summary>
    /// 离开
    /// </summary>
    public void Exit()
    {
        OnExit();
    }
    protected virtual void OnExit() { }

    /// <summary>
    /// 更新
    /// </summary>
    public void Update()
    {
        MyStateManager.FixedUpdate();
        OnUpdate();
    }
    protected virtual void OnUpdate() { }
    void InterfaceAI.Update()
    {
        throw new System.NotImplementedException();
    }

  
}
