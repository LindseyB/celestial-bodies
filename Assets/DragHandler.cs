using UnityEngine;
using System.Collections;

public class DragHandler : MonoBehaviour {
    private LineRenderer lr;

	void Start () {
        lr = gameObject.GetComponent<LineRenderer>();
	
	}
	
	void Update () {
	
	}

    void OnMouseDrag () {
        Vector3 endLinePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        endLinePosition.z = 1;
        Vector3 startLinePosition = gameObject.GetComponent<Transform>().position;
        startLinePosition.z = 1;
        lr.SetPosition(0, startLinePosition);
        lr.SetPosition(1, endLinePosition);
    }

    void OnMouseUp () {
        lr.SetPosition(0, Vector3.zero);
        lr.SetPosition(1, Vector3.zero);
    }
}
