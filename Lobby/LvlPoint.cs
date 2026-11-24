using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LvlPoint : MonoBehaviour
{
    public GameManager GameManager;

    public int NumberPoint;
    public GameObject Lock;

    private void Start()
    {
        GameManager = FindAnyObjectByType<GameManager>();

        if (GameManager.UnlockedLevel[NumberPoint] == 1)
        {
            Lock.SetActive(false);
        }
        else
        {
            Lock.SetActive(true);
        }
    }

    public void PressButton()
    {
        Debug.Log(NumberPoint + "");

        if (GameManager.UnlockedLevel[NumberPoint] == 1) // делаем проверку, елси уровень открыт, то переходим на него
        {
            GameManager.GamesLevel = NumberPoint;
            SceneManager.LoadScene("Quiz");
        }
    }
}
