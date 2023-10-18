
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private bool isCollect=false;
    [SerializeField] GameObject brickPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstranName.Player_Name) && !isCollect )
        {
           brickPrefab.SetActive(false);
            isCollect = true;
            other.GetComponent<Player>().AddBrick();
        }

    }
    // [SerializeField] public ColorBrick color;
}
