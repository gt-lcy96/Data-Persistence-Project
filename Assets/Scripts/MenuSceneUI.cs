using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneUI : MonoBehaviour
{
    public static string nameInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadNameInputField(string s)
    {
        nameInput = s;
        Debug.Log(nameInput);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
}
