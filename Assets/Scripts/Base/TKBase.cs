using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TKBase : MonoBehaviour
{
	protected void LogDebug(object msgObj)
	{
		if (GameConfiguration.Instance.IsOpenDebug)
		{
			MonoBehaviour.print(msgObj.ToString());
		}
	}


	protected void LogError(object msgObj)
	{
		if (GameConfiguration.Instance.IsOpenDebug)
		{
			Debug.LogError(msgObj.ToString());
		}
	}


}
