using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTexture : MonoBehaviour
{
    public Texture2D cursorTextureArrow;
    public Texture2D cursorTextureDialog;
    public Texture2D cursorTextureDialogOver;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Start()
    {
        Cursor.SetCursor(cursorTextureArrow, hotSpot, cursorMode);
    }

    private void OnEnable()
    {
        InputController.OnMouseTargetEmpty += InputController_OnMouseTargetEmpty;
        InputController.OnMouseOverTarget += InputController_OnMouseOverTarget;
        InputController.OnMouseOverNearTarget += InputController_OnMouseOverNearTarget;
    }


    private void OnDisable()
    {
        InputController.OnMouseTargetEmpty -= InputController_OnMouseTargetEmpty;
        InputController.OnMouseOverTarget -= InputController_OnMouseOverTarget;
        InputController.OnMouseOverNearTarget -= InputController_OnMouseOverNearTarget;
    }
    private void InputController_OnMouseOverNearTarget()
    {
        Cursor.SetCursor(cursorTextureDialogOver, hotSpot, cursorMode);
    }

    private void InputController_OnMouseOverTarget()
    {
        Cursor.SetCursor(cursorTextureDialog, hotSpot, cursorMode);
    }

    private void InputController_OnMouseTargetEmpty()
    {
        Cursor.SetCursor(cursorTextureArrow, hotSpot, cursorMode);
    }
    //void OnMouseEnter()
    //{
    //    Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    //}

    //void OnMouseExit()
    //{
    //    Cursor.SetCursor(null, Vector2.zero, cursorMode);
    //}
}
