using UnityEngine;
using System.Collections;

public class CameraControllerA : MonoBehaviour {

	public GameObject target;

	enum Buttons : int{
		LEFT = 0,
		RIGHT = 1,
		MIDDLE = 2

	};
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton((int)Buttons.LEFT)) Debug.Log("左クリック");

		expandTarget(Input.GetAxis("Mouse ScrollWheel"));

		rotateAroundTargetByYaxis(Input.GetAxis("Horizontal"));
		rotateAroundTargetByXaxis (Input.GetAxis("Vertical"));

		/**float dx = Input.GetAxis ("Horizontal");
		float dy = Input.GetAxis ("Vertical");
		Debug.Log (dx + " " + dy);

		transform.Translate (dx, dy, 0.0F);*/
	}

	//  execute camera expanding 
	void  expandTarget(float ratio)
	{
		// vector between camera and target object  
		Vector3 vec = this.transform.position - this.target.transform.position;
		
		//  calculate next distance between camera and target by ratio
		Vector3 vecNext = vec * (1.0f + ratio);

		if(vecNext.magnitude > 0.01f){
			this.transform.position = this.target.transform.position + vecNext;
		}

		return;
	}

	void rotateAroundTargetByYaxis(float ratio){
		this.transform.RotateAround (target.transform.position,Vector3.up,ratio);

	}

	void rotateAroundTargetByXaxis(float ratio){
		this.transform.RotateAround (target.transform.position, this.transform.right, ratio);
	}

}
