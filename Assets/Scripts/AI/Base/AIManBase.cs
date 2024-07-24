using UnityEngine;

public class AIManBase : AIBase
{
    protected Transform path { get { return MapManager.Inst.path; } }

    /// <summary>
    /// 攻击力
    /// </summary>
    public float AtkNum { get { return atk; } }
    protected float atk = 0;

    /// <summary>
    /// 攻击距离
    /// </summary>
    public float AtkRange { get { return atkRange; } }
    protected float atkRange = 0;

    /// <summary>
    /// 最终攻击间隔（刷新使用)
    /// </summary>
    public float FinalAtkInterval { get { return atkSpd; } }//PublicFunction.Get_AtkInterval_OnAtkspdUp(atkSpd, (1 + BattleProp.Inst.zombieAtkSp)); } }//
    protected float atkSpd = 0;
    protected float maxAtkSpd = 0;

    /// <summary>
    /// 攻击计时
    /// </summary>
    protected float atkTimer = 0;

    /// <summary>
    /// 移动速度
    /// </summary>
    public float Speed { get { return speed; } }
    protected float speed = 0;

    /// <summary>
    /// 生命值上限
    /// </summary>
    public float HPMax { get { return hpMax; } }
    protected float hpMax = 0;
    protected float hpMaxFx = 0f;//优化乘法

    /// <summary>
    /// 当前生命值
    /// </summary>
    public float Hp { get { return hp; } }
    protected float hp = 0;

    /// <summary>
    /// 移动AI
    /// </summary>
  //  protected MoveAI moveAI;
   // public virtual void ControlMoveAI(bool _isOpen) { if (moveAI != null) { moveAI.enabled = _isOpen; } }

    /// <summary>
    /// 血量条
    /// </summary>
    protected Transform vertexUI;

    /// <summary>
    /// 体积单位半径
    /// </summary>
    public float volume = 0.5f;

    /// <summary>
    /// 监测设施队列
    /// </summary>
 //   protected List<AIInstrument> instrumentList = new List<AIInstrument>();

    //辅助变量
    protected float assistNum = 0;

    //辅助坐标
    protected Vector3 assistVe3;

    protected override void OnBorn()
    {
        base.OnBorn();
      // BindingColTools(Tran);
      //  moveAI = Tran.gameObject.AddComponent<MoveAI>();
      //  moveAI.moveSpeed = Speed;
        if (vertexUI != null) vertexUI.gameObject.SetActive(false);
    }

}
