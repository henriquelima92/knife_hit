using System.Collections;
using System;
using UnityEngine;

public static class Utilities
{
    public static IEnumerator StartMethodWithDelay(float delay, Action method)
    {
        yield return new WaitForSeconds(delay);
        method();
    }
}
