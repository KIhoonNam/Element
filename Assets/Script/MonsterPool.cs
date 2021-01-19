using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{

    public static MonsterPool Instance;

    Queue<MonsterCtrl> OrcSoldier = new Queue<MonsterCtrl>();
    Queue<MonsterCtrl> OrcRanger = new Queue<MonsterCtrl>();
    Queue<MonsterCtrl> OrcTanker = new Queue<MonsterCtrl>();

    StageManager stage;



    private void Awake()
    {
        Instance = this;

    
    }

    private void Start()
    {
        Initialize(8);
        stage = FindObjectOfType<StageManager>();
        StartCoroutine(stage.Spawn(1,3));
       
    }
    private void Initialize(int initCount)

    {
        for (int i = 0; i < initCount; i++)
        {
            OrcSoldier.Enqueue(CreateOrcSoldier());
            OrcTanker.Enqueue(CreateOrcTanker());
            OrcRanger.Enqueue(CreateOrcRanger());
        }



    }
    private MonsterCtrl CreateOrcSoldier()
    {
        GameObject game = Resources.Load<GameObject>("OrcSoldier") as GameObject;

        var newObj = Instantiate(game).GetComponent<MonsterCtrl>();

        newObj.gameObject.SetActive(false);

        newObj.transform.SetParent(transform);

        return newObj;
    }
    private MonsterCtrl CreateOrcRanger()
    {
        GameObject game = Resources.Load<GameObject>("OrcRanger") as GameObject;

        var newObj = Instantiate(game).GetComponent<MonsterCtrl>();

        newObj.gameObject.SetActive(false);

        newObj.transform.SetParent(transform);

        return newObj;
    }
    private MonsterCtrl CreateOrcTanker()
    {
        GameObject game = Resources.Load<GameObject>("OrcTanker") as GameObject;

        var newObj = Instantiate(game).GetComponent<MonsterCtrl>();

        newObj.gameObject.SetActive(false);

        newObj.transform.SetParent(transform);

        return newObj;
    }

    public static MonsterCtrl GetObject(string Monster)

    {

        if (Monster == "OrcSoldier")
        {
            if (Instance.OrcSoldier.Count > 0)

            {

                var obj = Instance.OrcSoldier.Dequeue();


                obj.transform.SetParent(null);

                obj.gameObject.SetActive(true);


                return obj;
            }

            else

            {

                var newObj = Instance.CreateOrcSoldier();

                newObj.gameObject.SetActive(true);

                newObj.transform.SetParent(null);

                return newObj;

            }
        }
        else if (Monster == "OrcTanker")
        {
            if (Instance.OrcTanker.Count > 0)

            {

                var obj = Instance.OrcTanker.Dequeue();


                obj.transform.SetParent(null);

                obj.gameObject.SetActive(true);


                return obj;
            }

            else

            {

                var newObj = Instance.CreateOrcTanker();

                newObj.gameObject.SetActive(true);

                newObj.transform.SetParent(null);

                return newObj;

            }
        }
        else if (Monster == "OrcRanger")
        {
            if (Instance.OrcRanger.Count > 0)

            {

                var obj = Instance.OrcRanger.Dequeue();


                obj.transform.SetParent(null);

                obj.gameObject.SetActive(true);


                return obj;
            }

            else

            {

                var newObj = Instance.CreateOrcRanger();

                newObj.gameObject.SetActive(true);

                newObj.transform.SetParent(null);

                return newObj;

            }
        }
        else
            return null;

    }



    public static void ReturnObject(MonsterCtrl obj)

    {

        obj.gameObject.SetActive(false);

        obj.transform.SetParent(Instance.transform);

      
         if (obj.gameObject.name == "OrcRanger(Clone)")
            Instance.OrcRanger.Enqueue(obj);
         else if (obj.gameObject.name == "OrcTanker(Clone)")
            Instance.OrcTanker.Enqueue(obj);
        else if (obj.gameObject.name == "OrcSoldier(Clone)")
            Instance.OrcSoldier.Enqueue(obj);

    }
}
