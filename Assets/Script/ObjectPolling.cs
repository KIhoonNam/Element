using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPolling : MonoBehaviour
{
    public static ObjectPolling Instance;
    Queue<MnEffect> StunPool = new Queue<MnEffect>();
    Queue<MnEffect> DeadPool = new Queue<MnEffect>();


    Queue<Bullet> poolingFireQueue = new Queue<Bullet>();
    Queue<Bullet> poolingRockQueue = new Queue<Bullet>();
    Queue<Bullet> poolingTreeQueue = new Queue<Bullet>();
    Queue<Bullet> poolingWaterQueue = new Queue<Bullet>();
    Queue<Bullet> poolingLightningQueue = new Queue<Bullet>();
    Queue<Bullet> poolingFireRockQueue = new Queue<Bullet>();
    Queue<Bullet> poolingArrowQueue = new Queue<Bullet>();
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

  

    }

    private void Start()
    {
        Initialize(9);
        CreateFullFire();
        CreateFireShowerObject();
        CreateLazerObject();
        CreateUpFire();
        CreateRockSpearObject();
        CreateFullRockSpearObject();
        CreateVineTreeObject();
        CreateHealTreeObject();
        CreateWaterSpearObject();
        CreateWaterFogObject();
        CreateWaterLightning();
        CreateArrow();
        CreateHasteObject();
    }
    // Update is called once per frame
    private void Initialize(int initCount)

    {

        for (int i = 0; i < initCount; i++)

        {
            poolingRockQueue.Enqueue(CreateRockBullet());
            poolingFireQueue.Enqueue(CreateFireBallObject());
            StunPool.Enqueue(CreateStun());
            DeadPool.Enqueue(CreateDead());

        }
        for (int i = 0; i < initCount * 4; i++)

        {
            poolingTreeQueue.Enqueue(CreateTreeBullet());
            poolingWaterQueue.Enqueue(CreateWaterBullet());
            poolingLightningQueue.Enqueue(CreateLightningBullet());
            poolingArrowQueue.Enqueue(CreateArrow());

        }
        for(int i = 0; i < initCount *2.2;i++)
        {
            poolingFireRockQueue.Enqueue(CreateFireRockBallObject());
            
        }


    }

    private MnEffect CreateStun()
    {
        GameObject game = Resources.Load<GameObject>("Stun") as GameObject;

        var newObj = Instantiate(game).GetComponent<MnEffect>();

        newObj.gameObject.SetActive(false);

        newObj.transform.SetParent(transform);

        return newObj;
    }
    private MnEffect CreateDead()
    {
        GameObject game = Resources.Load<GameObject>("Dead") as GameObject;

        var newObj = Instantiate(game).GetComponent<MnEffect>();

        newObj.gameObject.SetActive(false);

        newObj.transform.SetParent(transform);

        return newObj;
    }
    private Bullet CreateRockBullet()
    {
        GameObject game = Resources.Load<GameObject>("Rock") as GameObject;

        var newObj = Instantiate(game).GetComponent<Bullet>();

        newObj.gameObject.SetActive(false);

        newObj.transform.SetParent(transform);

        return newObj;
    }
    private Bullet CreateArrow()
    {
        GameObject game = Resources.Load<GameObject>("Arrow") as GameObject;

        var newObj = Instantiate(game).GetComponent<Bullet>();

        newObj.gameObject.SetActive(false);

        newObj.transform.SetParent(transform);

        return newObj;
    }
    private Bullet CreateTreeBullet()
    {
        GameObject game = Resources.Load<GameObject>("Tree") as GameObject;

        var newObj = Instantiate(game).GetComponent<Bullet>();

        newObj.gameObject.SetActive(false);

        newObj.transform.SetParent(transform);

        return newObj;
    }
    private Bullet CreateWaterBullet()
    {
        GameObject game = Resources.Load<GameObject>("Water") as GameObject;

        var newObj = Instantiate(game).GetComponent<Bullet>();

        newObj.gameObject.SetActive(false);

        newObj.transform.SetParent(transform);

        return newObj;
    }
    private Bullet CreateLightningBullet()
    {
        GameObject game = Resources.Load<GameObject>("Lightning") as GameObject;

        var newObj = Instantiate(game).GetComponent<Bullet>();

        newObj.gameObject.SetActive(false);

        newObj.transform.SetParent(transform);

        return newObj;
    }
    private Bullet CreateFireBallObject()

    {
        GameObject game = Resources.Load<GameObject>("Fire") as GameObject;

        var newObj = Instantiate(game).GetComponent<Bullet>();

        newObj.gameObject.SetActive(false);

        newObj.transform.SetParent(transform);

        return newObj;

    }
    private Bullet CreateFireRockBallObject()

    {
        GameObject game = Resources.Load<GameObject>("FireRock") as GameObject;

        var newObj = Instantiate(game).GetComponent<Bullet>();

        newObj.gameObject.SetActive(false);

        newObj.transform.SetParent(transform);

        return newObj;

    }

    private void CreateFireShowerObject()

    {
        GameObject game = Resources.Load<GameObject>("UpFire") as GameObject;

        var newObj = Instantiate(game);    
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
    }
    private void CreateRockSpearObject()

    {
        GameObject game = Resources.Load<GameObject>("UpRock") as GameObject;

        var newObj = Instantiate(game);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
    }
    private void CreateFullRockSpearObject()

    {
        GameObject game = Resources.Load<GameObject>("FullRock") as GameObject;

        var newObj = Instantiate(game);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
    }
    private void CreateVineTreeObject()

    {
        GameObject game = Resources.Load<GameObject>("UpTree") as GameObject;

        var newObj = Instantiate(game);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
    }
    private void CreateHasteObject()

    {
        GameObject game = Resources.Load<GameObject>("FullPower") as GameObject;

        var newObj = Instantiate(game);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
    }
    private void CreateHealTreeObject()

    {
        GameObject game = Resources.Load<GameObject>("FullTree") as GameObject;

        var newObj = Instantiate(game);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
    }

    private void CreateWaterSpearObject()

    {
        GameObject game = Resources.Load<GameObject>("UpWater") as GameObject;

        var newObj = Instantiate(game);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
    }
    private void CreateWaterFogObject()

    {
        GameObject game = Resources.Load<GameObject>("FullWater") as GameObject;

        var newObj = Instantiate(game);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
    }
    private void CreateLazerObject()

    {
        GameObject game = Resources.Load<GameObject>("FullLightning") as GameObject;

        var newObj = Instantiate(game);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
    }
    private void CreateFullFire()

    {
        GameObject game = Resources.Load<GameObject>("FullFire") as GameObject;

        var newObj = Instantiate(game);     
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
    }
    private void CreateUpFire()

    {
        GameObject game = Resources.Load<GameObject>("UpLightning") as GameObject;

        var newObj = Instantiate(game);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
    }
    private void CreateWaterLightning()

    {
        GameObject game = Resources.Load<GameObject>("WaterLightning") as GameObject;

        var newObj = Instantiate(game);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
    }
    public static MnEffect GetMnEffect(string MnE)

    {
        if (MnE == "Stun")
        {
            if (Instance.StunPool.Count > 0)

            {

                var obj = Instance.StunPool.Dequeue();


                obj.transform.SetParent(null);

                obj.gameObject.SetActive(true);

                return obj;

            }

            else

            {

                var newObj = Instance.CreateStun();

                newObj.gameObject.SetActive(true);

                newObj.transform.SetParent(null);

                return newObj;

            }
        }
        else if (MnE == "Dead")
        {
            if (Instance.DeadPool.Count > 0)

            {

                var obj = Instance.DeadPool.Dequeue();


                obj.transform.SetParent(null);

                obj.gameObject.SetActive(true);

                return obj;

            }

            else

            {

                var newObj = Instance.CreateDead();

                newObj.gameObject.SetActive(true);

                newObj.transform.SetParent(null);

                return newObj;

            }

        }
        else
            return null;
    }
        public static Bullet GetObject(string Bullet)

    {
        if (Bullet == "Rock")
        {
            if (Instance.poolingRockQueue.Count > 0)

            {

                var obj = Instance.poolingRockQueue.Dequeue();
             

                obj.transform.SetParent(null);

                obj.gameObject.SetActive(true);

                return obj;

            }

            else

            {

                var newObj = Instance.CreateRockBullet();

                newObj.gameObject.SetActive(true);

                newObj.transform.SetParent(null);

                return newObj;

            }
        }
        else if (Bullet == "Tree")
        {
            if (Instance.poolingTreeQueue.Count > 0)

            {

                var obj = Instance.poolingTreeQueue.Dequeue();


                obj.transform.SetParent(null);

                obj.gameObject.SetActive(true);


                return obj;
            }

            else

            {

                var newObj = Instance.CreateTreeBullet();

                newObj.gameObject.SetActive(true);

                newObj.transform.SetParent(null);

                return newObj;

            }
        }
        else if (Bullet == "Water")
        {
            if (Instance.poolingWaterQueue.Count > 0)

            {

                var obj = Instance.poolingWaterQueue.Dequeue();


                obj.transform.SetParent(null);

                obj.gameObject.SetActive(true);


                return obj;
            }

            else

            {

                var newObj = Instance.CreateWaterBullet();

                newObj.gameObject.SetActive(true);

                newObj.transform.SetParent(null);

                return newObj;

            }
        }
        else if (Bullet == "Fire")
        {
            if (Instance.poolingFireQueue.Count > 0)

            {

                var obj = Instance.poolingFireQueue.Dequeue();
                
                
                obj.transform.SetParent(null);

                obj.gameObject.SetActive(true);


                return obj;
            }

            else

            {

                var newObj = Instance.CreateFireBallObject();
                
                newObj.gameObject.SetActive(true);

                newObj.transform.SetParent(null);

                return newObj;

            }
        }
        else if (Bullet == "Lightning")
        {
            if (Instance.poolingLightningQueue.Count > 0)

            {

                var obj = Instance.poolingLightningQueue.Dequeue();


                obj.transform.SetParent(null);

                obj.gameObject.SetActive(true);


                return obj;
            }

            else

            {

                var newObj = Instance.CreateLightningBullet();

                newObj.gameObject.SetActive(true);

                newObj.transform.SetParent(null);

                return newObj;

            }
        }
        else if (Bullet == "FireRock")
        {
            if (Instance.poolingFireRockQueue.Count > 0)

            {

                var obj = Instance.poolingFireRockQueue.Dequeue();


                obj.transform.SetParent(null);

                obj.gameObject.SetActive(true);


                return obj;
            }

            else

            {

                var newObj = Instance.CreateFireRockBallObject();

                newObj.gameObject.SetActive(true);

                newObj.transform.SetParent(null);

                return newObj;

            }
        }
        else if (Bullet == "Arrow")
        {
            if (Instance.poolingArrowQueue.Count > 0)

            {

                var obj = Instance.poolingArrowQueue.Dequeue();


                obj.transform.SetParent(null);

                obj.gameObject.SetActive(true);


                return obj;
            }

            else

            {

                var newObj = Instance.CreateArrow();

                newObj.gameObject.SetActive(true);

                newObj.transform.SetParent(null);

                return newObj;

            }
        }
        else
            return null;

    }



    public static void ReturnObject(Bullet obj)
     {

        obj.gameObject.SetActive(false);

        obj.transform.SetParent(Instance.transform);

        if (obj.gameObject.name == "Rock(Clone)")
            Instance.poolingRockQueue.Enqueue(obj);
        else if (obj.gameObject.name == "Fire(Clone)")
            Instance.poolingFireQueue.Enqueue(obj);
        else if (obj.gameObject.name == "Tree(Clone)")
            Instance.poolingTreeQueue.Enqueue(obj);
        else if (obj.gameObject.name == "Water(Clone)")
            Instance.poolingWaterQueue.Enqueue(obj);
        else if (obj.gameObject.name == "Lightning(Clone)")
            Instance.poolingLightningQueue.Enqueue(obj);
        else if (obj.gameObject.name == "FireRock(Clone)")
            Instance.poolingFireRockQueue.Enqueue(obj);
        else if (obj.gameObject.name == "Arrow(Clone)")
            Instance.poolingArrowQueue.Enqueue(obj);

    }
    public static void ReturnMnE(MnEffect obj)
    {
        obj.gameObject.SetActive(false);

        obj.transform.SetParent(Instance.transform);
        if (obj.gameObject.name == "Stun(Clone)")
            Instance.StunPool.Enqueue(obj);
        else if (obj.gameObject.name == "Dead(Clone)")
            Instance.DeadPool.Enqueue(obj);
    }

    }
