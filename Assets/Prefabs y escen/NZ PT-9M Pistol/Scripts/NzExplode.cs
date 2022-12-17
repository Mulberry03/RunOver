using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NzBulletLookDev
{
    public class NzExplode : MonoBehaviour
    {

        public AudioClip Explode_Sound;
        public AudioClip Recall_Sound;
        public AudioSource Audio;
    
        public float ExplodeSpeed;
        private bool IsExplode = false;

        
        

    
        Vector3 pointA;
        public Vector3 pointB;

        private void Start() 
        {
            pointA = transform.localPosition;
            
        }
        void Update()
         {

            if (Input.GetKeyDown(KeyCode.Space) && !IsExplode)
            {
                Audio.PlayOneShot(Explode_Sound); 
                StartCoroutine(MoveObject(transform, pointA, pointB, ExplodeSpeed));
                IsExplode = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && IsExplode)
            {
                Audio.PlayOneShot(Recall_Sound); 
                StartCoroutine(MoveObject(transform, pointB, pointA, ExplodeSpeed));
                IsExplode = false;
            

            }
         }
      
         IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
         {
             var i= 0.0f;
             var rate= 1.0f/time;
             while (i < 1.0f) {
                 i += Time.deltaTime * rate;
                 thisTransform.localPosition = Vector3.Lerp(startPos, endPos, i);
                 yield return null; 
             }
         }
     
    }
}
