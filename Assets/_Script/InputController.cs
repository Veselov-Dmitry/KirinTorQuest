﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static event System.Action OnMouseOverTarget;
    public static event System.Action OnMouseOverNearTarget;
    public static event System.Action OnMouseTargetEmpty;
    public static event System.Action OnMouseUseBox;
    public static event System.Action<bool> OnEscape;

    private RaycastHit hit;
    private Ray ray;
    private bool _NearTarget;
    private bool m_ShowMenu = false;


    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_ShowMenu = !m_ShowMenu;
            if (OnEscape != null)
                OnEscape(m_ShowMenu);            
        }
        if (m_ShowMenu) return;

        _NearTarget = false;
        hit = new RaycastHit();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            var Start = hit.transform.gameObject.GetComponent<StartCube>();
            if (Start != null)
            {
                Vector3 dist = Start.gameObject.transform.position - PlayerScript.instance.transform.position;

                //print("dist.magnitude " + dist.magnitude);
                if (dist.magnitude < 4)
                {
                    _NearTarget = true;
                    if(OnMouseOverNearTarget != null) { OnMouseOverNearTarget(); }
                }
                else
                {
                    if (OnMouseOverTarget != null) OnMouseOverTarget();
                }
            }
            else
            {
                if(OnMouseTargetEmpty != null)
                {
                    OnMouseTargetEmpty();
                }
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            if ( _NearTarget )
            {
                if(OnMouseUseBox != null) { OnMouseUseBox(); }
            }       
        }

    }
}
