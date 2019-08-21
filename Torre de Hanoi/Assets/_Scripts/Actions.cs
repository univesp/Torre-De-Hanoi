using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Actions : MonoBehaviour
{
    [SerializeField] private bool hasDelay;
    [SerializeField] private WaitForSeconds wait;
    [SerializeField] private UnityEvent action;

    public void MakeAction(float _delayTime)
    {
        if(hasDelay)
        {
            wait = new WaitForSeconds(_delayTime);
            StartCoroutine(WaitToMakeAction());
        }
        else
        {
            action.Invoke();
        }
    }

    private IEnumerator WaitToMakeAction()
    {
        yield return wait;
        action.Invoke();
    }
}
