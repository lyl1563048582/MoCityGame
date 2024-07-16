
/// <summary>
/// 伤害效果
/// </summary>
public enum DamageEffect
{
	// 普通 (小幅度)
	NORMAL,
	// 被攻击（大幅度）
	HIT,
	// 被击飞
	HIT_FLY,
	// 微弱的
	//FAINT,
	// 杀死
	KILL
}

/// <summary>
/// 游戏内的各种阵容 游戏方
/// </summary>
public enum GameSide
{
	// 玩家
	PLAYER,
	// 敌人
	ENEMY,
	// 中立
	NETURAL,
	// 朋友
	FRIEND
}

/// <summary>
/// 任务完成条件
/// </summary>
public enum TaskCompleteCondition
{
	// 提交一部分材料
	GIVE,
	// 获取材料
	GET,
	// 直接完成
	NORMAL,
	// 正常对话
	TALK,
	// 到达
	ARRIVE,
	// 击杀
	KILL,
	// 秘钥
	KEYFLAG,
	// 交互式对话
	INTERACTIVE,
	//时间
	TIME
}

// 任务类型
public enum TaskType
{
	// 秘钥
	KEY,
	// 普通
	NORMAL,
	//活动
	ACTIVE
}


