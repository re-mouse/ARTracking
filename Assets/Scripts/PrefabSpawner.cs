using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedPrefab;

    private void OnMouseDown()
    {
        selectedPrefab.SetActive(true);
        selectedPrefab.transform.position = transform.position;
        selectedPrefab.transform.rotation = transform.rotation;
    }
}
