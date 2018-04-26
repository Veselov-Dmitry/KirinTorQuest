using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DlgMenu : MonoBehaviour {

    [SerializeField]
    private GameObject m_Menus;

    private void OnEnable()
    {
        InputController.OnEscape += InputController_OnBackSpase;
    }
    private void OnDisable()
    {
        InputController.OnEscape -= InputController_OnBackSpase;
    }


    void Start ()
    {

    }

    public void InputController_OnBackSpase(bool obj)
    {
        m_Menus.SetActive(obj);
    }


    void Update ()
    {
		
	}
}
