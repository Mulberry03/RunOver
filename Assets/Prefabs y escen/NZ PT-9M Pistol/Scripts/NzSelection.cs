using UnityEngine;
using UnityEngine.UI;

namespace NzBulletLookDev
{
    public class NzSelection : MonoBehaviour
    {
        [SerializeField] private Button previousButton;
        [SerializeField] private Button nextButton;
        private int currentModel;
    
        private void Awake()
        {
            SelectModel(0);
        }
    
        private void SelectModel(int _index)
        {
            previousButton.interactable = (_index != 0);
            nextButton.interactable = (_index != transform.childCount-1);
    
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(i == _index);
            }
        }
    
        public void ChangeModel(int _change)
        {
            currentModel += _change;
            SelectModel(currentModel);
        }
    }
}
