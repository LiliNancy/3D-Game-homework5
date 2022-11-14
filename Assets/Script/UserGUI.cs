using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserAction{
    int StartGame();
    int Pause();
    int GameOver();
    int ScoreCount();
    void Setlevel(int round);
}
public class UserGUI : MonoBehaviour
{
    private IUserAction action;
    int score = 0;
    float time = 30;
    GUIStyle style,bigstyle;
    string gameMessage = "";
    int round = 1;
    int statue=0;
    void Start()
    {
        action = SDirector.getInstance().currentScenceController as IUserAction;

        style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.fontSize = 70;

        bigstyle = new GUIStyle();
        bigstyle.normal.textColor = Color.black;
        bigstyle.fontSize = 20;
    }
    void OnGUI(){
        GUI.Box(new Rect(10,10,120,100), "Menu");
        if(GUI.Button(new Rect(20,40,100,20), "Start")){
            statue = action.StartGame();
            time = 30;
            score = 0;
            gameMessage = "";
        }
        if(GUI.Button(new Rect(20,70,100,20), "Stop/Continue")){
            statue = action.Pause();
        }
        if(gameMessage == "Next round"){
            if(GUI.Button(new Rect(300,100,180,60), "Continue")){
                action.Setlevel(round);
                statue = action.StartGame();
                time=30;
                gameMessage = "";
                round++;
            }
        }
        GUI.Label(new Rect(370, 200, 180, 200), gameMessage,style);
        GUI.Label(new Rect(Screen.width - 150,10,100,50), "Time: " + time, bigstyle);
        GUI.Label(new Rect(Screen.width - 150,30,100,50), "Score: " + score, bigstyle);
        GUI.Label(new Rect(Screen.width - 400,10,100,50), "Round " + round, bigstyle);
    }
    void Update()
    {
        score = action.ScoreCount();
        if(time<=0) {
            if(round==1){
                if(score>50) gameMessage="Next round";
                else gameMessage="Game Over";
            }
            else {
                if(score>40*round) gameMessage="You Win!!!";
                else gameMessage="Game Over";
            }
            statue = action.GameOver();
            time=0;
        }
        if(statue==1) time-=Time.deltaTime;
    }
}
