using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyController : MonoBehaviour,ISceneController,IUserAction
{
    int Gamestatue = 0;
    float diskNum = (float)0.4;
    public GameObject cam;
    public int score=0;
    DiskFactory fcc;
    void Awake(){
        SDirector director = SDirector.getInstance();
        director.currentScenceController = this;
        fcc = Singleton<DiskFactory>.Instance;
    }
    public void LoadResources(){
    }
    public int StartGame(){
        fcc.ClearDisk();
        Gamestatue = 1;
        fcc.statue = Gamestatue;
        score = 0;
        return Gamestatue;
    }
    public int GameOver(){
        Gamestatue = 2;
        fcc.statue = Gamestatue;
        return Gamestatue;
    }
    public int Pause(){
        if(Gamestatue!=2){
            Gamestatue = 1-Gamestatue;
            fcc.statue = Gamestatue;
        }
        return Gamestatue;
    }
    public void Setlevel(int round){
        fcc.level = round;
    }
    public void HitDel(){
        if(Input.GetButtonDown("Fire1")){
            Vector3 mp = Input.mousePosition;
            Camera ca;
            if(cam!=null) ca = cam.GetComponent<Camera>();
            else ca = Camera.main;

            Ray ray = ca.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] hits = Physics.RaycastAll(ray);

            foreach(RaycastHit hit in hits){
                hit.transform.gameObject.SetActive(false);
                fcc.FreeDisk(hit.transform.gameObject);
                score+=hit.transform.gameObject.GetComponent<DickAction>().score;
                diskNum--;
            }
        }
    }
    public int ScoreCount(){
        return score;
    }

    void Update()
    {
        if(Gamestatue==1) HitDel();
        diskNum+=Time.deltaTime;
        if(diskNum>=0.4&&Gamestatue==1){
            fcc.getDisk();
            diskNum = 0;
        }
        
    }
}
