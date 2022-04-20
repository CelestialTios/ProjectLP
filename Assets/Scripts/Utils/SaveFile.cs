using Assets.Scripts.Player;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public static class SaveFile
    {
        /// <summary>
        /// This function save data of a player into a bin file.<br/>
        /// data is as Character class.
        /// </summary>
        public static void Save(string nameFile, Character data) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/" + nameFile + ".bin";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData player = new PlayerData(data);

            //Write binary
            formatter.Serialize(stream, player);
            stream.Close();
        }

        /// <summary>
        /// This function save parameter of user.
        /// </summary>
        /// Need to make it for parameter class
        public static void Save(string nameFile)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/" + nameFile + ".bin";
            FileStream stream = new FileStream(path, FileMode.Create);


            //Write binary
            //formatter.Serialize(stream, player);
            stream.Close();
        }
    }
}
