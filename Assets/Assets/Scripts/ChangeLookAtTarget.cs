using UnityEngine;
using System.Collections;

public class ChangeLookAtTarget : MonoBehaviour {

	public GameObject target; // the target that the camera should look at

	void Start() {
		if (target == null) 
		{
			target = this.gameObject;
			Debug.Log ("ChangeLookAtTarget target not specified. Defaulting to parent GameObject");
		}
	}

	// Called when MouseDown on this gameObject
	void OnMouseDown () {
		// change the target of the LookAtTarget script to be this gameobject.
		AudioSource audio_source;
		if (LookAtTarget.target != null) {
			audio_source = LookAtTarget.target.GetComponent<AudioSource> ();
			if (audio_source != null && audio_source.isPlaying) {
				Debug.Log ("Stoping " + LookAtTarget.target.name);
				audio_source.Stop ();
			}
		}

		LookAtTarget.target = target;
//		Camera.main.fieldOfView = 60*target.transform.localScale.x;
		audio_source = target.GetComponent<AudioSource>();	
		if (audio_source != null && !audio_source.isPlaying) {
			audio_source.Play ();
			Debug.Log ("Playing " + target.name);
		}
	}
}
