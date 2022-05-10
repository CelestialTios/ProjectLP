using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        public Text nameText;
        public Text dialogText;
        public Canvas dialogCanvas;

        public Queue<string> sentences;

        // Use this for initialization
        void Start()
        {
            dialogCanvas.enabled = false;
            sentences = new Queue<string>();
        }

        public void StartDialogue(Dialogue dialogue)
        {
            sentences.Clear();                                  // Clear the queue
            dialogCanvas.enabled = true;
            nameText.text = dialogue.name;

            foreach (string sentence in dialogue.sentences)      // Add at the end of the queue the sentence
            {
                sentences.Enqueue(sentence);
            }

            NextDialogueSentence();
        }

        public void NextDialogueSentence()
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            string sentence = sentences.Dequeue();
            dialogText.text = sentence;
            //StopCoroutine();
            //StartCoroutine(TypeSentence(sentence));
        }

        /// <summary>
        /// Function to type each letter in the sentence with little delay to make it like robot text
        /// </summary>
        /// <param name="sentence"> Sentence to type</param>
        /// <returns></returns>
        IEnumerator TypeSentence(string sentence)
        {
            dialogText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogText.text += letter;
                yield return null;
            }
        }

        public void EndDialogue()
        {
            dialogCanvas.enabled = false;
            sentences.Clear();
        }
    }
}