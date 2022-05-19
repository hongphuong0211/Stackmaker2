﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public List<MapSettings> settings;
    public PointPath pointPrefabs;
    public StackPath stackPrefabs;
    public GameObject goalPrefabs;
    private MapSettings curSettings;
    private List<PointPath> pointPath;
    private int curPoint = 0;
    private int level;

    private void Awake()
    {
        curPoint = 0;
        level = DataManager.GetInt("level", 0);
        curSettings = settings[Mathf.Clamp(level, 0, settings.Count - 1)];
        pointPath = new List<PointPath>();
        pointPath.Add(transform.GetChild(0).GetChild(0).GetComponent<PointPath>());
        Vector3 curRotation = Vector3.zero;
        int point = 0;
        for (int i = 1; i < curSettings.pointsMap.Count; i++)
        {
            PointPath path = Instantiate(pointPrefabs, transform.GetChild(0));
            Vector3 dir = curSettings.pointsMap[i].position - curSettings.pointsMap[i - 1].position;
            if (dir.x == 0)
            {
                curRotation = Vector3.zero;
            }else if (dir.x < 0)
            {
                curRotation = Vector3.up * (-90);
            }else
            {
                curRotation = Vector3.up * 90;
            }
            path.transform.localPosition = curSettings.pointsMap[i].position;
            path.transform.eulerAngles = curRotation;
            path.SetPrevPoint(curSettings.pointsMap[i - 1].position);
            point += (curSettings.pointsMap[i].isIncreaseStack ? 1 : -1) * (int)dir.magnitude;
            for (int j = 1; j < Vector3.Distance(curSettings.pointsMap[i].position, curSettings.pointsMap[i - 1].position); j++)
            {
                StackPath stackPath = Instantiate(stackPrefabs, transform.GetChild(1));
                stackPath.transform.localPosition = curSettings.pointsMap[i - 1].position + j * dir.normalized;
                stackPath.transform.localEulerAngles = curRotation;
                stackPath.SetStatusPath(curSettings.pointsMap[i].isIncreaseStack, !curSettings.pointsMap[i].isIncreaseStack);
            }
            if (i < curSettings.pointsMap.Count - 1)
            {
                path.SetNextPoint(curSettings.pointsMap[i + 1].position);
            }
            path.GetComponent<StackPath>().SetStatusPath(curSettings.pointsMap[i].isIncreaseStack, !curSettings.pointsMap[i].isIncreaseStack);
            pointPath.Add(path);
        }
        for(int i = 0; i < point; i++)
        {
            StackPath stackPath = Instantiate(stackPrefabs, transform.GetChild(1));
            stackPath.transform.localPosition = curSettings.pointsMap[curSettings.pointsMap.Count - 1].position + i * Vector3.forward;
            stackPath.transform.localEulerAngles = Vector3.zero;
            stackPath.SetStatusPath(false, true);
        }
        GameObject goalObject = Instantiate(goalPrefabs, transform);
        goalObject.transform.localPosition = curSettings.pointsMap[curSettings.pointsMap.Count - 1].position + point * Vector3.forward;
    }
}
