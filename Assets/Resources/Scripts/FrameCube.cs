using UnityEngine;
using System.Collections;

public class FrameCube : MonoBehaviour {
	void Start () {
		int size = 100;
		ArrayList latticeList = new ArrayList();

		// create cube lattice point
		for (int z = -1; z <= 1; z++) {
			for (int y = -1; y <= 1; y++) {
				for (int x = -1; x <= 1; x++) {
					Vector3 point;
					point = new Vector3(x * size, y * size, z * size);
					if (z != 0 || y != 0 || x != 0) {
						latticeList.Add (point);
					}
					CreateCube (point, Color.red);

					point = new Vector3(x * size - size/2, y * size - size/2, z * size - size/2);
					CreateCube (point, Color.magenta);
					latticeList.Add(point);
				}
			}
		}

		// create point
		for (float z = -1.0f; z <= 1.0f; z+=0.05f) {
			for (float y = -1.0f; y <= 1.0f; y+=0.05f) {
				for (float x = -1.0f; x <= 1.0f; x+=0.05f) {
					Vector3 point;
					point = new Vector3(x * size, y * size, z * size);
					if (isNearestInGroup(point, Vector3.zero, latticeList)) {
						CreateSphere(point, Color.green);
					}
				}
			}
		}
	}

	private GameObject CreateCube(Vector3 position, Color color) {
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = position;
		cube.GetComponent<Renderer>().material.color = color;
		return cube;
	}

	private GameObject CreateSphere(Vector3 position, Color color) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = position;
		sphere.transform.localScale = new Vector3 (7.0f, 7.0f, 7.0f);
		sphere.GetComponent<Renderer>().material.color = color;
		return sphere;
	}

	private bool isNearestInGroup(Vector3 point, Vector3 base1, ArrayList otherGroup) {
		float d = distance (point, base1);
		foreach (Vector3 other in otherGroup) {
			float d1 = distance (point, other);
			if (d > d1) {
				return false;
			}
		}
		return true;
	}

	private float distance(Vector3 v1, Vector3 v2) {
		float dx = (v1.x - v2.x);
		float dy = (v1.y - v2.y);
		float dz = (v1.z - v2.z);
		return Mathf.Sqrt(dx*dx + dy*dy + dz*dz);
	}
}
