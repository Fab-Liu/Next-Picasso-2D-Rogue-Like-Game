using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood_spur : MonoBehaviour
{

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timer > 0.2)
            Destroy(this.gameObject);
    }
}
