﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBullet : Bullet
{
    private Vector3 direction;
    Rigidbody Rg;
    // Start is called before the first frame update
    void Start()
    {
        Rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rg.velocity = new Vector3(0, 0, 0);
        transform.Translate(Vector3.forward * Time.deltaTime * 20f);
    }

    public override void Shoot(Vector3 direction)
    {
        base.Shoot(direction);
        this.direction = direction;
        CancelInvoke();
        Invoke("DestroyBullet", 3f);

    }

    public override void DestroyBullet()
    {
        ObjectPolling.ReturnObject(this);
        Rg.isKinematic = false;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
            Rg.isKinematic = true;
        if (collision.gameObject.layer == 9)
        {
            var MonsterHit = collision.gameObject.GetComponent<MonsterCtrl>();
            MonsterHit.TakeDamage(-3, false,true);
            MonsterHit.VindMon(2f);

            DestroyBullet();
        }
    }
}
