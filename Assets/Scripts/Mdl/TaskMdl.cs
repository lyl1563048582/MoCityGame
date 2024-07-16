using System;
using System.Collections.Generic;

[Serializable]
public class TaskMdl
{
	// �������
	public string TaskCode;

	// ��������
	public TaskType TaskType;

	// �������
	public string TaskTitle;

	// ����ͼƬ����
	public string TaskPicCode;

	// ��������
	public string TaskDescription;

	//  �ο���־����(��ǰ����ִ�е���һ��)
	public string RefFlagCode;

	// TODO:��һ���������
	public string PreTaskCode;

	// ���������������
	public List<string> NextTaskCode;

	// �����������
	public TaskCompleteCondition CompleteCondition;

	// Token: 0x040002B5 RID: 693
	public string RefCode;

	// ����
	public int RefNumber;

	// Token: 0x040002B7 RID: 695
	public string DestinationAreaCode;

	// Token: 0x040002B8 RID: 696
	public string DestinationPositionCode;

	// Token: 0x040002B9 RID: 697
	public List<AwardMdl> CompleteAwards;
}
