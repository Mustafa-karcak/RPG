using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace RPG.portal
{
    public class CanvasFader : MonoBehaviour
    {
        CanvasGroup canvasGroup;


        private void Start()
        {

            canvasGroup = GetComponent<CanvasGroup>();
           
        }
       


        public  IEnumerator canvasart�r(float time)
        {
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime / time;
                yield return null;
            }
        }
        public IEnumerator canvasazalt(float time)
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime / time;
                yield return null;
            }
        }

    }
}

