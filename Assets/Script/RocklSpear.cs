using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocklSpear : MonoBehaviour
{
    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Destroy", 1.2f);
        Ray dir = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(dir, out hit, 10000f,LayerMask.GetMask("Ground")))
        {
            targetPos = hit.point;
        }

        transform.position = targetPos;
    }

    void Destroy()
    {
        transform.position = new Vector3(0, 0, 0);
        this.gameObject.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            var MonsterHit = other.gameObject.GetComponent<MonsterCtrl>();
            MonsterHit.TakeDamage(-14, true, false) ;
            MonsterHit.NockBack(transform.position,20);
        }
    }
}
