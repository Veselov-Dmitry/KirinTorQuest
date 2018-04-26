using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct Pos
{
    public Pos(int x, int z)
    {
        this.x = x;
        this.z = z;
    }
    public Pos(CellScript c)
    {
        x = c.posit.x;
        z = c.posit.z;
    }
    public bool Compare(Pos a)
    {
        return ((a.x == x) && (a.z == z));
    }
    public int x;
    public int z;
}
public class CellGenerator : MonoBehaviour
{
    public static event Action OnDemoPlayed;
    public static event Action OnGetAllCell;

    public class PatternLevel
    {
        public Queue<Pos> Ways
        {
            get
            {
                return _Way;
            }
        }
        private Queue<Pos> _Way = new Queue<Pos>();
        public PatternLevel(IEnumerable<Pos> waysPoint)
        {
            waysPoint.ToList();
            foreach (var item in waysPoint)
            {
                _Way.Enqueue(item);
            }
        }

        internal bool StatusCell(Pos posit)
        {
            if(_Way.Peek().Compare(posit))
            {
                _Way.Dequeue();
                return true;
            }
            return false;
        }
    }

    public GameObject TemplateCell;
    public static CellGenerator instance;

    private PatternLevel _CurentLevelPattern;
    private int _RectSize = 7;
    private Dictionary<Pos, CellScript> _Children = new Dictionary<Pos, CellScript>();
    private Coroutine coroutine;
    private int _CountCellHit;

    private void OnEnable()
    {
        CellScript.OnPlayerEnter += CellScript_OnPlayerEnter;
        GameController.OnEnableFueld += GameController_OnEnableFueld;
        GameController.OnStarntLevel += GameController_OnStarntLevel;
    }


    private void OnDisable()
    {
        CellScript.OnPlayerEnter += CellScript_OnPlayerEnter;
        GameController.OnEnableFueld -= GameController_OnEnableFueld;
        GameController.OnStarntLevel -= GameController_OnStarntLevel;
    }
    void Start()

    {
        instance = this;
        _CountCellHit = 0;
    }


    public void Register(CellScript c)
    {
        Pos p = new Pos(c);
        if (!_Children.ContainsKey(p))
            _Children.Add(p,c);
    }

    private void CellScript_OnPlayerEnter(CellScript cs)
    {
        if (_Children.ContainsKey(new Pos(cs)))
        {
            if (_CurentLevelPattern.StatusCell(new Pos(cs)))
            {
                cs.Hide(false);
                if( _CurentLevelPattern.Ways.Count<1)
                {
                    if(OnGetAllCell != null) { OnGetAllCell(); }
                }
            }
            else
            {
                GameController.instance.ReselLevel();
                SetVisibleAll(false, false);
            }
        }
    }

    private void GameController_OnEnableFueld()
    {
        GenerateCells();
    }
    private void GameController_OnStarntLevel(int level, int fields)
    {
        _CountCellHit = 0;
        _CurentLevelPattern = new PatternLevel(LevelsData.instance.GetLevel(level));
        GenerateWay();
    }

    [ContextMenu("+++GenerateCells")]
    private void GenerateCells()
    {
        for (int i = 0; i < _RectSize; i++)
        {
            for (int j = 0; j < _RectSize; j++)
            {
                var obj = Instantiate(TemplateCell,gameObject.transform);
                obj.name = "cell (" + i + "," + j + ")";
                CellScript cs = obj.GetComponent<CellScript>();
                Register(cs);
                cs.posit.z =i;
                cs.posit.x = j;
            }
        }

    }
    [ContextMenu("+++GenerateWay")]
    public void GenerateWay()
    {
        SetVisibleAll(false);
        coroutine = StartCoroutine(ShowWay());
    }

    private IEnumerator ShowWay()
    {

        foreach (Pos item in _CurentLevelPattern.Ways)
        {
            yield return new WaitForSeconds(0.9f);
            _Children[item].Show(false);
        }
        SetVisibleAll(true,false);
        if (OnDemoPlayed != null) OnDemoPlayed();
        StopCoroutine(coroutine);

        coroutine = null;
    }

    public void SetVisibleAll(bool active,bool instanly = true)
    {
        foreach (Pos item in _Children.Keys)
        {
            if(active)
                _Children[item].Show(instanly);
            else
                _Children[item].Hide(instanly);
        }
    }
}
