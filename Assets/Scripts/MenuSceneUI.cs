using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneUI : MonoBehaviour
{
    public string nameInput;
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
}
