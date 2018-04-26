using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField]
    private Slider m_Slider;
    private FreeLookCam m_FreeLookCam;
    void Start ()
    {
        m_Slider.maxValue = 10;
        m_FreeLookCam = FreeLookCam.instance;
    }

    private void OnEnable()
    {
        if(m_FreeLookCam == null) m_FreeLookCam = FreeLookCam.instance;
        m_Slider.value = m_FreeLookCam.TurnSpeed;
    }
    


    void Update ()
    {
        m_FreeLookCam.TurnSpeed = m_Slider.value;
    }
}
