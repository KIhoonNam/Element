using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    Transform Tr;
    Character Player;
   
    private void Start()
    {
        Tr = GetComponent<Transform>();
        Player = FindObjectOfType<Character>();

       
    }

    private void Update()
    {

        Tr.position = new Vector3(Player.transform.position.x, Tr.position.y, Player.transform.position.z -4);

   
    }
}
