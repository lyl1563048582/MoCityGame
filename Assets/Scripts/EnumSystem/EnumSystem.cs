
/// <summary>
/// �˺�Ч��
/// </summary>
public enum DamageEffect
{
	// ��ͨ (С����)
	NORMAL,
	// ������������ȣ�
	HIT,
	// ������
	HIT_FLY,
	// ΢����
	//FAINT,
	// ɱ��
	KILL
}

/// <summary>
/// ��Ϸ�ڵĸ������� ��Ϸ��
/// </summary>
public enum GameSide
{
	// ���
	PLAYER,
	// ����
	ENEMY,
	// ����
	NETURAL,
	// ����
	FRIEND
}

/// <summary>
/// �����������
/// </summary>
public enum TaskCompleteCondition
{
	// �ύһ���ֲ���
	GIVE,
	// ��ȡ����
	GET,
	// ֱ�����
	NORMAL,
	// �����Ի�
	TALK,
	// ����
	ARRIVE,
	// ��ɱ
	KILL,
	// ��Կ
	KEYFLAG,
	// ����ʽ�Ի�
	INTERACTIVE,
	//ʱ��
	TIME
}

// ��������
public enum TaskType
{
	// ��Կ
	KEY,
	// ��ͨ
	NORMAL,
	//�
	ACTIVE
}


