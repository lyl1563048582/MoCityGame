using UnityEngine;

//枚举UI层：主界面、进入、消息、加载
public enum UILayer
{
    Normal,
    Back,
    Message,
    Loading,
}
//所有UI继承的抽象类
public abstract class UIBase
{
    //获得抽象层
    public abstract UILayer Layer { get; }
    //获取名称
    public string Name { get; }
    //是否添加引用
    protected bool isAttach = false;
   
    //获得物体
    public GameObject gameObject
    {
        get;
        private set;
    }

    //获得物体的位置
    public Transform transform => gameObject.transform;

    //通过函数名获取名称
    protected UIBase()
    {
        Name = GetType().Name;
    }

    //没有在显示的时候删除
    public virtual bool IsDestroyWhenHide => false;

    //通过预制体的路径，加载并获得预制体的名字，预制体的名字与函数名字相同，关闭预制体
    public void Load()
    {
        var prefab = Resources.Load<GameObject>($"Prefabs/UI/{GetType().Name}");
        if (null != prefab)
        {
            gameObject = Object.Instantiate(prefab);
            gameObject.name = Name;
            //获得在父物体下的坐标（不保持世界坐标）（在预设好的子物体下）
            gameObject.transform.SetParent(UIManager.GetLayer(Layer), false);
            gameObject.SetActive(false);
        }
        OnLoad();
    }
    protected virtual void OnLoad()
    {
        
    }

    //打开并显示物体
    public void Show(object[] paramObjects)
    {
        gameObject.SetActive(true);        
        if (!isAttach)
        {
            isAttach = true;
            OnAttach(paramObjects);
        }
        OnShow(paramObjects);
    }
    protected virtual void OnShow(object[] paramObjects)
    {
        
    }
    protected virtual void OnAttach(object[] paramObjects)
    {

    }

    //隐藏物体
    public void Hide()
    {
        OnHide();
        isAttach = false;
        gameObject.SetActive(false);
    }
    protected virtual void OnHide()
    {
        
    }

    //固定更新
    public void FixedUpdate()
    {
        OnFixedUpdate();
    }

    protected virtual void OnFixedUpdate()
    {
        
    }

    //删除函数
    public void Destroy()
    {
        OnDestroy();
        Object.Destroy(gameObject);
        gameObject = null;
    }

    protected virtual void OnDestroy()
    {
        
    }

    //通过路径找到物体
    protected Transform Find(string path)
    {
        return transform.Find(path);
    }
    //通过路径找到物体并加载脚本
    protected T GetComponent<T>(string path)
    {
        return transform.Find(path).GetComponent<T>();
    }
    //物体直接获取脚本
    protected T GetComponent<T>()
    {
        return gameObject.GetComponent<T>();
    }
}