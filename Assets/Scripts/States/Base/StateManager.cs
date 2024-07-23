//管理器声明
public static class StateManager
{
    private static IState _current;
    private static IState _next;
    //一个由接口约束的无参构造泛型
    public static void TranslateTo<T>() where T : IState, new()
    {
        _next = new T();
    }
    //物理更新
    public static void FixedUpdate()
    {
        //当现在的界面逻辑更新完的时候，进行下一个逻辑更新
        if (null != _next)
        {
            _current?.OnExit();
            _current = _next;
            _next = null;
            _current?.OnEnter();
        }
        //循环逻辑更新
        _current?.OnFixedUpdate();
    }
}