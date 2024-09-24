using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting.FullSerializer;


public class sclass_json : MonoBehaviour
{
    /*
    // Start is called before the first frame update
    public Text nome;
    public Text senha;
    
    public void gravar()
    {
        sclass_user svar_user = new sclass_user();
        svar_user.login = nome.text;
        svar_user.password = senha.text;

        print("login: "+ svar_user.login);
        print("senha: " + svar_user.password);


        string svar_json_string = "";
        string svar_filepath_string = Path.Combine(Application.streamingAssetsPath,svar_user.login +".json");

        print(svar_filepath_string);

        if(!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }

        if(!File.Exists(svar_filepath_string))
        {
            svar_json_string = JsonUtility.ToJson(svar_user);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(svar_filepath_string))
            {
                file.WriteLine(svar_json_string);
            }
        }

    }
    public void ler()
    {
        try
        {
            string svar_json_string = System.IO.File.ReadAllText(
                Application.streamingAssetsPath + "/" + nome.text + ".json");

            sclass_user svar_user = JsonUtility.FromJson<sclass_user>(svar_json_string);

            if(svar_user.password == senha.text)
            {
                print("bemvindo");
            }
            else
            {
                print("Senha bugada");
            }
        }
        catch (Exception ex)
        {

        }


    }
    public void lerDiretorio()
    {
        DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);
        foreach (FileInfo file in di.GetFiles())
        {
            print(file.Name);
        }
    }
    public void apagar()
    {
        File.Delete(Application.streamingAssetsPath+"/"+nome.text+".json");
    }*/
}

    