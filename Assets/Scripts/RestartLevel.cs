﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}