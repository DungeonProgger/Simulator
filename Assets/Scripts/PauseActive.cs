using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseActive : MonoBehaviour
{
    [SerializeField] private GameObject PauseScreen;
    void Start()
    {
        PauseScreen.SetActive(false);
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Main")
        //{
        //    PauseScreen.SetActive(true);
        //}
    }
}
