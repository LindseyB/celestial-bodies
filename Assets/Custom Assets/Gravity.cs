using UnityEngine;
using System.Collections.Generic;

public class Gravity : MonoBehaviour
{
	public float range = 10f;
	
	Rigidbody ownRb;
	
	void Start()
	{
		ownRb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate()
	{
		Collider[] cols = Physics.OverlapSphere(transform.position, range);
		List<Rigidbody> rbs = new List<Rigidbody>();
		
		foreach (Collider c in cols)
		{
			Rigidbody rb = c.attachedRigidbody;
			if (rb != null && rb != ownRb && !rbs.Contains(rb))
			{
				rbs.Add(rb);
				Vector3 offset = transform.position - c.transform.position;
				rb.AddForce(offset / offset.sqrMagnitude * ownRb.mass);
			}
		}
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}