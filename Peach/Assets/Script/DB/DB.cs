using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Data;
using System.Text;
using Mono.Data.SqliteClient;


public class DB : MonoBehaviour {

	private string connection;
	private IDbConnection dbcon;
	private IDbCommand dbcmd;
	private IDataReader reader;
	private StringBuilder builder;

	public void OpenDB(string path){
		try{
			
			#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
			string filePath = Application.streamingAssetsPath + "/" + path;
			#else
			string filePath = Application.persistentDataPath + "/" + path;
			#endif

			if (!File.Exists (filePath)) {
				#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
					WWW localDB = new WWW ("file://" + Application.dataPath + "!/assets/" + path);
				#else
					WWW localDB = new WWW ("jar:file://" + Application.dataPath + "!/assets/" + path);
				#endif

				while (!localDB.isDone) {}
				File.WriteAllBytes (filePath, localDB.bytes);
			}

			connection = "URI=file:" + filePath;
			Debug.Log("Stablishing connection to: " + connection);
			dbcon = new SqliteConnection(connection);
			dbcon.Open();
		}catch (Exception ex){
			Debug.Log ("Database Error : " + ex.ToString ());
		}
	}

	public void CloseDB()
	{
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbcon.Close();
		dbcon = null;
	}

	public IDataReader BasicQuery(string query)
	{
		dbcmd = dbcon.CreateCommand();
		dbcmd.CommandText = query;
		reader = dbcmd.ExecuteReader();
		return reader;
	}
		
	public ArrayList SearchData(string query)
	{
		dbcmd = dbcon.CreateCommand();
		dbcmd.CommandText = query;
		reader = dbcmd.ExecuteReader();

		ArrayList readArray = new ArrayList();
		while (reader.Read())
		{
			string[] row = new string[reader.FieldCount];
			int j = 0;
			while (j < reader.FieldCount)
			{
				row[j] = reader.GetString(j);
				j++;

			}
			readArray.Add(row);

			//Debug.Log(("ID : " + ((string[])readArray[0])[0]) +" , " + " Name : "+ ((string[])readArray[0])[1]);// +" , "+ " Value : " + ((string[])readArray[0])[2]);
		}
		string strArray = "";
		for ( int i = 0; i < readArray.Count; i++){
			strArray += " " + ((string[])readArray[i])[1];
		}
		return readArray;
	}

	public void SetDB(string query){
		try
		{
			dbcmd = dbcon.CreateCommand();
			dbcmd.CommandText = query;
			Debug.Log(query);
			reader = dbcmd.ExecuteReader();


		}
		catch (Exception ex){
			Debug.Log ("Set DB Error: " + ex.ToString ());
		}
	}

}
