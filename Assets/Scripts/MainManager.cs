using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text BestScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;
    private BestScore bestScore;
    private string json_file;

    
    // Start is called before the first frame update
    void Start()
    {
        json_file = Application.persistentDataPath + "/save_data.json";
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }


        UpdateBestScoreText();
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
    }

    public void UpdateBestScoreText()
    {
        BestScore bestScore = LoadScore();
        if(m_Points > bestScore.score)
        {
            SaveScore();
        }
        BestScoreText.text = $"Best Score : {bestScore.name} : {bestScore.score}";
    }

    [System.Serializable]
    public class BestScore
    {
        public int score = 0;
        public string name = " ";
        public int order = 1;
    }

    public void SaveScore()
    {
        BestScore data = new BestScore();
        data.name = MenuSceneUI.nameInput;
        data.score = m_Points;
        
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(json_file , json);

    }

    public BestScore LoadScore()
    {
        
        if(File.Exists(json_file)) 
        {
            string json = File.ReadAllText(json_file);
            BestScore data = JsonUtility.FromJson<BestScore>(json);
            return data;
        } else {
            return new BestScore();
        }


    }
}
