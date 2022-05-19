﻿using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PointPath : MonoBehaviour
{
    public bool isContinuos = false;
    private Vector3 prevPoint = Vector3.zero;
    private Vector3 nextPoint = Vector3.zero;
    public void SetPrevPoint(Vector3 newPos)
    {
        prevPoint = newPos;
    }

    public void SetNextPoint(Vector3 newPos)
    {
        nextPoint = newPos;
    }

    public int CheckDirection(Vector3 dirMove)
    {
        if(dirMove.normalized == (transform.position - prevPoint).normalized)
        {
            return -1;
        }else if (dirMove.normalized == (transform.position - nextPoint).normalized)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
