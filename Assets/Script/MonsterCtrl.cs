using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterCtrl : MonoBehaviour
{
    MonsterCtrl instance;
    StageManager stage;
    public SoundScript Sound;
    protected Character PlayerTr;
    protected Rigidbody Rg;
    protected NavMeshAgent Nav;
    protected BoxCollider Col;
    protected BoxCollider Col1;
    private CharacterController MCol;
    protected Image Hpbar;
    [HideInInspector]
    public Animator Ani;
    protected  float Slowly = 1;
    protected float SlowSet = 1;
    protected float movespeed = 3.5f;
    protected float time = 0.0f;
    protected float VindTime = 0.0f;
    protected float Damage;
    protected float Hp;
    protected float MaxHp;
    protected bool Vind = false;
    protected bool Stun = false;
    protected  bool Lightning = false;
    protected bool AttackTime = false;
    protected bool over = false;
    bool NavStop = false;
    public bool StopMon = false;
    
  
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        MCol = GetComponent<CharacterController>();
        Sound = GetComponent<SoundScript>();
        //Rg = GetComponent<Rigidbody>();
        //Nav = GetComponent<NavMeshAgent>();
        //PlayerTr = FindObjectOfType<Character>();
        //Ani = GetComponent<Animator>();
        //Col = gameObject.transform.GetChild(0).gameObject.GetComponent<SphereCollider>();

    }
    private void Start()
    {
        stage = FindObjectOfType<StageManager>();
        
        
    }
    private void OnEnable()
    {
        if (this.name == "OrcSoldier(Clone)")
            instance = GetComponent<OrcSoldier>();
        else if (this.name == "OrcTanker(Clone)")
            instance = GetComponent<OrcTanker>();
        else if (this.name == "OrcRanger(Clone)")
            instance = GetComponent<OrcRanger>();

        Setting();

    }
    void Setting()
    {
        StageManager.Over += GameOver;
        instance.Vind = false;
        instance.Lightning = false;
        instance.AttackTime = false;
        instance.StopMon = false;
        instance.time = 0.0f;
        instance.VindTime = 0.0f;
    }

    void GameOver()
    {
        instance.over = true;
        instance.Ani.SetBool("IsAttack", false);
        StageManager.Over -= GameOver;
    }
    public virtual void SetAttackTime(bool On)
    {

        instance.AttackTime = On;
    }
    // Update is called once per frame
    void Update()
    {
        if (!instance.over)
        {
            instance.Hpbar.transform.position = new Vector3(instance.transform.position.x - 0.3f, instance.transform.position.y + 2.5f, instance.transform.position.z);

            //Rg.velocity = new Vector3(0, 0, 0);
            if (!NavStop)
            {
                if (instance.StopMon)
                {

                    instance.Nav.isStopped = true;
                }
                else if (!instance.StopMon)
                {
                    if (!instance.Vind)
                    {
                        instance.Nav.isStopped = false;
                        instance.Nav.destination = instance.PlayerTr.transform.position;

                    }
                }
                if (!instance.Stun)
                    instance.Nav.transform.LookAt(instance.PlayerTr.transform);
            }
            //instance.transform.rotation = new Quaternion(0, instance.transform.rotation.y, instance.transform.rotation.z,1);

            VindCheck();

        }

    }
    void Destroy()
    {

    }
    void SetHp(float n)
    {
      
        instance.Hp += n;
        if (instance.Hp <= 0)
        {
            instance.Nav.isStopped = true;
            NavStop = true;

            instance.Rg.useGravity = false;
            MCol.enabled = false;

            instance.Ani.SetBool("IsDead", true);
            Sound.ChangeAudio("En_Death");
            Sound.PlayAudio();

        }
        else
        {
            Sound.ChangeAudio("En_Hit");
            Sound.PlayAudio();
        }
        var HpCheck = GetComponent<PlayerHp>();
        HpCheck.FillAmount(instance.Hp, instance.MaxHp);
       
    }
    public void SetDead()
    {
        
        instance.Hpbar.transform.position = new Vector3(0, 0, 0);

        instance.Rg.useGravity = true;
        NavStop = false;
        MCol.enabled = true;
        var MnE = ObjectPolling.GetMnEffect("Dead");
        MnE.transform.position = transform.position;
       
        MnE.SetDestroy(2f);
        stage.MonsterCn();

        MonsterPool.ReturnObject(this);

    }
    void VindCheck()
    {

        instance.VindTime -= Time.deltaTime;
        if (instance.VindTime < 0)
        {
            instance.Vind = false;
            instance.Ani.SetBool("IsVind", false);
            instance.Stun = false;
            instance.Ani.SetBool("IsStun", false);
        }
        
    }
    public virtual  bool AttackGet()
    {
        return instance.Col.enabled;
    }
    public bool AttackGet1()
    {
        return instance.Col1.enabled;
    }

    public void SetStopMon(bool On)
    {
        instance.Nav.velocity = new Vector3(0,0,0);
        instance.StopMon = On;

    }
    public virtual void SetAttack(bool On,int n)
    {
        if (n == 1)
            instance.Col1.enabled = On;
        else
        {
            if(On)
                instance.Col.transform.GetChild(0).gameObject.SetActive(true);
            else
                instance.Col.transform.GetChild(0).gameObject.SetActive(false);
            instance.Col.enabled = On;
        }

    }
    public void SetSlow(float time,float slow)
    {
        instance.SlowSet = slow;
        instance.Nav.speed = instance.movespeed * instance.Slowly * instance.SlowSet;
        Invoke("SlowCancle", time);
    }
    public void SlowCancle()
    {
        instance.SlowSet = 1f;
        instance.Nav.speed = instance.movespeed * instance.Slowly * instance.SlowSet;
    }
    public virtual void TakeDamage(float n, bool Chanel,bool stun)
    {
        if (Chanel)
        {
            if (instance.time > 1f)
            {
                SetHp(n);
                Debug.Log(n);
                instance.time = 0;
                if (stun && !instance.Stun)
                {

                    var MnE = ObjectPolling.GetMnEffect("Stun");
                    MnE.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                    MnE.SetDestroy(3f);
                   
                    instance.Stun = true;
                }
            }
        }
        else if (!Chanel)
        {
            if (n == -30)
            {
                if (!instance.Lightning)
                {
                    SetHp(n);
                    instance.Lightning = true;
                    Invoke("SetBool", 5f);
                    


                }

            }
            else
            {
                SetHp(n);
                Debug.Log(n);
                if (stun && !instance.Stun)
                {

                    var MnE = ObjectPolling.GetMnEffect("Stun");
                    MnE.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                    MnE.SetDestroy(2f);
                    
                    instance.Stun = true;
                }
            }
        }
        

    }

    void SetBool()
    {
        instance.Lightning = false;
    }

    public virtual void VindMon(float time)
    {
        if (instance.VindTime <= 0)
        {
            instance.VindTime = time;
            instance.Vind = true;
            instance.Nav.isStopped = true;
            instance.Ani.SetBool("IsVind", true);
            instance.Ani.SetBool("IsStun", true);
        }
    }
    public virtual void NockBack(Vector3 pos,float power)
    {
        if (instance.Hp > 0)
        {
            if (instance.Col)
            {
                SetAttack(false, 0);
                
            }
            else if(instance.Col1 != null)
                SetAttack(false, 1);
            instance.Ani.SetBool("IsAttack", false);
            instance.Ani.SetBool("IsHit", true);
            Vector3 Back;
            Back = pos - instance.transform.position;
            instance.Rg.AddForce(-instance.transform.forward * power, ForceMode.Impulse);
            instance.Nav.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
        }
    }
    public void SetBoolAni(string name,bool On)
    {
        instance.Ani.SetBool(name, On);
       
        if (name == "IsHit")
            instance.Nav.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
     

    }

    

}
