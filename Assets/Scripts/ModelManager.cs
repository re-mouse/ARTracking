using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ModelManager : MonoBehaviour
{
    public static readonly string[] prefabPaths = new string[] 
    { 
        "Prefabs/Hambuger",
        "Prefabs/Donuts",
        "Prefabs/Cake",
        "Prefabs/Milk"
    };

    public static ModelManager instance;

    private List<GameObject> prefabPool = new List<GameObject>();
    private List<MeshRenderer> meshes = new List<MeshRenderer>();
    private List<MeshFilter> meshFilters = new List<MeshFilter>();

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        meshRendererComponent = GetComponent<MeshRenderer>();
        meshFilterComponent = GetComponent<MeshFilter>();

        foreach (string path in prefabPaths)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            if (prefab != null)
                IntializePrefabInList(prefab);
            else
                Debug.LogError("Prefab " + path + " not found");
        }
    }

    private void IntializePrefabInList(GameObject prefab)
    {
        prefabPool.Add(prefab);
        meshes.Add(prefab.GetComponent<MeshRenderer>());
        meshFilters.Add(prefab.GetComponent<MeshFilter>());
    }

    public void SetModelByName(string name, GameObject gameObject)
    {
        int index = prefabPool.FindIndex(p => p.name == name);
        if (index < 0)
        {
            Debug.LogError("Model with " + name + " not found in intialized list");
            return;
        }
        gameObject.GetComponent<MeshFilter>().mesh = meshFilters[index].mesh;
        gameObject.GetComponent<MeshRenderer>().material = meshes[index].material;
    }
}
