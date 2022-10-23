using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int level;
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = level.ToString();
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }
}
