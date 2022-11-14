using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiskFactory : Singleton<DiskFactory>
{
    List<GameObject> used = new List<GameObject>();
    List<GameObject> free = new List<GameObject>();
    public int statue=0;
    public int level=0;
    public GameObject getDisk(){
        GameObject a;
        if(free.Count>0){
            a = free[0];
            free.Remove(a);
        }
        else{
            int t = (int)Random.Range(1,3);
            if(t==1) {
                a = Instantiate(Resources.Load("Plant1"),
            new Vector3(Random.Range(-12,12),7,0), Quaternion.identity, null) as GameObject;
                a.GetComponent<DickAction>().speed+=level;
            }
            else{
                a = Instantiate(Resources.Load("Plant2"),
            new Vector3(Random.Range(-12,12),7,0), Quaternion.identity, null) as GameObject;
                a.GetComponent<DickAction>().speed+=level;
                a.GetComponent<DickAction>().score*=2;
            }
        }
        used.Add(a);
        return a;
    }
    public void FreeDisk(GameObject b){
        b.SetActive(true);
        b.transform.position = new Vector3(Random.Range(-12,12),7,0);
        b.GetComponent<DickAction>().score /= b.GetComponent<DickAction>().speed;
        b.GetComponent<DickAction>().speed = (int)Random.Range(1,5)+level;
        b.GetComponent<DickAction>().score *= b.GetComponent<DickAction>().speed;
        used.Remove(b);
        free.Add(b);
    }
    public void ClearDisk(){
        GameObject a;
        while(used.Count>0){
            a = used[0];
            used.Remove(a);
            Destroy(a);
        }
        while(free.Count>0){
            a = free[0];
            free.Remove(a);
            Destroy(a);
        }
    }
}
