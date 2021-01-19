using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinForceShield : MonoBehaviour
{
    Character player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Character>();

    }
    private void OnEnable()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position;//new Vector3(player.transform.position.x ,player.transform.position.y ,player.transform.position.z );
        
    }


}
