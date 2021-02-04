using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wall : MonoBehaviour, IDragHandler{
    
    public List<Vector3> hitPoints = new List<Vector3>();
    public void OnDrag(PointerEventData eventData){
        // Get the world position of the pointer:
        // It will be on the Camera's position
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Remember that point, so we can draw gizmos in the scene view for debugging:
        this.hitPoints.Add(position);
        // Calculate the local position for this world point on the Isometric Grid:
        position = this.transform.parent.InverseTransformPoint(position);
        // Set the wall's local position to the floored, calculated local position:
        this.transform.localPosition = new Vector3(Mathf.Floor(position.x), Mathf.Floor(position.y), position.z);
        
        // Problem: The tile is now stuck hovering over the Isometric Grid, stuck to the Camera Screen.
        // Fix: Use RayCasts in order to calculate the correct z position for the Mouse Input
    }
    void OnDrawGizmos() {
        this.hitPoints.ForEach(point => Gizmos.DrawCube(point, Vector3.one * 0.5f));
    }
}