using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuSceneUI : MonoBehaviour
{
    public static string nameInput;
    public TMP_InputField nameInputField;
    // Start is called before the first frame update
    void Start()
    {
        setNameInputFieldText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setNameInputFieldText()
    {

        // ScoreManager.BestScore bestScore = scoreManager.LoadScore();
        // nameInputField.text = bestScore.name;
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
