using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFog : MonoBehaviour
{
    GameObject[] Mn;
    Character player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Character>();

    }
    private void OnEnable()
    {
        CancelInvoke();
        Mn = GameObject.FindGameObjectsWithTag("Monster");

        Debug.Log(Mn.Length);
        if (Mn != null)
        {

            for (int i = 0; i < Mn.Length; i++)
            {
                Mn[i].GetComponent<MonsterCtrl>().SetSlow(10f,0.6f);

            }
        }
        Invoke("Destroy", 10f);
  
    }

    void Destroy()
    {
        this.gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
        
    }
}
