using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // получаем компаненты интерфейса и менеджера сцен
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public GameManager GameManager;

    private void Start()
    {
        GameManager = FindAnyObjectByType<GameManager>(); // находим главный скрипт GameMAnager

        SceneManager.LoadScene("Lobby");
    }
}
