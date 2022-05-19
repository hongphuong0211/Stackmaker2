using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackPath : MonoBehaviour
{
    public bool hasStack = true;
    public bool loseStack = false;
    public Material colorWhite;
    public Material colorYellow;
    private MeshRenderer colorPath;
    private GameObject stackObject;

    private void Awake()
    {
        stackObject = transform.GetChild(0).gameObject;
        colorPath = transform.GetChild(2).GetComponent<MeshRenderer>();
    }

    public void SetStatusPath(bool newStatusHave, bool newStatusLose = false)
    {
        hasStack = newStatusHave;
        loseStack = newStatusLose;
        if (loseStack)
        {
            stackObject.SetActive(false);
            if (!hasStack)
            {
                colorPath.material = colorWhite;
            }
            else
            {
                colorPath.material = colorYellow;
            }
        }
        else
        {
            colorPath.material = colorWhite;
            if (!hasStack)
            {
                stackObject.SetActive(false);
            }
            else
            {
                stackObject.SetActive(true);
            }
        }
    }
}
