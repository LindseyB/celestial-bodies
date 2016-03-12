using UnityEngine;
using System.Collections;

public class initialVelocity : MonoBehaviour {
	public Rigidbody2D rb;
	public Vector2 force;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		force = new Vector2(-500, 0);
		rb.AddForce(force);

	}
	
	// Update is called once per frame
	void Update () {
		//rb.AddForce(force);
	}
}
