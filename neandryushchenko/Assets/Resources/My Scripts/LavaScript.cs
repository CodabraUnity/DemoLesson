using UnityEngine;

public class LavaScript : MonoBehaviour
{
    private Vector3 playerStartPosition;
	
    private Transform player;

    private void Awake()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject)
            player = playerObject.transform;
    }

    private void Start()
    {
        if (player)
            playerStartPosition = player.position;

        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
            player.position = playerStartPosition;
    }
}