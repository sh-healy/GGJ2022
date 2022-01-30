using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null; 
    public static GameManager Instance 
    { 
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if( _instance == null) 
                {
                    GameObject go = new GameObject();
                    go.name = "GameManager";
                    _instance = go.AddComponent<GameManager>(); 
                    DontDestroyOnLoad(go); 
                }
            }
            return _instance;
        }
    }

    public SceneController SceneController;
    public HUDCanvasController HUDController;
    public ScoreManager ScoreManager;
    public NumberManager NumberManager;

    void Awake() 
    {
        if(_instance == null ) 
        {
            _instance = this; 
            DontDestroyOnLoad(this.gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start() 
    {
        int finalNumber = ScoreManager.SetUpScore();
        NumberManager.SpawnNumbers(finalNumber);
    }
    
}
