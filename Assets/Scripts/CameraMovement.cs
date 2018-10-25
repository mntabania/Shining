using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField] private Transform lookAtTarget;
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(lookAtTarget);
        transform.Translate(Vector3.right * Time.deltaTime);
    }
}
