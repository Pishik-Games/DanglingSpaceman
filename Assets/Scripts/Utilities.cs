using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

class Utilities{

    public delegate void CallBack();
    public static void setTimeout(MonoBehaviour mb ,CallBack cb, float sec){
        mb.StartCoroutine(ExecuteAfterTime(cb, sec));
    }

    private static IEnumerator ExecuteAfterTime(CallBack cb, float sec){
        yield return new WaitForSeconds(sec);
        cb();
    }
}