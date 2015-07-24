using UnityEngine;

public enum NavMode {xyz, fly, orbit};

public class CameraMovement : MonoBehaviour {

	private float orbitSpeed = 3.0f;
	private float flySpeed = 0.08f;
	private float xyzSpeed = 0.1f;
	private NavMode navMode = NavMode.fly;

	// Use this for initialization
	void Start()
	{
	}	

	void Update() {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		float a = Input.GetAxis ("Altitude");
			
		Vector3 movement = new Vector3 (h, a, v);
		if(movement == Vector3.zero) return;

		switch(navMode) {
			case NavMode.xyz:
				transform.Translate (movement * xyzSpeed);
				break;

			case NavMode.fly:
				movement = Camera.main.transform.TransformDirection(movement);				
				movement *= flySpeed;
				transform.Translate (movement);
				break;

			case NavMode.orbit: // not implemented yet
				break;
		}
	}

}
