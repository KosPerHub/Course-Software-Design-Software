using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int[] UnlockedLevel = new int[3]; // массив целочисленных переменных, показывает какие уровни открыты
    public int GamesLevel; // игровой уровень, который игрок выбрал на "карте"

    void Start()
    {
        DontDestroyOnLoad(gameObject); //делаем так, чтобы обьект не удалялся, при переходе на другую сцену 
    }
}
