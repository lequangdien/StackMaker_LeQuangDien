using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnBrick : MonoBehaviour
{
    public bool isCollect=false;
    [SerializeField]public GameObject brickPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstranName.Player_Name) && !isCollect  && other.GetComponent<Player>().playerBricks.Count !=0)
        {
            brickPrefab.SetActive(true);
            isCollect = true;
            other.GetComponent<Player>().RemoveBrick();
        }
    }
}
