using UnityEngine;
using System.Collections;

/*
 * Cycle through different configurations of what is 
 * visible, based on the Cycle button.
 */
public class CycleVisibility : MonoBehaviour {
	private int mode = 0;
	private int modes = 3;

	private GameObject lHemi = null;
	private GameObject rHemi = null;

	void Start () {
		lHemi = GameObject.Find ("/Brain/cortex_left");
		rHemi = GameObject.Find ("/Brain/cortex_right");
		setVisibility(0);
	}
	
	void Update () {
		if(Input.GetButtonDown ("Cycle")) {
			mode = (mode+1) % modes;
			setVisibility(mode);
		}
	}

	/*
	 * Set what's visibile given the mode.
	 * We currently cycle through:
	 * 
	 * 0	left hemisphere visible
	 * 1	both hemispheres visible
	 * 2	no hemispheres visible
	 */
	private void setVisibility(int m) {
		switch(m) {
			case 0:
				lHemi.SetActive(true);
				rHemi.SetActive(false);
				break;
				
			case 1:
				lHemi.SetActive(true);
				rHemi.SetActive(true);
				break;
				
			case 2:
				lHemi.SetActive(false);
				rHemi.SetActive(false);
				break;
		}
	}
}
