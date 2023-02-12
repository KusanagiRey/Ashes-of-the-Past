using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera _cam;
    public Transform _subject;

    Vector2 startPosition;
    float _startZ;

    Vector2 travel => (Vector2)_cam.transform.position - startPosition;

    float _distanceFromSubject => transform.position.z - _subject.position.z;
    float _clippingPlane => (_cam.transform.position.z + (_distanceFromSubject > 0 ? _cam.farClipPlane : _cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(_distanceFromSubject) / _clippingPlane;

    public void Start(){
        startPosition = transform.position;
        _startZ = transform.position.z;
    }

    public void Update(){
        Vector2 newPos = startPosition + travel * parallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, _startZ);
    }
}
