using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineTree : MonoBehaviour
{
    Vector3 targetPos;
    Character player;
    BoxCollider Box;
    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<Character>();
        Box = GetComponent<BoxCollider>();
    }


    private void OnEnable()
    {
        Box.center = new Vector3(0, 1, 0f);
        CancelInvoke();
        Invoke("Destroy", 1.5f);
        this.transform.position = player.transform.GetChild(0).transform.position;//new Vector3(player.transform.position.x ,player.transform.position.y ,player.transform.position.z );
        this.transform.rotation = player.transform.rotation;

    }

    void Destroy()
    {
        Box.size = new Vector3(2, 5, 0);
        Box.center = new Vector3(0, 0, 0);
        transform.position = new Vector3(0, 0, 0);
        this.gameObject.SetActive(false);

    }
    void Size()
    {
        if (Box.size.z < 10)
            Box.size += new Vector3(0, 0, Time.deltaTime * 30);
        if (Box.center.z < 5)
            Box.center += new Vector3(0, 0, Time.deltaTime * 15);
    }
    // Update is called once per frame
    void Update()
    {
        Size();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            var MonsterHit = other.gameObject.GetComponent<MonsterCtrl>();
            MonsterHit.TakeDamage(-15, true,false);
            MonsterHit.VindMon(3);
           
        }
    }
}
