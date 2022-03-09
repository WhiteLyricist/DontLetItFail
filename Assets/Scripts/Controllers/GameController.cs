using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private void Start()
    {
        MoveBall.EndGame += OnEndGame;
    }
    public void Pause()
    {
        Time.timeScale = (Time.timeScale > 0) ? 0 : 1;
    }

    private void OnEndGame() 
    {
        StartCoroutine(EndGame());
    }

    private void OnDestroy()
    {
        MoveBall.EndGame -= OnEndGame;
    }

    private IEnumerator EndGame() 
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Menu");
    }
}
