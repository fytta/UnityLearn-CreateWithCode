using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject startMenu;
    public GameObject gameOverMenu;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreValueText;
    public TextMeshProUGUI finalScoreText;
    public List<GameObject> targets;
    public bool isGameActive = false;
    public int lives = 3;
    public int difficult = 1;
    private float _spawnRate = 1.0f;
    private int _score = 0;

    void Start() {}

    public void StartGame(int difficult)
    {
        lives = 3;
        isGameActive = true;
        EnableStartMenu(false);
        SetDifficult(difficult);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        scoreText.gameObject.SetActive(true);
        scoreValueText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        EnableStartMenu(true);
        EnableGameOverMenu(false);
        _score = 0;
        lives = 3;
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = UnityEngine.Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        if (_score < 0) _score = 0;
        scoreValueText.text = _score.ToString();
    }

    public void GameOver()
    {
        isGameActive = false;
        scoreText.gameObject.SetActive(false);
        scoreValueText.gameObject.SetActive(false);
        EnableGameOverMenu(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void EnableGameOverMenu(bool enable)
    {
        finalScoreText.text = "Score " + _score.ToString();
        gameOverMenu.SetActive(enable);
    }

    private void EnableStartMenu(bool enable)
    {
        startMenu.SetActive(enable);
    }

    private void SetDifficult(int diff)
    {
        difficult = diff;
        _spawnRate = 1;
        _spawnRate /= (float)difficult;
    }
}
