using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationGameObject : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    public void SetObjectActive()
    {
        targetObject.SetActive(true);
    }

    public void SetObjectInactive()
    {
        targetObject.SetActive(false);
    }
}
