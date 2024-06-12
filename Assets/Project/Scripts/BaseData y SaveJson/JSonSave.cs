using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

public class JSonSave : MonoBehaviour
{
    #region variables
    public int highscorePatos;
    public int highscorePiratas ;
    public int monedas ;
    #endregion
    #region methods
    public static JSonSave Singleton
    {
        get
            {
                if (instance == null)
                    {
                      instance = FindAnyObjectByType(typeof(JSonSave)) as JSonSave;
                    }
                return instance;
            }
            set
            {
              instance = value;
            }
    }
    private static JSonSave instance;
    public class SaveData
    {

        public int SaveDucks;
        public int SavePirates;
        public int monedasSave;

        public SaveData(int _hsc,int _hsp, int _coin)
        {
            SaveDucks = _hsc;
            SavePirates = _hsp;
            monedasSave = _coin;
        }
    }

    public void SaveHS()
    {
        if(Timer.Singleton.endGame == true)

        { 
           if(SceneManager.GetActiveScene().name == "DuckShots")
                {
                    highscorePatos = ScoreManager.Singleton.actualScore;
                }
            if (SceneManager.GetActiveScene().name == "PirateShots")
                {
                    highscorePiratas = ScoreManagerPirates.Singleton.actualScore;
                }
            SaveData sd = new SaveData(highscorePatos,highscorePiratas, monedas);

            JObject jSaveGame = new JObject();
            string jsonString = JsonUtility.ToJson(sd);
            string saveFilePath = Application.persistentDataPath + "/CarnivalSave.sav";
            StreamWriter sw = new StreamWriter(saveFilePath);
            Debug.Log("Saving to: " + saveFilePath);
            sw.WriteLine(jsonString);
            sw.Close();

            //byte[] encryptSavegame = Encrypt(jSaveGame.ToString());
           
            //File.WriteAllBytes(saveFilePath, encryptSavegame);
            
            //Debug.Log("Saving to: " + saveFilePath);
        }

    }

    public void LoadHS()
    {
        string saveFilePath = Application.persistentDataPath + "/CarnivalSave.sav";
        Debug.Log("Loading from: " + saveFilePath);
        StreamReader sr = new StreamReader(saveFilePath);
        string jsonString = sr.ReadToEnd();
        sr.Close();
        SaveData sd = JsonUtility.FromJson<SaveData>(jsonString);

        highscorePatos = sd.SaveDucks;
        highscorePiratas = sd.SavePirates;
        monedas = sd.monedasSave;

        //byte[] decryptedSavegame = File.ReadAllBytes(saveFilePath);
        
        //string jSonString00 = Decrypt(decryptedSavegame);
    }

    //byte[] _key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

    //byte[] _initializationVector = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };


    //byte[] Encrypt(string message)
    //{
    //    AesManaged aes = new AesManaged();
    //    ICryptoTransform encryptor = aes.CreateEncryptor(_key, _initializationVector);
    //    MemoryStream memoryStream = new MemoryStream();
    //    CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

    //    StreamWriter streamWriter = new StreamWriter(cryptoStream);
    //    streamWriter.WriteLine(message);
    //    streamWriter.Close();
    //    cryptoStream.Close();
    //    memoryStream.Close();
    //    return memoryStream.ToArray();
    //}

    //string Decrypt(byte[] message)
    //{
    //    AesManaged aes = new AesManaged();
    //    ICryptoTransform decrypter = aes.CreateDecryptor(_key, _initializationVector);
    //    MemoryStream memoryStream = new MemoryStream(message);
    //    CryptoStream cryptoStream = new CryptoStream(memoryStream, decrypter, CryptoStreamMode.Read);
    //    StreamReader streamReader = new StreamReader(cryptoStream);
    //    string decryptedMessage = streamReader.ReadToEnd();
    //    streamReader.Close();
    //    cryptoStream.Close();
    //    memoryStream.Close();
    //    return decryptedMessage;
    //}
    #endregion
}
