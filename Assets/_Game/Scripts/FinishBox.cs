using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinishBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstranName.Player_Name))
        {
            VitoryGame();
        }
    }
    public void VitoryGame()
    {
        Debug.Log("VICTORY");
    }
}
