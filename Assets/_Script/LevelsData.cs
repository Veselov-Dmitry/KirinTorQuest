using System.Collections.Generic;
using UnityEngine;

public class LevelsData : MonoBehaviour {

    List<Queue<Pos>> Base = new List<Queue<Pos>> ();
    public static LevelsData instance;
     
    void Start ()
    {
        instance = this;
        Queue<Pos> q; 
        q = new Queue<Pos>();
        q.Enqueue(new Pos(1, 1));
        q.Enqueue(new Pos(2, 1));
        q.Enqueue(new Pos(3, 1)); 
        q.Enqueue(new Pos(4, 1));
        q.Enqueue(new Pos(5, 1));
        q.Enqueue(new Pos(5, 2));
        q.Enqueue(new Pos(5, 3));
        q.Enqueue(new Pos(5, 4));
        q.Enqueue(new Pos(5, 5));
        q.Enqueue(new Pos(5, 6));
        Base.Add(q);

        Queue<Pos> q2 = new Queue<Pos>();
        q2.Enqueue(new Pos( 1 , 1));
        q2.Enqueue(new Pos( 2 , 1));
        q2.Enqueue(new Pos( 3 , 1));
        q2.Enqueue(new Pos( 4 , 1));
        q2.Enqueue(new Pos( 5 , 1));
        q2.Enqueue(new Pos( 5 , 2));
        q2.Enqueue(new Pos( 5 , 3));
        q2.Enqueue(new Pos( 5 , 4));
        q2.Enqueue(new Pos( 5 , 5));
        q2.Enqueue(new Pos( 4 , 5));
        q2.Enqueue(new Pos( 3 , 5));
        q2.Enqueue(new Pos( 2 , 5));
        q2.Enqueue(new Pos( 1 , 5));
        q2.Enqueue(new Pos( 0 , 5));
        Base.Add(q2);

        Queue<Pos> q3 = new Queue<Pos>();
        q3.Enqueue(new Pos(1, 1));
        q3.Enqueue(new Pos(2, 1));
        q3.Enqueue(new Pos(3, 1));
        q3.Enqueue(new Pos(3, 2));
        q3.Enqueue(new Pos(3, 3));
        q3.Enqueue(new Pos(3, 4));
        q3.Enqueue(new Pos(3, 5));
        q3.Enqueue(new Pos(4, 5));
        q3.Enqueue(new Pos(5, 5));
        q3.Enqueue(new Pos(6, 5));
        Base.Add(q3);

        Queue<Pos> q4 = new Queue<Pos>();
        q4.Enqueue(new Pos(1, 1));
        q4.Enqueue(new Pos(1, 2));
        q4.Enqueue(new Pos(1, 3));
        q4.Enqueue(new Pos(1, 4));
        q4.Enqueue(new Pos(1, 5));
        q4.Enqueue(new Pos(2, 5));
        q4.Enqueue(new Pos(3, 5));
        q4.Enqueue(new Pos(3, 4));
        q4.Enqueue(new Pos(3, 3));
        q4.Enqueue(new Pos(3, 2));
        q4.Enqueue(new Pos(3, 1));
        q4.Enqueue(new Pos(4, 1));
        q4.Enqueue(new Pos(5, 1));
        q4.Enqueue(new Pos(6, 1));
        Base.Add(q4);

        Queue<Pos> q5 = new Queue<Pos>();
        q5.Enqueue(new Pos(1, 1));
        q5.Enqueue(new Pos(1, 2));
        q5.Enqueue(new Pos(2, 2));
        q5.Enqueue(new Pos(2, 3));
        q5.Enqueue(new Pos(3, 3));
        q5.Enqueue(new Pos(3, 4));
        q5.Enqueue(new Pos(4, 4));
        q5.Enqueue(new Pos(4, 5));
        q5.Enqueue(new Pos(5, 5));
        q5.Enqueue(new Pos(6, 5));
        Base.Add(q5);

        Queue<Pos> q6 = new Queue<Pos>();
        q6.Enqueue(new Pos(1, 1));
        q6.Enqueue(new Pos(2, 1));
        q6.Enqueue(new Pos(3, 1));
        q6.Enqueue(new Pos(4, 1));
        q6.Enqueue(new Pos(5, 1));
        q6.Enqueue(new Pos(5, 2));
        q6.Enqueue(new Pos(5, 3));
        q6.Enqueue(new Pos(4, 3));
        q6.Enqueue(new Pos(3, 3));
        q6.Enqueue(new Pos(2, 3));
        q6.Enqueue(new Pos(2, 4));
        q6.Enqueue(new Pos(1, 4));
        q6.Enqueue(new Pos(1, 5));
        q6.Enqueue(new Pos(1, 6));
        Base.Add(q6);

        Queue<Pos> q7 = new Queue<Pos>();
        q7.Enqueue(new Pos(1, 1));
        q7.Enqueue(new Pos(1, 2));
        q7.Enqueue(new Pos(2, 2));
        q7.Enqueue(new Pos(3, 2));
        q7.Enqueue(new Pos(3, 1));
        q7.Enqueue(new Pos(4, 1));
        q7.Enqueue(new Pos(5, 1));
        q7.Enqueue(new Pos(5, 2));
        q7.Enqueue(new Pos(5, 3));
        q7.Enqueue(new Pos(4, 3));
        q7.Enqueue(new Pos(4, 4));
        q7.Enqueue(new Pos(3, 4));
        q7.Enqueue(new Pos(3, 5));
        q7.Enqueue(new Pos(2, 5));
        q7.Enqueue(new Pos(2, 6));
        Base.Add(q7);

        Queue<Pos> q8 = new Queue<Pos>();
        q8.Enqueue(new Pos(1, 1));
        q8.Enqueue(new Pos(1, 2));
        q8.Enqueue(new Pos(1, 3));
        q8.Enqueue(new Pos(1, 4));
        q8.Enqueue(new Pos(1, 5));
        q8.Enqueue(new Pos(2, 5));
        q8.Enqueue(new Pos(3, 5));
        q8.Enqueue(new Pos(4, 5));
        q8.Enqueue(new Pos(5, 5));
        q8.Enqueue(new Pos(5, 4));
        q8.Enqueue(new Pos(5, 3));
        q8.Enqueue(new Pos(5, 2));
        q8.Enqueue(new Pos(5, 1));
        q8.Enqueue(new Pos(4, 1));
        q8.Enqueue(new Pos(4, 2));
        q8.Enqueue(new Pos(4, 3));
        q8.Enqueue(new Pos(3, 3));
        q8.Enqueue(new Pos(3, 2));
        q8.Enqueue(new Pos(2, 2));
        q8.Enqueue(new Pos(2, 1));
        q8.Enqueue(new Pos(2, 0));
        Base.Add(q8);

        Queue<Pos> q9 = new Queue<Pos>();
        q9.Enqueue(new Pos(1, 1));
        q9.Enqueue(new Pos(1, 2));
        q9.Enqueue(new Pos(2, 2));
        q9.Enqueue(new Pos(3, 2));
        q9.Enqueue(new Pos(3, 1));
        q9.Enqueue(new Pos(4, 1));
        q9.Enqueue(new Pos(5, 1));
        q9.Enqueue(new Pos(5, 2));
        q9.Enqueue(new Pos(5, 3));
        q9.Enqueue(new Pos(4, 3));
        q9.Enqueue(new Pos(3, 3));
        q9.Enqueue(new Pos(2, 3));
        q9.Enqueue(new Pos(2, 4));
        q9.Enqueue(new Pos(3, 4));
        q9.Enqueue(new Pos(4, 4));
        q9.Enqueue(new Pos(5, 4));
        q9.Enqueue(new Pos(5, 5));
        q9.Enqueue(new Pos(4, 5));
        q9.Enqueue(new Pos(3, 5));
        q9.Enqueue(new Pos(2, 5));
        q9.Enqueue(new Pos(1, 5));
        q9.Enqueue(new Pos(1, 4));
        q9.Enqueue(new Pos(1, 3));
        q9.Enqueue(new Pos(0, 3));
        Base.Add(q9);

        Queue<Pos> q10 = new Queue<Pos>();
        q10.Enqueue(new Pos(1, 1));
        q10.Enqueue(new Pos(1, 2));
        q10.Enqueue(new Pos(2, 2));
        q10.Enqueue(new Pos(2, 1));
        q10.Enqueue(new Pos(3, 1));
        q10.Enqueue(new Pos(3, 2));
        q10.Enqueue(new Pos(4, 2));
        q10.Enqueue(new Pos(4, 1));
        q10.Enqueue(new Pos(5, 1));
        q10.Enqueue(new Pos(5, 2));
        q10.Enqueue(new Pos(5, 3));
        q10.Enqueue(new Pos(5, 4));
        q10.Enqueue(new Pos(5, 5));
        q10.Enqueue(new Pos(4, 5));
        q10.Enqueue(new Pos(4, 4));
        q10.Enqueue(new Pos(3, 4));
        q10.Enqueue(new Pos(3, 5));
        q10.Enqueue(new Pos(2, 5));
        q10.Enqueue(new Pos(2, 4));
        q10.Enqueue(new Pos(2, 3));
        q10.Enqueue(new Pos(1, 3));
        q10.Enqueue(new Pos(1, 4));
        q10.Enqueue(new Pos(1, 5));
        q10.Enqueue(new Pos(1, 6));
        Base.Add(q10);
    }
	
	public IEnumerable<Pos> GetLevel(int index = 0)
    {
        return Base[index];
    }
}
