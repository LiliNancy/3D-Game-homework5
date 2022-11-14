using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DickAction : MonoBehaviour
{
    public int speed;
    public int score;
    static DiskFactory fc;
    void Start()
    {
        speed = (int)Random.Range(1,6);
        score = (int)speed;
        fc = Singleton<DiskFactory>.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y<-7){
            fc.FreeDisk(this.transform.gameObject);
            return;
        }
        if(fc.statue==1) this.gameObject.transform.Translate(new Vector3(0,-1,0)*this.speed*Time.deltaTime);
    }
}
