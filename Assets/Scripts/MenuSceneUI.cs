using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuSceneUI : MonoBehaviour
{
    public static string nameInput {get; private set;}
    public TMP_InputField nameInputField;
    [SerializeField] TextMeshProUGUI bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        setNameInputFieldText();
        ScoreManager.BestScore bestScore = ScoreManager.Instance.LoadScore();
        if (bestScore.name != " ")
        {
            bestScoreText.text = $"Best Score : {bestScore.name} : {bestScore.score}";
        } else
        {
            bestScoreText.text = "Best Score";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setNameInputFieldText()
    {
        ScoreManager.BestScore bestScore = ScoreManager.Instance.LoadScore();
        nameInputField.text = bestScore.name != " " ? bestScore.name : "Enter name...";
    }

    public void ReadNameInputField(string s)
    {
        nameInput = s;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
}
