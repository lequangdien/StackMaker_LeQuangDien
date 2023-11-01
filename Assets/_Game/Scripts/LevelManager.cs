using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int id;
    void Start()
    {
        var prefabs = Resources.Load<GameObject>("Map_0");
       
        Instantiate(prefabs);
    }
}
