using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class DialogueTrigger : MonoBehaviour
    {

        public Dialogue dialogue;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }
}