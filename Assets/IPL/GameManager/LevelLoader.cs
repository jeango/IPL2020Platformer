using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using IPL;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public void Load(string levelName)
    {
        GameManager.Instance.LoadScene(levelName);
    }
}
