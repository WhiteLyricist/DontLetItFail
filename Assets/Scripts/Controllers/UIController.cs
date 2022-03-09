using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{

    private float _gameTime;
    private float _second = 0;
    private float _bestScore;

    [SerializeField]
    private TMP_Text _timer;
    [SerializeField]
    private TMP_Text _score;



    private void Start()
    {
        MoveBall.EndGame += OnEndGame;
       _bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
    }

    private void OnEndGame()
    {
        _timer.gameObject.SetActive(false);
        _score.gameObject.SetActive(true);

        _score.enabled = true;

        if (_second > _bestScore)
        {
            _score.text = "Поздравляю вы установили новый рекорд! Ваш рекорд: " + $"{_second}";

            _bestScore = _second;

            PlayerPrefs.SetFloat("BestScore", _bestScore);
            PlayerPrefs.Save();
        }
        else 
        {
            _score.text = "Игра закончена, Ваш счёт: " + $"{_second}";
        }
    }

    void Update()
    {
        _timer.text = $"{_second}";

        _gameTime += 1 * Time.deltaTime;
        if (_gameTime >= 1)
        {
            _second += 1;
            _gameTime = 0;
        }
    }

    private void OnDestroy()
    {
        MoveBall.EndGame -= OnEndGame;
    }
}
