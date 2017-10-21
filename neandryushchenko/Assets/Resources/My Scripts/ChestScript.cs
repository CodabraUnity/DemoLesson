using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]

public class ChestScript : MonoBehaviour {

    private GameObject player;

    private Animator anim;

    private KnightController knightController;

    private bool isWin = false;

    [Space]
    public string winText = "You Win!";

    private void Start()
    {
        anim = transform.Find("Treasure_Chest_Up").GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");

        knightController = player.GetComponent<KnightController>();

    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Col");
        if (col.CompareTag("Player") && knightController.isKeyGotten)
        {
            isWin = true;
            anim.SetBool("Open", true);
        }
    }

    private void OnGUI()
    {

        GUIStyle style = new GUIStyle
        {
            fontSize = 24,
            alignment = TextAnchor.UpperCenter,
            font = (Font)Resources.Load("Fonts/Badaboom")
        };
        style.fontSize = 100;
        style.normal.textColor = Color.white;

        if (isWin)
            GUI.Label(new Rect(
                (Screen.width) / 2 - (Screen.width) / 8,
                (Screen.height) / 6, (Screen.width) / 4,
                (Screen.height) / 4), 
                winText, 
                style);
    }
}