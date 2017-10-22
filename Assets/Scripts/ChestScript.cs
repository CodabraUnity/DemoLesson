using UnityEngine;
using UnityEngine.UI;

namespace Codabra.Demo
{
    public class ChestScript : MonoBehaviour
    {
        private Animator _animator;
        private bool _isWin = false;
        [SerializeField]
        private string _winText = "You Win!";
        private GUIStyle _style = new GUIStyle();

        private void Start()
        {
            _animator = transform.Find("Treasure_Chest_Up").GetComponent<Animator>();
            _style.fontSize = 24;
            _style.alignment = TextAnchor.UpperCenter;
            _style.font = (Font)Resources.Load("Fonts/Badaboom");
            _style.fontSize = 100;
            _style.normal.textColor = Color.white;
        }

        public void Open()
        {
            _isWin = true;
            _animator.SetBool("Open", true);
        }

        private void OnGUI()
        {
            if (_isWin)
                GUI.Label(new Rect((Screen.width) / 2 - (Screen.width) / 8, (Screen.height) / 6, (Screen.width) / 4, (Screen.height) / 4), _winText, _style);
        }
    }
}