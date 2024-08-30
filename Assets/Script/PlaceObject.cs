using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceObject : MonoBehaviour
{
    [SerializeField]
    private  GameObject prefab;
    
    private GameObject spwanedObject;
    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
    }

    bool TryGetTouchPos(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!TryGetTouchPos(out Vector2 touchPosition))
            return;

        if (aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spwanedObject == null)
            {
                spwanedObject = Instantiate(prefab, hitPose.position, hitPose.rotation);
                aRPlaneManager.enabled = false;
                aRRaycastManager.enabled = false;
            }
            else
            {
                spwanedObject.transform.position = hitPose.position;
            }
        }
    }
}
