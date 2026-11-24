using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // обязательно получаем компанент для перемещения по сценам
using UnityEngine;

public class MowementScene : MonoBehaviour
{
    public void SceneLobby() // метод для переноса на сцену лобби (скрипт нужно прикрепить к обьекту на сцене)
    {
        SceneManager.LoadScene("lobby");
    }
    public void SceneQuiz() // метод для переноса на сцену квиз (скрипт нужно прикрепить к обьекту на сцене)
    {
        SceneManager.LoadScene("Quiz");
    }
}
