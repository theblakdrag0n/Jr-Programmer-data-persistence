using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public Text BestScoreLabel;
    public InputField txtUsername;
    public GameManager gameManager;

    void Start()
    {
        BestScoreLabel.text = $"Best Score : {GameManager.Instance.bestName} : {GameManager.Instance.bestScore}";
    }

    public void StartGame()
    {
        GameManager.Instance.username = txtUsername.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
#if UNITY_STANDALONE_WIN
        Application.Quit();
#endif
    }
}
