using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameuse : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene("GameStart Lobby");
    }
}
