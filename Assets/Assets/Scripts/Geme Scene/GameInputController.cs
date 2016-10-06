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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.ChangeBoard();
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
        DeselectedObject();
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
        OnSelectedObject(hitObject);
    }

    private void OnDragNothing()
    {

    }

    private void OnTouchUp(GameObject hitObject)
    {
        if (selectedObject != null)
            OnTouchUpForRenderObject();
        DeselectedObject();
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

    private void DeselectedObject()
    {
        if (selectedObject != null)
            Debug.Log("Notice Lost Item");
        selectedObject = null;
    }

    private void OnTouchDownForRenderObject()
    {
        RenderObject render = selectedObject.GetComponent<RenderObject>();
        if (render != null)
        {
            render.GetHead<LogicRenderObject>().OnTouchDown();
        }
    }

    private void OnTouchUpForRenderObject()
    {
        RenderObject render = selectedObject.GetComponent<RenderObject>();
        if(render != null)
        {
            render.GetHead<LogicRenderObject>().OnTouchUp();
        }
    }
}
