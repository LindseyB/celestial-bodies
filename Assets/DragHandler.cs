using UnityEngine;
using System.Collections;

public class DragHandler : MonoBehaviour {
    private LineRenderer lr;
    private Rigidbody2D rb;
    private Vector2 force;
    private int mult = -100;

	void Start () {
        lr = gameObject.GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
	
	}

    void OnMouseDrag () {
        Vector3 endLinePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        endLinePosition.z = 1;

        Vector3 startLinePosition = gameObject.GetComponent<Transform>().position;
        startLinePosition.z = 1;

        force = new Vector2(endLinePosition.x - startLinePosition.x, endLinePosition.y - startLinePosition.y);
        force *= (Vector3.Distance(startLinePosition, endLinePosition) * mult * rb.mass);

        lr.SetPosition(0, startLinePosition);
        lr.SetPosition(1, endLinePosition);
    }

    void OnMouseUp () {
        lr.SetPosition(0, Vector3.zero);
        lr.SetPosition(1, Vector3.zero);
        rb.isKinematic = false;

        Debug.Log(force);

        rb.AddForce(force);
    }
}
