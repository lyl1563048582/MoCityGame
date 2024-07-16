using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : TKBase
{
	
	private void OnEnable()
	{
		this.Damaged = false;
	}

	
	private void Start()
	{
		this.Damaged = false;
	}


	
	public DamageEffect DamageEffect;

	
	public float DamagePoint;

	
	public int DamageLevel;

	
	public GameSide DamageSide;

	
	public bool Damaged = false;

	
	public Vector3 LastHitPoint;
}
