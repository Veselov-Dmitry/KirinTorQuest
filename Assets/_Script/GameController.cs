using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static event System.Action OnEnableFueld;
    public static event System.Action OnRelesLevel;
    public static event System.Action<int, int> OnStarntLevel;
    public static event Action OnWinTheGame;

    public static GameController instance;
    private int _Level;
    private int _FieladInLevel;

    private void OnEnable()
    {
        CellGenerator.OnGetAllCell += LevelComplite;
        InputController.OnMouseUseBox += InputController_OnMouseUseBox;
    }


    private void OnDisable()
    {
        CellGenerator.OnGetAllCell -= LevelComplite;
        InputController.OnMouseUseBox -= InputController_OnMouseUseBox;
    }

    private void InputController_OnMouseUseBox()
    {
        StartLevel();
    }
    private void LevelComplite()
    {
        _Level++;
        if(_Level < 10)
            StartLevel();
        else
            if(OnWinTheGame != null)
            {
                OnWinTheGame();
            }
    }

    void Start ()
    {
        instance = this;

        if (OnEnableFueld != null)
        {
            OnEnableFueld();
        }
        _Level = 3;
        _FieladInLevel = 7;
	}
	
	void Update ()
    {
		
	}

    internal void ReselLevel()
    {
        if (OnRelesLevel != null)
        {
            OnRelesLevel();
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    [ContextMenu("+++StartLevel")]
    private void StartLevel()
    {
         
        if (OnStarntLevel != null)
        {
            OnStarntLevel(_Level,_FieladInLevel);
        }
    }
}
