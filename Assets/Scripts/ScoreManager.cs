using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    private string json_file;
    public static ScoreManager Instance; //{get; private set;}
    // Start is called before the first frame update
    void Awake()
    {
        json_file = Application.persistentDataPath + "/save_data.json";

        // if (Instance != null)
        // {
        //     Destroy(gameObject);
        //     return;
        // }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public class BestScore
    {
        public int score = 0;
        public string name = " ";
        public int order = 1;
    }

    public void SaveScore(int score)
    {
        BestScore data = new BestScore();
        data.name = MenuSceneUI.nameInput;
        data.score = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(json_file, json);

    }

    public BestScore LoadScore()
    {
        if (File.Exists(json_file))
        {

            string json = File.ReadAllText(json_file);
            BestScore data = JsonUtility.FromJson<BestScore>(json);
            return data;
        }
        else
        {
            return new BestScore();
        }


    }

    public void UpdateText(int currentScore, TextMeshProUGUI textUI)                                       
    {
        BestScore bestScore = LoadScore();
        if (currentScore > bestScore.score)
        {
            SaveScore(currentScore);
        }
        textUI.text = $"Best Score : {bestScore.name} : {bestScore.score}";
    }
}
