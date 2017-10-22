using UnityEngine;
using UnityEngine.UI;

namespace Codabra.Demo
{
    public class ChestScript : MonoBehaviour
    {
        private Animator _animator;
        private Text _text;
        [SerializeField]
        private string _winText = "You Win!";

        private void Start()
        {
            _animator = transform.Find("Treasure_Chest_Up").GetComponent<Animator>();
            _text = GameObject.FindGameObjectWithTag("Finish").GetComponent<Text>();
            _text.enabled = false;
        }

        public void Open()
        {
            _animator.SetBool("Open", true);
            _text.text = _winText;
            _text.enabled = true;
        }
    }
}