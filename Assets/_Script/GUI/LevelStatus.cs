using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStatus : MonoBehaviour {
    private Text _Text;

    private void OnEnable()
    {
        GameController.OnStarntLevel += GameController_OnStarntLevel;
        GameController.OnLevelComplite += GameController_OnLevelComplite;
        GameController.OnRelesLevel += CellGenerator_OnRelesLevel;
    }
    private void OnDisable()
    {
        GameController.OnStarntLevel -= GameController_OnStarntLevel;
        GameController.OnLevelComplite -= GameController_OnLevelComplite;
        GameController.OnRelesLevel -= CellGenerator_OnRelesLevel;
    }


    void Start ()
    {
        _Text = GetComponent<Text>();
	}

    private void CellGenerator_OnRelesLevel()
    {
        _Text.text += " [Fail]";
    }

    private void GameController_OnLevelComplite()
    {
    }

    private void GameController_OnStarntLevel(int arg1, int arg2)
    {
        _Text.text = (arg1 +1).ToString();
    }


}
