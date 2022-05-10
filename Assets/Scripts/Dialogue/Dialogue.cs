using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Dialogue
{
    [Serializable]
    public class Dialogue
    {
        public string name;
        [TextArea(2, 8)]
        public string[] sentences;
    }
}