using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasteScript : MonoBehaviour
{
    Character player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Character>();

    }
    private void OnEnable()
    {
        CancelInvoke();
        if(player != null)
        player.SetSpeed(14);
        Invoke("Destroy", 12f);
    }

    void Destroy()
    {
        if (player != null)
            player.SetSpeed(10);
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        this.transform.rotation = player.transform.rotation;
    }
}
