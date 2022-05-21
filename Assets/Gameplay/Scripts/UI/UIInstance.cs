using UnityEngine;

public class UIInstance : MonoBehaviour
{
    public EnumManager.NumberUI numberUI;
    public EnumManager.NumberUI otherNumberUI;
    protected virtual void OnInit()
    {

    }
    protected virtual void OnEnable()
    {
        UIManager.Instance.OpenUI(otherNumberUI);
    }
    protected virtual void OnDisable()
    {
        UIManager.Instance.CloseUI(otherNumberUI);
    }
    

}
