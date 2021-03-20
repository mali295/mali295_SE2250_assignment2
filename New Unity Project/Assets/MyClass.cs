using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        X obj = new Y();
        obj.i = 1;
        obj.F1();
        obj.PrintX();
    }

    public class X {
        public int i;
        protected int j;
        public void PrintX() {
            print("Result is: " + i + "and" + j);
        }
        public virtual void F1() {
            j = i + 5;
        }

    }

    class Y : X 
    {
        public void F1()
        {
            j = 2;
            base.i = 3;
            i = 2;
            base.F1();
        } 
    }
}
