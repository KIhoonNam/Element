using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningShield : MonoBehaviour
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
        Invoke("Destroy", 10f);
    }

    void Destroy()
    {
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position;//new Vector3(player.transform.position.x ,player.transform.position.y ,player.transform.position.z );
        transform.rotation = player.transform.rotation;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            var MonsterHit = other.gameObject.GetComponent<MonsterCtrl>();

            MonsterHit.TakeDamage(-5, true,true);
            MonsterHit.VindMon(3f);
        }
    }
}
