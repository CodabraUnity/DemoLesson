using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachAtStart : MonoBehaviour {

	void Start()
	{
		gameObject.transform.parent = null;
	}
}
