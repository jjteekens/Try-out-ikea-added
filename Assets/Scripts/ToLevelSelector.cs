using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevelSelector : MonoBehaviour
{
    public void OpenScene()
    {
        SceneManager.LoadScene("Level selector");
    }

    
}
