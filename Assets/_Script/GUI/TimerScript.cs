using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private Text _Text;
    private float _Time;
    private TimeSpan ts;
    private float _StartLevelTime;
    private Coroutine _Coroutine;

    private void OnEnable()
    {
        GameController.OnStarntLevel += GameController_OnRun;
        GameController.OnLevelComplite += GameController_OnLevelComplite;
        CellGenerator.OnDemoPlayed += CellGenerator_OnDemoPlayed;
        InputController.OnEscape += InputController_OnEscape;
    }

    private void OnDisable()
    {
        GameController.OnStarntLevel -= GameController_OnRun;
        GameController.OnLevelComplite -= GameController_OnLevelComplite;
        CellGenerator.OnDemoPlayed -= CellGenerator_OnDemoPlayed;
        InputController.OnEscape -= InputController_OnEscape;
    }

    void Start ()
    {
        _Text = GetComponent<Text>();
	}


    private void InputController_OnEscape(bool obj)
    {
        if (obj)
        {

        }
    }


    private void CellGenerator_OnDemoPlayed()
    {
        _StartLevelTime = Time.time;
        _Coroutine = StartCoroutine(TimeCounter());
    }
    private void GameController_OnLevelComplite()
    {
        StopCoroutine(_Coroutine);
        _Text.text = " ";
    }
    private void GameController_OnRun(int lvl,int size)
    {
        _Text.text = "00:00";
    }

    private IEnumerator TimeCounter()
    {
        while (true)
        {
            _Time = Time.time - _StartLevelTime;
            TimeSpan total = new TimeSpan(0, 0, 0, (int)_Time);

            _Text.text = string.Format("{0}:{1}", total.Minutes.ToString("00"), total.Seconds.ToString("0#."));
            yield return new WaitForSeconds(0.5f);
        }
    }
}
