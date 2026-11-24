using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string Text;                              // текст вопроса
    public string[] WrongAnswers = new string[4];    // четыре неверных ответа (по одному на каждую кнопку, один из них заменится на правильный в QuizManager.Question)
    public string CorrectAnswer;                     // правильный ответ
}