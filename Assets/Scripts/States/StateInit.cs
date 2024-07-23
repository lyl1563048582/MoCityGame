
//更新声明
public class StateInit : IState
{
    public override void OnEnter()
    {
        UIManager.Show<UILogin>();
        StartTran();
    }


    private void StartTran()
    {
        var _tran = Main.MainScript.transform;
        //Debug.Log("初始化各类父节点");
        MapManager.Inst.Born(_tran.Find("MapManager"));
    }
    public override void OnExit()
    {
        //离开的时候隐藏
    }

    public override void OnFixedUpdate()
    {
        
    }
}