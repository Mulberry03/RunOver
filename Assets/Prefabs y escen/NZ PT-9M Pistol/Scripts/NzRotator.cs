using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NzBulletLookDev
{
    public class NzRotator : MonoBehaviour
    {

        public AudioClip Explode_Sound;
        public AudioClip Recall_Sound;
        public AudioSource Audio;
    
        public float ExplodeSpeed;
        public bool IsExplode = false;

        Quaternion pointA;
        public Quaternion pointB;

        private void Start() 
        {
            pointA = transform.rotation;
            
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
      
         IEnumerator MoveObject(Transform thisTransform, Quaternion startPos, Quaternion endPos, float time)
         {
             var i= 0.0f;
             var rate= 1.0f/time;
             while (i < 1.0f) {
                 i += Time.deltaTime * rate;
                 thisTransform.rotation = Quaternion.Lerp(startPos, endPos, i);
                 yield return null; 
             }
         }
     
    }
}
