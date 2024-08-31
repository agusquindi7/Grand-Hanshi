using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : Controller , IDragHandler , IEndDragHandler
{
    Vector3 _initialPos;
    [SerializeField] float maxMagnitude = 125f;

    private void Start()
    {
        _initialPos = transform.position;
    }

    public override Vector3 GetMovementInput()
    {
        Vector3 modifiedDir = new Vector3(_moveDir.x, 0, _moveDir.y);
        //Para dar un efecto de control de velocidad
        modifiedDir /= maxMagnitude;
        return modifiedDir;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _moveDir = Vector3.ClampMagnitude((Vector3)eventData.position - _initialPos, maxMagnitude);
        transform.position = _initialPos + _moveDir;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = _initialPos;
        _moveDir = Vector3.zero;
    }
}
