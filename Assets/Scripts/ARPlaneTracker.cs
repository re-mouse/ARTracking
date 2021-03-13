using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaneTracker : MonoBehaviour
{
    [SerializeField]
    private GameObject visualGrid;
    [SerializeField]
    private GameObject prefab;

    private ARRaycastManager rayCastManager;

    private void Start()
    {
        rayCastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        UpdateGridState();
    }

    private void UpdateGridState()
    {
        List<ARRaycastHit> hits = GetRaycastHits();
        if (hits.Count > 0)
        {
            visualGrid.SetActive(true);

            Pose gridPose = hits[0].pose;
            visualGrid.transform.position = gridPose.position;
            visualGrid.transform.rotation = gridPose.rotation;
        }
        else
            visualGrid.SetActive(false);
    }

    private List<ARRaycastHit> GetRaycastHits()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        rayCastManager.Raycast(new Vector2(Screen.width /2, Screen.height / 2), hits, TrackableType.Planes);

        return hits;
    }
}
