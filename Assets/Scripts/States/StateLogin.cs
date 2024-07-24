//进入声明
public class StateLogin : IState
{
    //开始
    public override void OnEnter()
    {
        //显示进入UI
        UIManager.Show<UILogin>();

    }

    //初始化各类父节点
  
    //离开
    public override void OnExit()
    {
        //隐藏UI
        UIManager.Hide<UILogin>();
    }

    public override void OnFixedUpdate()
    {
        
    }
}