//接口方法声明
//开始、退出与更新
public abstract class IState
{
    //继承该接口的函数的开始、更新与退出方法会一直在StateManager中进行物理更新
    public virtual void OnEnter()
    {
        
    }

    public virtual void OnExit()
    {
        
    }

    public virtual void OnFixedUpdate()
    {
        
    }
}