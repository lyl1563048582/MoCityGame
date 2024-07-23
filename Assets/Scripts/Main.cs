using UnityEngine;
//主函数：提供所有类的入口
public class Main : MonoBehaviour
{
    //获取主函数
    public static Main MainScript { get; private set; }
    //网络服务器配置
    public string ServerAddress;
    //启动界面
    // Use this for initialization
    private void Start()
    {
        MainScript = this;
        //受到声明管理器约束的启动更新声明
        StateManager.TranslateTo<StateInit>();
        GameProp.Inst.MainTran = transform;
        
    }

 

    //实时更新声明管理器里面的更新，UI管理器里面的更新
    private void FixedUpdate()
    {
        StateManager.FixedUpdate();
        UIManager.FixedUpdate();
    }
}