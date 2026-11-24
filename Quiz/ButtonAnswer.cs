using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonAnswer : MonoBehaviour
{
    public QuizManager QuizManager; // Обьявляем доступ к главному скрипту сцены
    public Text TextButton; // текст на кнопке

    private Image _buttonImage; // кэшируем компонент Image, чтобы не вызывать GetComponent каждый раз

    void Start()
    {
        QuizManager = FindAnyObjectByType<QuizManager>(); // получаем скрипт
        _buttonImage = gameObject.GetComponent<Image>();   // кэшируем Image
    }

    public void InpunButton() // метод нажатия на кнопку 
    {
        if (QuizManager.CanAnswer == false) return; // блокируем нажатия, пока идет задержка перед новым вопросом
        if (QuizManager.NumberQuestion >= 10) return; // блокируем нажатия после окончания квиза

        QuizManager.CanAnswer = false; // блокируем кнопки до восстановления в NextAnswer

        if (TextButton.text == QuizManager.StringTruAnswer) // делаем проверку, совпадает ли текст на кнопке с текстом правильного ответа 
        {
            // если да, то добавляем балл в баллы ))
            QuizManager.Score++;
            _buttonImage.color = Color.green; // меняем цвет кнопки на зеленый, для визуального обозначения
        }
        else // если ответ неверны, меняем цвет кнопки на красный 
        {
            _buttonImage.color = Color.red;
        }

        QuizManager.NumberQuestion++; // добавляем балл к общему числу заданных вопросов (их десять)

        Invoke("NextAnswer", 0.7f); // через 0,7f вызываем метод "NextAnswer"
    }

    private void NextAnswer()
    {
        QuizManager.InputButton = true; // переменная которая показывает нажимали ли мы на кнопку ответа
        _buttonImage.color = new Color(255f, 255f, 255f, 1f); // меняем цвет кнопки на стандартный 

        if (QuizManager.NumberQuestion < 10) // разблокируем кнопки только если квиз еще не закончен
        {
            QuizManager.CanAnswer = true;
        }
        //( так же этот метод позваляет учеловеку точно определить, верно он ответил или нет, за счет цвета. Без этого метода новый вопрос задался сразу бы)
    }
}