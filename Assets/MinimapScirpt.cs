using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScirpt : MonoBehaviour
{
    // Start is called before the first frame update
    Character player;
    void Start()
    {
        player = FindObjectOfType<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }
}
