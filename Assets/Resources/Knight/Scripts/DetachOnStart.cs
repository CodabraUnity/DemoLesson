using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachOnStart : MonoBehaviour
{
    void Start()
    {
        transform.parent.localScale = new Vector3(1, 1, 1);
        gameObject.transform.parent = null;
    }
}