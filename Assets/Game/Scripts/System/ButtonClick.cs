using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameJam.System
{
    public class ButtonClick : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] int loadIndex;
        [SerializeField] bool isQuit = false;
        public void OnPointerClick(PointerEventData eventData)
        {
            if(isQuit)
                SceneLoader.GetInstance().Quit();
            SceneLoader.GetInstance().LoadScene(loadIndex);
        }

    }

}
