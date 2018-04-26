using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public static PlayerScript instance;
    private void OnEnable()
    {
        GameController.OnStarntLevel += GameController_OnStarntLevel;
        CellGenerator.OnDemoPlayed += CellGenerator_OnDemoPlayed;
        InputController.OnEscape += BlockPlayer;
    }


    private void OnDisable()
    {
        GameController.OnStarntLevel -= GameController_OnStarntLevel;
        CellGenerator.OnDemoPlayed -= CellGenerator_OnDemoPlayed;
        InputController.OnEscape -= BlockPlayer;
    }
    void Start ()
    {
        instance=this;
    }

    private void BlockPlayer(bool obj)
    {
        GetComponent<Collider>().enabled = !obj;
        GetComponent<Rigidbody>().constraints = (!obj) ? RigidbodyConstraints.FreezeRotation : RigidbodyConstraints.FreezeAll;
    }

    private void CellGenerator_OnDemoPlayed()
    {
        BlockPlayer(false);
    }

    private void GameController_OnStarntLevel(int level, int fields)
    {
        transform.Rotate(Vector3.forward);
        BlockPlayer(true);
        Vector3 pos = CellGenerator.instance.gameObject.transform.position;
        gameObject.transform.position = new Vector3(pos.x + 1, GetPositionY(pos), pos.z + 1);
    }

    private float GetPositionY(Vector3 pos)
    { 
        float res =0;
        GameObject go = new GameObject();
        go.name = "Raycast";
        go.transform.position = new Vector3(pos.x + 1, pos.y+10, pos.z + 1);
        RaycastHit myhit = new RaycastHit();
        Ray ray = new Ray { origin = go.transform.position, direction = go.transform.up * -1 };
        if(Physics.Raycast(ray, out myhit, 15))
        {
            res = myhit.point.y;
        }
        return res;
    }

	
}
