using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities  {

	public static void DestroyChildren(Transform parent) {
        Transform[] children = GetComponentsInDirectChildren<Transform>(parent.gameObject);
        for (int i = 0; i < children.Length; i++) {
            GameObject.Destroy(children[i].gameObject);
        }
    }
    public static T[] GetComponentsInDirectChildren<T>(GameObject gameObject) {
        int indexer = 0;

        foreach (Transform transform in gameObject.transform) {
            if (transform.GetComponent<T>() != null) {
                indexer++;
            }
        }

        T[] returnArray = new T[indexer];

        indexer = 0;

        foreach (Transform transform in gameObject.transform) {
            if (transform.GetComponent<T>() != null) {
                returnArray[indexer++] = transform.GetComponent<T>();
            }
        }

        return returnArray;
    }
    public static T[] GetEnumValues<T>() where T : struct {
        if (!typeof(T).IsEnum) {
            throw new ArgumentException("GetValues<T> can only be called for types derived from System.Enum", "T");
        }
        return (T[])Enum.GetValues(typeof(T));
    }
}
