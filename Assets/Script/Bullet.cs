using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

   
    private void Update()
    {
       

    }

    public virtual void Shoot(Vector3 direction)
    {
       
    }

    public void Set(Bullet bullet,Vector3 dir,string name)
    {
        if (name == "Fire")
            bullet = GetComponent<FireBullet>();
        else if (name == "Rock")
            bullet = GetComponent<RockBullet>();
        else if (name == "Tree")
            bullet = GetComponent<TreeBullet>();
        else if (name == "Water")
            bullet = GetComponent<WaterBullet>();
        else if (name == "Lightning")
            bullet = GetComponent<LightningBullet>();
        else if (name == "Arrow")
            bullet = GetComponent<OrcArrow>();
        bullet.Shoot(dir);
    }
    


    public virtual void DestroyBullet()
    {
        
    }













}
