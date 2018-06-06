using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {

    [Serializable]
    public class Wrapper<T>
    {
        public T[] Items;
    }

    [Serializable]
    public class Person
    {
        public long ID;
        public string Name;

    }

    public Wrapper<Person> wrapper = new Wrapper<Person>();
}
