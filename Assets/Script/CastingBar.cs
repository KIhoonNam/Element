using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastingBar : MonoBehaviour
{
    [SerializeField]
    Image Casting;
    float time = 0;
    bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        Casting.fillAmount = 0;
    }

    public void SetTime(float n)
    {
        if (time == 0)
        {
            time = n;
            start = true;
        }
    }
    public float GetTime()
    {
        return time;
    }

    // Update is called once per frame
    void Update()
    {
        if(time >0.1 && start)
        {
            Casting.fillAmount += Time.deltaTime / time;
        }
        if(Casting.fillAmount == 1)
        {
            Casting.fillAmount = 0;
            start = false;
            time = 0;
        }    
    }
}
