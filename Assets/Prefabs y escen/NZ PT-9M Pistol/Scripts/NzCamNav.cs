using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace NzBulletLookDev
{
    public class NzCamNav : MonoBehaviour
    {
        public Transform target;
        public float orbitSpeed = 15f;
        public float zoomSpeed = 10f;
        private Vector3 targetOffset = Vector3.zero;
        private Vector3 targetPosition;
    
    
        // Use this for initialization
        void Start() {
            if (target != null) transform.LookAt(target);
        }
    
    
    
        void Update() {
            targetPosition = target.position + targetOffset;
    
    
            if (target != null) {
                targetPosition = target.position + targetOffset;
    
                // Left Mouse to Orbit
                if (Input.GetMouseButton(0)) {
                    transform.RotateAround(targetPosition, Vector3.up, Input.GetAxis("Mouse X") * orbitSpeed);
                    float pitchAngle = Vector3.Angle(Vector3.up, transform.forward);
                    float pitchDelta = -Input.GetAxis("Mouse Y") * orbitSpeed;
                    float newAngle = Mathf.Clamp(pitchAngle + pitchDelta, 0f, 180f);
                    pitchDelta = newAngle - pitchAngle;
                    transform.RotateAround(targetPosition, transform.right, pitchDelta);
                }
    
                // Scroll to Zoom
                transform.position += transform.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
    
            }
        }
    }
}
