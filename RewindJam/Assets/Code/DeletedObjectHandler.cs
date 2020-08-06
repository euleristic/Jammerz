using System.Collections.Generic;
using UnityEngine;

public class DeletedObjectHandler : MonoBehaviour
{
    private static List<DestroyedObject> _destroyedObjects = new List<DestroyedObject>();
    public static void DestroyObject(GameObject obj)
    {
        DestroyedObject d = new DestroyedObject(obj, TimeManager.GetRelativeTime());
        _destroyedObjects.Add(d);
        obj.SetActive(false);
    }

    public void Update()
    {
        if(TimeManager.GetTimeFactor() < 0f)
        {
            for(int i = 0; i < _destroyedObjects.Count; i++)
            {
                int index = _destroyedObjects.Count - i - 1;
                if (TimeManager.GetRelativeTime() < _destroyedObjects[i].destroyedTime)
                {
                    _destroyedObjects[i].gO.SetActive(true);
                    _destroyedObjects.RemoveAt(i);
                }
            }
        }
    }
}

public class DestroyedObject
{
    public DestroyedObject(GameObject g, float t)
    {
        destroyedTime = t;
        gO = g;
    }
    public float destroyedTime;
    public GameObject gO;
}