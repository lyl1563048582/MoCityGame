using System;
using System.Collections.Generic;

[Serializable]
public class TaskMdl
{
	// 任务代码
	public string TaskCode;

	// 任务类型
	public TaskType TaskType;

	// 任务标题
	public string TaskTitle;

	// 任务图片代码
	public string TaskPicCode;

	// 任务描述
	public string TaskDescription;

	//  参考标志代码(当前任务执行到哪一步)
	public string RefFlagCode;

	// TODO:上一个任务代码
	public string PreTaskCode;

	// 接下来的任务代码
	public List<string> NextTaskCode;

	// 任务完成条件
	public TaskCompleteCondition CompleteCondition;

	// Token: 0x040002B5 RID: 693
	public string RefCode;

	// 数量
	public int RefNumber;

	// Token: 0x040002B7 RID: 695
	public string DestinationAreaCode;

	// Token: 0x040002B8 RID: 696
	public string DestinationPositionCode;

	// Token: 0x040002B9 RID: 697
	public List<AwardMdl> CompleteAwards;
}
