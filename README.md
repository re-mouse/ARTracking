# ARTracked Image

ARTracked Image is a repository, that resolve problem with limited number of prefabs per card.

## 🚀Installation

- Clone the project.

```bash
git clone https://github.com/re-mouse/ARTracking.git
```
- Install Unity Editor 2019.4.20f1 or higher

- Build on platform that you need
> To run this app, your phone should support AR
---

## Problem

The Unity XR library allows you to detect given pictures and place objects on them, but the same object will always appear on any picture

## Usage

### Add new object on pool

- Add image on xr tracked images on `Assets/TrackedImages/FirstImage.asset`

![](https://github.com/re-mouse/Image-sources/blob/master/Add%20new%20image.png?raw=true)



- Add new GameObject in `Assets/Resources/Prefabs` with the same name, as Sprite name on previous stage

![](https://github.com/re-mouse/Image-sources/blob/master/Add%20new%20prefab.png?raw=true)


### Add more intialization on objects

By default object change only Mesh components, you can add more functionality at `Assets/Scripts/ModelManager.cs`

```csharp
private void Start()
{
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
```
## License
[MIT](https://choosealicense.com/licenses/mit/)
