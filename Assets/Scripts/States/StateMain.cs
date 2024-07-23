//主声明
public class StateMain : IState
{
    public override void OnEnter()
    {
        UIManager.Show<UIMain>();
        //Prop.Inst.Init();
    }

    public override void OnExit()
    {
        UIManager.Hide<UIMain>();
    }

    public override void OnFixedUpdate()
    {
        
    }
}