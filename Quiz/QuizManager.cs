using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public GameManager GameManager;
    public LoadingText LoadingText;

    public int Score; // переменная балло, показывает сколько верных ответов мы сделали
    public int NumberQuestion; // переменная отвечающая, сколько вопросов уже было заданно 

    public string NameQuiz; // название квиза
    public string StringTruAnswer; // переменная, в которую мы задаем верный ответ на вопрос
    public bool InputButton; // переменная отвечает, нажали мы на ктопку или нет
    public bool CanAnswer = true; // блокирует нажатия кнопок, пока идет задержка перед новым вопросом

    public Text QuestionsText; // текст, на который мы выводим вопрос
    public Text[] TextButtom = new Text[4]; // текст, который висит на кнопках ответов
    public Text TheEndText; // текст указывающий выйграли мы или нет
    public Text ScoreText; // текст указывающий сколько баллов мы набрали

    public GameObject GameImage; // сама картинка, которая у нас висит на сцене
    public Sprite[] QuizSpriteFairyTales = new Sprite[10]; // спрайты возможных картинок
    public Sprite[] QuizSpriteCountries = new Sprite[10];
    public Sprite[] QuizSpriteHistory = new Sprite[10];

    public GameObject TheEndWindow; // обьект - появляется когда заданно десять вопросов (всплывающая окошко)

    private bool _quizEnded = false; // флаг, чтобы окно конца и тексты обновлялись только один раз

    void Start()
    {
        GameManager = FindAnyObjectByType<GameManager>();
        LoadingText = gameObject.GetComponent<LoadingText>();
        LoadingText.QuizManager = this; // прокидываем ссылку, чтобы LoadingText мог использовать NameQuiz

        TheEndWindow.SetActive(false); // скрываем окно конца квиза на старте

        switch (GameManager.GamesLevel) // при нажатии на карту игрок задавал значение переменой "GamesLevel" исходя из этого задаем название (уточняем какой уровень выбрал игрок)
        {
            case 0:
                NameQuiz = "Fairytales";
                break;
            case 1:
                NameQuiz = "Countries";
                break;
            case 2:
                NameQuiz = "History";
                break;
        }

        LoadingText.LoadQuestions(); // синхронно загружаем вопросы и ответы
        Question(); // вызываем метод "задачи впроса"
    }

    private void Update()
    {
        if (InputButton == true) // если игрок нажал на кнопку ответа, вызываем новый вопрос, и отключаем перемунную нажатия
        {
            InputButton = false;
            Question();
        }

        if (NumberQuestion >= 10 && _quizEnded == false) // если игрок ответил на десять вопросов 
        {
            _quizEnded = true;
            CanAnswer = false; // на всякий случай блокируем кнопки до конца сцены
            TheEndWindow.SetActive(true); // вкл овно конца квиза

            if (Score >= 8) // проверяем сколько очков игрок набрал за квиз 
            {
                switch (GameManager.GamesLevel) // если игрок набрал >= 8 верных ответов, то открываем следующий уровень в списке
                {
                    case 0:
                        GameManager.UnlockedLevel[1] = 1;
                        break;
                    case 1:
                        GameManager.UnlockedLevel[2] = 1;
                        break;
                }
                TheEndText.text = "Ты выйграл !"; // задаем текст переменной
            }
            else // если игрок набрал меньше верных ответов, меняем тект на новый 
            {
                TheEndText.text = "Ты проиграл (";
            }

            ScoreText.text = "Набрав " + Score + " из 10 очков"; // пишем в текте, сколько игрок набрал верных ответов
        }
    }

    public void Question() // метод выдачи вопроса
    {
        if (NumberQuestion < 10) // если игрок еще не ответил на десять вопросов 
        {
            int IntRandomQuestion = Random.Range(0, LoadingText.AllQuestions.Count); // задаем локальную перемнную int для рандомного выбора вопроса из списка
            Question RandomQuestion = LoadingText.AllQuestions[IntRandomQuestion]; // достаем вопрос, который рандомно выпал из списка
            QuestionsText.text = RandomQuestion.Text; // пишем текст вопроса, который выпал 

            TextButtom[0].text = RandomQuestion.WrongAnswers[0]; // задаем кнопкам возможные варианты ответа
            TextButtom[1].text = RandomQuestion.WrongAnswers[1];
            TextButtom[2].text = RandomQuestion.WrongAnswers[2];
            TextButtom[3].text = RandomQuestion.WrongAnswers[3];

            StringTruAnswer = RandomQuestion.CorrectAnswer; // записываем верный ответ
            int RandomAnswer = Random.Range(0, TextButtom.Length); // задаем вторую локальную int переменную, чтобы определить, какую кнопку с возможным ответом мы заменим на верный 
            TextButtom[RandomAnswer].text = StringTruAnswer; // заменяем возможный текст кнопки на верный ответ 

            LoadingText.AllQuestions.RemoveAt(IntRandomQuestion); // сразу убираем вопрос из списка (чтобы он не мог повториться)

            QuizSprite(); // вызываем метод смены картинки на новую
        }
    }

    private void QuizSprite() // метод замены картинки на новую 
    {
        switch (GameManager.GamesLevel) // проверяем какой сейчас уровень, чтобы картинка совпадала ему
        {
            case 0:
                GameImage.GetComponent<Image>().sprite = QuizSpriteFairyTales[Random.Range(0, QuizSpriteFairyTales.Length)]; // заменяем картинку 
                break;
            case 1:
                GameImage.GetComponent<Image>().sprite = QuizSpriteCountries[Random.Range(0, QuizSpriteCountries.Length)];
                break;
            case 2:
                GameImage.GetComponent<Image>().sprite = QuizSpriteHistory[Random.Range(0, QuizSpriteHistory.Length)];
                break;
        }
    }
}