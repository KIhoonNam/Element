using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTree : MonoBehaviour
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
        Invoke("Destroy", 1.5f);
    }

    void Destroy()
    {
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
        this.transform.rotation = player.transform.rotation;
    }
}
