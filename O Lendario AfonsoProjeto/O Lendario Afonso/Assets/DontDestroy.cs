using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mantém um Gerenciador vivo durante a troca de cenas.
public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SMG");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
