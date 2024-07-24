//单例UI
public static class UISingleton<T> where T : UIBase, new()
{
    public static string Name => Obj.Name;
    public static T Obj ;
    public static bool IsDestroyWhenHide => Obj.IsDestroyWhenHide;
    //显示函数
    public static void Show(object[] paramObjects)
    {
        Load();
        Obj?.Show(paramObjects);
    }
    //隐藏函数并判断隐藏是否为空
    public static void Hide()
    {
        Obj?.Hide();
    }
    //更新函数并判断更新是否为空
    public static void FixedUpdate()
    {
        Obj?.FixedUpdate();
    }
    //删除函数并判断删除是否为空
    public static void Destroy()
    {
        Obj?.Destroy();
        Obj = null;
    }

    //当为空的时候一直装载
    private static void Load()
    {
        if (null != Obj)
        {
            return;
        }

        Obj = Singleton<T>.Inst;
        Obj?.Load();
    }
    

}