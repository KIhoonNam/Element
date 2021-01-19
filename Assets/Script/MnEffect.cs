using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MnEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
 
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDestroy(float n)
    {
        if (this.name == "Stun(Clone)")
            Invoke("Destroy", n);
        else if(this.name == "Dead(Clone)")
            Invoke("Destroy", 2f);

    }

    void Destroy()
    {
        ObjectPolling.ReturnMnE(this);
    }
}
