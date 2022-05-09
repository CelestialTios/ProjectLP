using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Dialogue
    {
        public string name;
        [TextArea(2, 8)]
        public string[] sentences;
    }
}