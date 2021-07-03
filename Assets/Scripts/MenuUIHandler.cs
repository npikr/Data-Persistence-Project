using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public Text playerName;
    public Text highScoreText;


    public void Start()
    {
        highScoreText.text = "Best Score : " + GameManager.Instance.highesScoreName + " : " + GameManager.Instance.highestPlayerPoints;
    }

    // Start is called before the first frame update
    public void StartNew()
    {
        GameManager.Instance.currentName = playerName.text;
        //GameManager.Instance.highestPlayerPoints = 0;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        //GameManager.Instance.SaveNameAndScore();

        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
                Application.Quit(); // original code to quit Unity player
        #endif

    }


}
