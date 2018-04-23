using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainText : MonoBehaviour {

    private Text _Text;
    private int _fontSize;
    private Color _color;
    private Coroutine _Coroutine;
    [Range(0.8f, 1f)]
    [SerializeField]
    private float _SmothVanish = 0.9f;

    private void OnEnable()
    {
        GameController.OnStarntLevel += GameController_OnStarntLevel;
        GameController.OnRelesLevel += GameController_OnRelesLevel;
        CellGenerator.OnGetAllCell += CellGenerator_OnGetAllCell;
        GameController.OnWinTheGame += GameController_OnWinTheGame;
    }


    private void OnDisable()
    {
        GameController.OnStarntLevel -= GameController_OnStarntLevel;
        GameController.OnRelesLevel -= GameController_OnRelesLevel;
        CellGenerator.OnGetAllCell -= CellGenerator_OnGetAllCell;
        GameController.OnWinTheGame -= GameController_OnWinTheGame;

    }
    private void GameController_OnWinTheGame()
    {
        Show("Win The Game!");
    }

    private void CellGenerator_OnGetAllCell()
    {
        Show("Finish!");
    }
    private void GameController_OnRelesLevel()
    {
        Show("Fail");
    }

    private void GameController_OnStarntLevel(int lvl, int arg2)
    {
        Show("Level " + (lvl +1).ToString());
    }

    private void Show(string v)
    {
        StopAllCoroutines();
        _Text.text =  v;
        _Text.fontSize = _fontSize;
        _Text.color = _color;
        _Coroutine = StartCoroutine(Vanishing());
    }

    private IEnumerator Vanishing()
    {
        float myAlpha = 1;

        yield return new WaitForSeconds(1f);
        while (myAlpha>0.01)
        {
            yield return new WaitForFixedUpdate();
            myAlpha = Mathf.Lerp(myAlpha, 0, 1 - _SmothVanish);
            _Text.fontSize = (int)(_fontSize + _fontSize *(1 - myAlpha));
            _Text.color = new Color(_color.r, _color.g, _color.b, myAlpha);
        }
        StopCoroutine(_Coroutine);
    }

    void Start ()
    {
        _Text = GetComponent<Text>();
        _fontSize = _Text.fontSize;
        _color = _Text.color;
    }
	
	void Update ()
    {
		
	}
}
