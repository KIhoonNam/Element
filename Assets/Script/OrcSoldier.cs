using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class OrcSoldier : MonsterCtrl
{

   
    // Start is called before the first frame update
    void Awake()
    {

        Rg = GetComponent<Rigidbody>();
        Nav = GetComponent<NavMeshAgent>();
        PlayerTr = FindObjectOfType<Character>();
        Ani = GetComponent<Animator>();
        Col = GetComponentInChildren<BoxCollider>();
    }

    private void Start()
    {
       
       

    }
    private void OnEnable()
    {
        Hp = 70;
        MaxHp = 70;
        Damage = 10;
        if (Hpbar == null)
        {
            var Can = GameObject.Find("HpCanvas").GetComponent<Canvas>();
            Hpbar = Instantiate(Resources.Load<Image>("MonsterHp"), Can.transform);
            var MonsterHp = GetComponent<PlayerHp>();

            MonsterHp.Hp = Hpbar;
        }
        var HpCheck = GetComponent<PlayerHp>();
        HpCheck.FillAmount(Hp, MaxHp);
    }
    // Update is called once per frame
    void Update()
    {
        if (!over)
        {
            //Rg.velocity = new Vector3(0, 0, 0);
            AttackSet();

            //if (StopMon)
            //    Nav.isStopped = true;
            //else if (!StopMon)
            //{
            //    if (!Vind)
            //    {
            //        Nav.isStopped = false;
            //        Nav.destination = PlayerTr.transform.position;
            //    }
            //}
            //Nav.transform.LookAt(PlayerTr.transform);

            time += Time.deltaTime;
        }
     
    }
    public override void SetAttackTime(bool On)
    {
        base.SetAttackTime(On);
    }
    void VindCheck()
    {


    }
    
    public override bool AttackGet()
    {
        base.AttackGet();
        return Col.enabled;
    }
    void AttackSet()
    {

        float Distance = Vector3.Distance(Nav.transform.position, PlayerTr.transform.position);
  
        if (Nav.stoppingDistance >= Distance)
        {
            Ani.SetBool("IsAttack", true);
            Nav.avoidancePriority = 40;
        }
        else
        {
            
            Ani.SetBool("IsAttack", false);
            Nav.avoidancePriority = 50;
        }
    }

    //public override void SetAttack(bool On)
    //{
    //    base.SetAttack(On);
    //}
    //public override void TakeDamage(float n, bool Chanel)
    //{
    //    base.TakeDamage(n, Chanel);

    //}
    //void SetBool()
    //{
    //    Lightning = false;
    //}
    void WaterSlowly(float n)
    {
        Slowly = n;
        Nav.speed = movespeed * Slowly * SlowSet;
    }
    //public override void VindMon(float time)
    //{
    //    base.VindMon(time);
    //}
    //public override void NockBack(Vector3 pos, float power)
    //{
    //    base.NockBack(pos, power);
    //}
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Element"))
        {
            if (other.name == "Water")
                WaterSlowly(0.8f);
        }
        else if (other.gameObject.layer == 8)
        {
            if (AttackTime)
            {
                Debug.Log(other.name);
                AttackTime = false;
                var PlayerHit = other.gameObject.GetComponent<Character>();
                PlayerHit.TakeDamage(Damage);
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Element"))
        {
            if (other.name == "Water")
                WaterSlowly(1.0f);
        }
    }


}

