using UnityEngine;
using UnityEditor;

public class SelectCollisionDetectObjects
{
    [MenuItem("Tools/Select All CollisionDetect Objects")]
    public static void SelectAllCollisionDetectObjects()
    {
        // CollisionDetect scriptine sahip t�m objeleri bul
        CollisionDetect[] objectsWithScript = Object.FindObjectsOfType<CollisionDetect>();
        GameObject[] gameObjects = new GameObject[objectsWithScript.Length];
        for (int i = 0; i < objectsWithScript.Length; i++)
        {
            gameObjects[i] = objectsWithScript[i].gameObject;
        }
        // Hepsini sahnede se�
        Selection.objects = gameObjects;
        Debug.Log($"{gameObjects.Length} obje se�ildi.");
    }
}
