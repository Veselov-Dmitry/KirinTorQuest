using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public static event System.Action<CellScript> OnPlayerEnter;

    public class Posit
    {
        public event System.Action OnChangeValue;   

        public Posit(int x, int z)
        {
            _Point[0] = x;
            _Point[1] = z;
        }
        public Posit()
        { }
        public bool Equal(Posit p)
        { return (p.p == _Point); }
        public static bool Equal(Posit p1,Posit p2)
        { return ((p1.x==p2.x)&&(p1.z == p2.z)); }
        private int[] _Point = new int[]{0,0};

        public void Set(int x, int z)
        {
            _Point[0] = x; _Point[1] = z;
            if (OnChangeValue != null)
                OnChangeValue();
        }
        public int[] p
        {
            get { return _Point; }
            set
            {
                _Point = value;
                if (OnChangeValue != null)
                    OnChangeValue();
            }
        }
        public int x
        {
            get { return _Point[0]; }
            set
            {
                _Point[0] = value;
                if (OnChangeValue != null)
                    OnChangeValue();
            }
        }
        public int z
        {
            get { return _Point[1]; }
            set
            {
                _Point[1] = value;
                if (OnChangeValue != null)
                    OnChangeValue();
            }
        }
    }

    public Posit posit = new Posit();
    private Collider _Col;
    private Projector _Projector;
    private Coroutine cooutine;
    [Range(0,1)]
    public float _SmothOnHideShow = 0.5f;
    public bool test;
    private object _LerpingPower;

    void Awake()
    {
        _Projector = transform.GetChild(0).GetComponent<Projector>();
        _Projector.material = new Material(_Projector.material);
    }

    private void OnEnable()
    {
        posit.OnChangeValue += Posit_OnChangeValue;
    }

    private void OnDisable()
    {
        posit.OnChangeValue -= Posit_OnChangeValue;
    }

    private void Posit_OnChangeValue()
    {
        gameObject.transform.localPosition = new Vector3(posit.x, 0, posit.z);
    }

    void Start ()
    {
        _SmothOnHideShow = 0.03f;
        CellGenerator.instance.Register(this);
        _Col = GetComponent<Collider>();
        Hide(true);

    }

    [ContextMenu("+++Hide")]
    public void HideMenu()
    {
        Hide(false);
    }
    [ContextMenu("+++Show")]
    public void ShowMenu()
    {
        Show(false);
    }
    public void Hide(bool instantly = true)
    {
        if (_LerpingPower == null)
        {
            _LerpingPower = new object();
            _Col.enabled = false;
            if (instantly)
            {
                _Projector.material.SetFloat("_Power", 0);
                _LerpingPower = null;
            }
            else
                cooutine = StartCoroutine(ProjectorHide());
        }
    }

    public void Show(bool instantly = true)
    {
        if (_LerpingPower == null)
        {
            _LerpingPower = new object();
            _Col.enabled = true;
            if (instantly)
            {
                _Projector.material.SetFloat("_Power", 1);
                _LerpingPower = null;
            }
            else
                cooutine = StartCoroutine(ProjectorShow());
        }
    }

    private IEnumerator ProjectorShow()
    {
        float curVal = 0;
        while (curVal < 0.9f)
        {
            yield return new WaitForEndOfFrame();
            curVal = Mathf.Lerp(curVal, 1, _SmothOnHideShow);
            _Projector.material.SetFloat("_Power", curVal);
        }
        _LerpingPower = null;
        StopCoroutine(cooutine);
    }

    private IEnumerator ProjectorHide()
    {
        float curVal = 1;
        while (curVal > 0.1f)
        {
            yield return new WaitForEndOfFrame();
            curVal = Mathf.Lerp(curVal, 0, _SmothOnHideShow);
            _Projector.material.SetFloat("_Power", curVal);
        }
        _LerpingPower = null;
        StopCoroutine(cooutine);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_LerpingPower != null) return;
        if (other.tag != "Player") return;
        if (OnPlayerEnter != null)
        {
            OnPlayerEnter(this);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (_LerpingPower != null) return;
        if (other.tag != "Player") return;
        if (OnPlayerEnter != null)
        {
            OnPlayerEnter(this);
        }
    }
}
