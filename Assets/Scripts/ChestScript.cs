using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Codabra.Demo;

public class ChestScript : MonoBehaviour
{
    private bool _isOpened = false;
    private GUIStyle _g = new GUIStyle();
    private Vector3 _endRotation = new Vector3(60, 0, 0);
    private float _time = 0f;

    void Start()
    {
        var user = GetComponent<Codabra.Demo.EquipUser>();
        if (user != null) user.Activation.AddListener(() => { _isOpened = true; });
        _g.fontSize = 24;
    }

    void Update()
    {
        if (_isOpened && _time <= 1f)
        {
            _time += Time.deltaTime;
            GameObject.FindWithTag("Up").transform.localEulerAngles = Vector3.Lerp(Vector3.zero, _endRotation, _time);
        }
    }

    void OnGUI()
    {
        if (_isOpened)
            GUI.Label(new Rect(100, 100, Screen.width, Screen.height), "YOU WIN!", _g);
    }
}
