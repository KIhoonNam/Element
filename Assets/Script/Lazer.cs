using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
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
        Invoke("Destroy", 5f);
    }

    void Destroy()
    {
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x ,player.transform.position.y + 1 ,player.transform.position.z );
        this.transform.rotation = player.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            var MonsterHit = other.gameObject.GetComponent<MonsterCtrl>();

            MonsterHit.TakeDamage(-30, false,false);
        }
    }
}
