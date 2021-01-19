using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcArrow : Bullet
{
    private Vector3 direction;
    Rigidbody Rg;
    float Damage = 15;
    SoundScript Sound;
    // Start is called before the first frame update
    void Start()
    {
        Rg = GetComponent<Rigidbody>();
        Sound = GetComponent<SoundScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Rg.velocity = new Vector3(0, 0, 0);
        transform.Translate(direction * Time.deltaTime * 20f);
    }

    public override void Shoot(Vector3 direction)
    {
        base.Shoot(direction);
        this.direction = direction;

        Invoke("DestroyBullet", 3f);

    }

    public override void DestroyBullet()
    {
        ObjectPolling.ReturnObject(this);
        Rg.isKinematic = false;

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
            Rg.isKinematic = true;
        if (collision.gameObject.layer == 8)
        {
            //var MonsterHit = collision.gameObject.GetComponent<MonsterCtrl>();
            //MonsterHit.TakeDamage(-10, false);
            Sound.ChangeAudio("Ar_Hit");
            DestroyBullet();
            Debug.Log("Hit");
            var PlayerHit = collision.gameObject.GetComponent<Character>();
            PlayerHit.TakeDamage(Damage);
        }
    }
}
