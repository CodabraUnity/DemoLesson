using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
