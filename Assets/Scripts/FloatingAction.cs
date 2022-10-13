using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class FloatingAction 
{
    public Sprite sprite;
    public string label;
    public UnityAction<int> action;
}
