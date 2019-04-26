using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class dragRigidbody2 : MonoBehaviour
{
    const float k_Spring = 50.0f;
    const float k_Damper = 5.0f;
    const float k_Drag = 10.0f;
    const float k_AngularDrag = 5.0f;
    const float k_Distance = 0.01f; //was 0.2f
    const float scrollSpeed = 0.2f; //increment at which object distance (from player) is changed per scrollwheel movement
    const float rotateSpeed = 2.6f; //multiplier by which object rotate when R is held

    private SpringJoint m_SpringJoint;

    private void Update()
    {
        // Make sure the user pressed the mouse down
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        var mainCamera = FindCamera();
        
        // We need to actually hit an object
        RaycastHit hit = new RaycastHit();
        if (!Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition).origin,
            mainCamera.ScreenPointToRay(Input.mousePosition).direction, out hit, 5,
            Physics.DefaultRaycastLayers))
        {
            return;
        }

        // We need to hit a rigidbody that is not kinematic
        if (!hit.rigidbody || hit.rigidbody.isKinematic)
        {
            return;
        }

        if (!m_SpringJoint)
        {
            var go = new GameObject("Rigidbody dragger");
            Rigidbody body = go.AddComponent<Rigidbody>();
            m_SpringJoint = go.AddComponent<SpringJoint>();
            body.isKinematic = true;
        }

        m_SpringJoint.transform.position = hit.transform.position; //was =hit.point
        m_SpringJoint.anchor = Vector3.zero;
        m_SpringJoint.spring = k_Spring;
        m_SpringJoint.damper = k_Damper;
        m_SpringJoint.maxDistance = k_Distance;
        m_SpringJoint.connectedBody = hit.rigidbody;

        StartCoroutine("DragObject", hit.distance);
    }

    private IEnumerator DragObject(float distance)
    {
        
        var oldDrag = m_SpringJoint.connectedBody.drag;
        var oldAngularDrag = m_SpringJoint.connectedBody.angularDrag;
        m_SpringJoint.connectedBody.drag = k_Drag;
        m_SpringJoint.connectedBody.angularDrag = k_AngularDrag;
        var mainCamera = FindCamera();

        while (Input.GetMouseButton(0))
        {
            m_SpringJoint.connectedBody.freezeRotation = true;

            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            m_SpringJoint.transform.position = ray.GetPoint(distance);
            yield return null;

            if (distance > 5f)
            {
                distance = 5f;
            }
            if (distance < 0.6f)
            {
                distance = 0.6f;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && distance <= 5f)
            {
                distance += scrollSpeed;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && distance >= 0.6f)
            {
                distance -= scrollSpeed;
            }

            if (Input.GetKey(KeyCode.R))
            {
                mainCamera.transform.parent.gameObject.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0f;
                mainCamera.transform.parent.gameObject.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0f;
                m_SpringJoint.connectedBody.transform.RotateAround(m_SpringJoint.connectedBody.transform.position, mainCamera.transform.up, -(Input.GetAxis("Mouse X") * rotateSpeed));
                m_SpringJoint.connectedBody.transform.RotateAround(m_SpringJoint.connectedBody.transform.position, mainCamera.transform.right, Input.GetAxis("Mouse Y") * rotateSpeed);
            }
            else
            {
                mainCamera.transform.parent.gameObject.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 2f;
                mainCamera.transform.parent.gameObject.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 2f;
            }
        }
        mainCamera.transform.parent.gameObject.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 2f;
        mainCamera.transform.parent.gameObject.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 2f;
        m_SpringJoint.connectedBody.freezeRotation = false;

        if (m_SpringJoint.connectedBody)
        {
            m_SpringJoint.connectedBody.drag = oldDrag;
            m_SpringJoint.connectedBody.angularDrag = oldAngularDrag;
            m_SpringJoint.connectedBody = null;
        }
    }

    private Camera FindCamera()
    {
        if (GetComponent<Camera>())
        {
            return GetComponent<Camera>();
        }
        return Camera.main;
    }
}
