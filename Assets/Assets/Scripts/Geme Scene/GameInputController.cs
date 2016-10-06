using UnityEngine;
using System.Collections;
using System;

public class GameInputController : MonoBehaviour {
    public static GameInputController Instance { get; private set; }

    public GameObject selectedObject;

    private bool isClicked;

    void Awake()
    {
        Instance = this;
        isClicked = false;
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        if(Input.GetMouseButtonDown(0))
        {
            isClicked = true;
            RayCastCheck(mousePosition, OnTouchDown, OnTouchDownNothing);
        }
        else if(isClicked && Input.GetMouseButton(0))
        {
            RayCastCheck(mousePosition, OnDragObject, OnDragNothing);
        }
        else if(isClicked && Input.GetMouseButtonUp(0))
        {
            isClicked = false;
            RayCastCheck(mousePosition, OnTouchUp, OnTouchUpNothing);
            selectedObject = null;
        }
    }

    private void RayCastCheck(Vector3 position, Action<GameObject> action, Action failAction)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(position), Vector2.zero);
        if (hit.collider != null)
        {
            action(hit.transform.gameObject);
        }
        else
        {
            LostSelectedObject(failAction);
        }
    }

    private void LostSelectedObject(Action failAction)
    {
        failAction();
        UnselectedObject();
    }

    private void OnTouchDown(GameObject hitObject)
    {
        OnSelectedObject(hitObject);
    }

    private void OnTouchDownNothing()
    {

    }

    private void OnDragObject(GameObject hitObject)
    {

    }

    private void OnDragNothing()
    {

    }

    private void OnTouchUp(GameObject hitObject)
    {

    }

    private void OnTouchUpNothing()
    {

    }

    private void OnSelectedObject(GameObject _selectObject)
    {
        if (selectedObject != null)
        {
            if(selectedObject == _selectObject)
            {
                return;
            }
            Debug.Log("Notice already have selected item"); // Notice It
        }
        selectedObject = _selectObject;
    }

    private void UnselectedObject()
    {
        if (selectedObject != null)
            Debug.Log("Notice Lost Item");
        selectedObject = null;
    }
}
