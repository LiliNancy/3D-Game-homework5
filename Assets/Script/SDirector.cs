using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ISceneController{
    void LoadResources();
}
public class SDirector : System.Object
{
    private static SDirector _instance;
    public ISceneController currentScenceController{get;set;}
    public bool running{get;set;}
    public static SDirector getInstance(){
        if(_instance==null){
            _instance = new SDirector();
        }
        return _instance;
    }
}
