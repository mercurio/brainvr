using UnityEngine;
using System.Collections;

public class HeadSizeManager : MonoBehaviour {
	public float headSizeScale = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/* not really interesting 
		float hs = Input.GetAxis ("HeadSize");

		Vector3 sv = Vector3.one * hs * headSizeScale;
		transform.localScale += sv;
		*/
	}
}
