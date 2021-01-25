using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieMenu : MonoBehaviour
{
    [SerializeField] private GameObject _dieMenu;

    public void Show()
    {
        _dieMenu.SetActive(true);
        Time.timeScale = 0f;

    }

    public void PlayButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    }
