using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameShowerScript : MonoBehaviour
{

    ParticleSystem ps;
    Character player;
    [SerializeField]
    GameObject MonsterPool;
    List<GameObject> Monster = new List<GameObject>();
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

    float DamageCount;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
       
        ps = GetComponent<ParticleSystem>();
        player = FindObjectOfType<Character>();
        SetMosnterTrigger();

        
        

    }
    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Destroy", 3f);
    }

    void Destroy()
    {
        this.gameObject.SetActive(false);
    }

    void SetMosnterTrigger()
    {

    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.GetChild(0).transform.position;//new Vector3(player.transform.position.x ,player.transform.position.y ,player.transform.position.z );
        this.transform.rotation = player.transform.rotation;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            var MonsterHit = other.gameObject.GetComponent<MonsterCtrl>();
            if(MonsterHit !=null)
            MonsterHit.TakeDamage(-10, true,false);
        }
    }
    //private void OnParticleCollision(GameObject other)
    //{
    //    if (other.layer == 9)
    //        Debug.Log("Hit");

    //}

    //private void OnParticleTrigger()
    //{
    //    // get the particles which matched the trigger conditions this frame
    //    int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    //    int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

    //    // iterate through the particles which entered the trigger and make them red
    //    for (int i = 0; i < numEnter; i++)
    //    {


    //        ParticleSystem.Particle p = enter[i];
    //        p.startColor = new Color32(255, 0, 0, 255);

    //        enter[i] = p;

    //    }

    //    // iterate through the particles which exited the trigger and make them green
    //    for (int i = 0; i < numExit; i++)
    //    {
    //        ParticleSystem.Particle p = exit[i];
    //        p.startColor = new Color32(0, 255, 0, 255);
    //        exit[i] = p;
    //    }

    //    // re-assign the modified particles back into the particle system
    //    ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    //    ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    //}

}
