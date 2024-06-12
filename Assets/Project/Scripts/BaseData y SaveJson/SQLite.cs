using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.IO;
using Mono.Data.Sqlite;
using System;

public class SQLite : MonoBehaviour
{
    #region var
    string rutaDB;
    string strConexion;
    
    string DBFileName = "BaseDatosCarnival.db";
    
    
    IDbConnection dbConnection;
    
    IDbCommand dbCommand;
    
    IDataReader reader;
    #endregion
    #region mehtods

    void OpenDB(string nombreDB)
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            rutaDB = Application.dataPath + "/StreamingAssets/" + nombreDB;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            rutaDB = Application.persistentDataPath + "/" + nombreDB;
            if (!File.Exists(rutaDB))
            {
                WWW loadDB = new WWW("jar;file://" + Application.dataPath + nombreDB);
                while (!loadDB.isDone){}
                File.WriteAllBytes(rutaDB, loadDB.bytes);
            }
        }
        strConexion = "URI=file:" + rutaDB;
        dbConnection = new SqliteConnection(strConexion);
        dbConnection.Open();
    }
    void CloseDB()
    {
        reader.Close();
        reader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }

    void ComandSelect(string item, string tabla)
    {
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = "SELECT " + item + " FROM " + tabla;
        dbCommand.CommandText = sqlQuery;

        reader = dbCommand.ExecuteReader();
        while (reader.Read())
        {
            try
            {
                Debug.Log(reader.GetInt32(0) + " - ");
            }
            catch (FormatException fe)
            {
                Debug.Log(fe.Message);
                continue;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                continue;
            }
        }
    }
    void INSERT(string tabla, int dato)
    {
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = String.Format("INSERT INTO \"{0}\"(Highscore) values(\"{1}\")", tabla, dato); //String.Format podemos pasarle datos a una cadena de caracteres para que tome el argumento
        dbCommand.CommandText = sqlQuery;
        dbCommand.ExecuteScalar();
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }
    
    public void Introducir (string tabla, int dato)
    {
        OpenDB("BaseDatosCarnival.db");
        INSERT(tabla, dato);
    }

    public void Select( string tabla)
    {
        OpenDB("BaseDatosCarnival.db");
        ComandSelect("*", tabla);
        CloseDB();
        Debug.Log("Prueba");
    }
    #endregion
}
