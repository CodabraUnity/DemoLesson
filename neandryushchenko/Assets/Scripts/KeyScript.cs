using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 2, 0);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<KnightController>().isKeyGotten = true;
            Destroy(gameObject);
        }
    }
}