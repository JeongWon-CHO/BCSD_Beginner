using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestructObject : MonoBehaviour
{
    private static DontDestructObject s_Instance = null;

    private void Awake()
    {
        if (s_Instance)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        s_Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
