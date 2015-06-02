using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	private Vector3 startPosition = Vector3.zero;
	private float radius;
	private float angle;

	// Use this for initialization
	void Start () {
		angle  = Mathf.Atan2(Camera.main.transform.position.z, Camera.main.transform.position.x);
		radius = Vector2.Distance(Vector2.zero, new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.z));
	}

	void Update () {
		// Left Click
		if (Input.GetMouseButtonUp(0)) {
			startPosition = Input.mousePosition;
		} else if (Input.GetMouseButtonUp(0)) {
			angle  = Mathf.Atan2(Camera.main.transform.position.z, Camera.main.transform.position.x);
			radius = Vector2.Distance(Vector2.zero, new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.z));
		} else if (Input.GetMouseButton(0)) {
			Vector3 endPosition  = Input.mousePosition;
			float diff = 360f * (endPosition.x - startPosition.x) / Screen.width;
			SetCameraPosition (radius, angle + diff);
		}
	}

	void SetCameraPosition(float radius, float angle) {
		Vector3 original = Camera.main.transform.position;
		Camera.main.transform.position = new Vector3(radius * Mathf.Cos (angle), original.y, radius * Mathf.Sin (angle));
		Camera.main.transform.LookAt(this.gameObject.transform.position);
	}
}
