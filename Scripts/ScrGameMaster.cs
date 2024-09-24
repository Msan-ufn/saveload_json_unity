using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


using System.IO;

using UnityEngine.UI;
using TMPro;
using System.Xml.Serialization;
using JetBrains.Annotations;
using System;
using UnityEditor.Experimental.GraphView;


public class ScrGameMaster : MonoBehaviour
{
    public GameObject PreviousItemInteracted = null;//var object interacted previously    
    public GameObject ItemHoldingNow; //var item holding now

    string filePath = Path.Combine(Application.streamingAssetsPath, "savegame.xml");


    //var key 1 = ClassGhostKey
    //var key 2

    //public List<GameObject> itemList;
    public Transform slv_player;
    public GameObject slv_smallbox;
    public GameObject slv_bigbox;
    public GameObject slv_ball;
    public GameObject slv_caixa_instrumental;
    private sclass_savejson slv_save_individual = new sclass_savejson();


    // GameMaster will be holding flags
    void Start()
    {
        slv_save_individual.slv_name = "player_save_info";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            


            slv_save_individual.slv_pos_x = slv_player.position.x;
            slv_save_individual.slv_pos_y = slv_player.position.y;
            slv_save_individual.slv_pos_z = slv_player.position.z;


            
            slv_save_individual.slv_player_is_visible = true;
            //

            slv_save_individual.slv_smallbox_visible = slv_smallbox.GetComponent<MeshRenderer>().enabled;
            slv_save_individual.slv_bigbox_visible = slv_bigbox.GetComponent<MeshRenderer>().enabled;
            slv_save_individual.slv_smallbox_visible = slv_ball.GetComponent<MeshRenderer>().enabled;
            slv_save_individual.slv_caixa_instrumental_visible = slv_caixa_instrumental.GetComponent<MeshRenderer>().enabled;


            string svar_json_string = "";
            string svar_filepath_string = Path.Combine(Application.streamingAssetsPath, slv_save_individual.slv_name + ".json");
            



            print("p");//SAVE CALL GOES HERE

            if (!Directory.Exists(Application.streamingAssetsPath))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath);
            }

            if (!File.Exists(svar_filepath_string))
            {
                
                svar_json_string = JsonUtility.ToJson(slv_save_individual);
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(svar_filepath_string))
                {
                    file.WriteLine(svar_json_string);
                }
            }
            else
            {
                File.Delete(Application.streamingAssetsPath + "/" + slv_save_individual.slv_name + ".json");
                svar_json_string = JsonUtility.ToJson(slv_save_individual);
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(svar_filepath_string))
                {
                    file.WriteLine(svar_json_string);
                }
            }


            /// xml     \/
            /*
           if (!Directory.Exists(filePath))
           {
               Directory.CreateDirectory(Application.streamingAssetsPath);

               print(Directory.CreateDirectory(Application.streamingAssetsPath));
           }
           //if(!File.Exists(filePath)) 
           {
              /* 
               XmlSerializer serializer = new XmlSerializer (typeof(SaveGame));
               StreamWriter streamWriter = new StreamWriter( filePath );
               serializer.Serialize( streamWriter.BaseStream , slv_save_game );
               streamWriter.Close();

               print("saved");
           }*/
            //============

        }
        else if(Input.GetKeyDown(KeyCode.L)) 
        {
            print("l");

            try
            {
                
                string svar_json_string = System.IO.File.ReadAllText(
                    Application.streamingAssetsPath + "/" + slv_save_individual.slv_name + ".json");

                sclass_savejson svar_player_load = JsonUtility.FromJson<sclass_savejson>(svar_json_string);


                slv_player.position = new Vector3(svar_player_load.slv_pos_x, svar_player_load.slv_pos_y, svar_player_load.slv_pos_z);

                print(svar_player_load.slv_pos_x);

                slv_smallbox.GetComponent<MeshRenderer>().enabled = svar_player_load.slv_smallbox_visible;
                slv_bigbox.GetComponent<MeshRenderer>().enabled = svar_player_load.slv_bigbox_visible;
                slv_ball.GetComponent<MeshRenderer>().enabled = svar_player_load.slv_smallbox_visible;
                slv_caixa_instrumental.GetComponent<MeshRenderer>().enabled = svar_player_load.slv_caixa_instrumental_visible;


                slv_smallbox.GetComponent<Collider>().enabled = svar_player_load.slv_smallbox_visible;
                slv_bigbox.GetComponent<Collider>().enabled = svar_player_load.slv_bigbox_visible;
                slv_ball.GetComponent<Collider>().enabled = svar_player_load.slv_smallbox_visible;
                slv_caixa_instrumental.GetComponent<Collider>().enabled = svar_player_load.slv_caixa_instrumental_visible;
                /*
                if (svar_user.password == senha.text)
                {
                    print("bemvindo");
                }
                else
                {
                    print("Senha bugada");
                }*/
            }
            catch (Exception ex)
            {

            }
            



            /*
            XmlSerializer serializer = new XmlSerializer(typeof(SaveGame));
            StreamReader reader = new StreamReader(filePath);
            SaveGame slv_saved_game = (SaveGame)serializer.Deserialize(reader.BaseStream);

            //slv_player.position = new Vector3(slv_saved_game.slv_pos_x, slv_saved_game.slv_pos_y, slv_saved_game.slv_pos_z);


            /*slv_smallbox.GetComponent<MeshRenderer>().enabled = slv_saved_game.slv_smallbox_visible;
            slv_bigbox.GetComponent<MeshRenderer>().enabled = slv_saved_game.slv_bigbox_visible;
            slv_ball.GetComponent<MeshRenderer>().enabled = slv_saved_game.slv_smallbox_visible;
            slv_caixa_instrumental.GetComponent<MeshRenderer>().enabled = slv_saved_game.slv_caixa_instrumental_visible;


            slv_smallbox.GetComponent<Collider>().enabled = slv_saved_game.slv_smallbox_visible;
            slv_bigbox.GetComponent<Collider>().enabled = slv_saved_game.slv_bigbox_visible;
            slv_ball.GetComponent<Collider>().enabled = slv_saved_game.slv_smallbox_visible;
            slv_caixa_instrumental.GetComponent<Collider>().enabled = slv_saved_game.slv_caixa_instrumental_visible;
            
            reader.Close();
            */

        }


    }

    public void MeshTurnOff(GameObject ItemToTurnOff)
    {
        
        
        
        ItemToTurnOff.GetComponent<MeshRenderer>().enabled = false;
        ItemToTurnOff.GetComponent<Collider>().enabled = false;


        ItemHoldingNow = ItemToTurnOff;

        //if(PreviousItemInteracted!=null&& PreviousItemInteracted!= ItemHoldingNow) PreviousItemInteracted.GetComponent<MeshRenderer>().enabled = true;
        PreviousItemInteracted = ItemToTurnOff;
        

    }



}





/*using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml.Serialization;
using JetBrains.Annotations;

public class Xml : MonoBehaviour
{

    string filePath = Path.Combine(Application.streamingAssetsPath, "usuarios.xml");

    public TextMeshProUGUI login;
    public TextMeshProUGUI senha;

    public void gravar()
    {
        //string filePath = Path.Combine(Application.streamingAssetsPath,"usuarios.xml");
        
        List<Usuario> lista = new List<Usuario>();

        Usuario usuario = new Usuario();
        usuario.login = login.text;
        usuario.senha = senha.text;

        print(usuario.login);

        lista.Add(usuario);

        if(!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);

            print(Directory.CreateDirectory(Application.streamingAssetsPath));
        }
        if(!File.Exists(filePath)) 
        {
            XmlSerializer serializer = new XmlSerializer (typeof(List<Usuario>));
            StreamWriter streamWriter = new StreamWriter( filePath );
            serializer.Serialize( streamWriter.BaseStream , lista );
            streamWriter.Close();
        }
        else
        {

            XmlSerializer serializer = new XmlSerializer (typeof(List<Usuario>));
            StreamReader reader = new StreamReader( filePath );
            List<Usuario> listaDeserializada = (List<Usuario>)serializer.Deserialize( reader.BaseStream );
            reader.Close();
            
            foreach (Usuario item in listaDeserializada) 
            {
                if(usuario.login == item.login) 
                {
                    print("ousuario " + usuario.login + " ja possui cadastro");
                    return; //encerra o metodo 'gravar' 
                }
            }
            listaDeserializada.Add(usuario);

            StreamWriter writer= new StreamWriter( filePath );
            serializer.Serialize(writer.BaseStream, listaDeserializada );
            writer.Close(); 
                        
        }

    }

    public void excluir()
    {
        File.Delete(filePath);
    }

    public void read()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Usuario>));
        StreamReader reader = new StreamReader( filePath );
        List<Usuario> usuario = (List<Usuario>)serializer.Deserialize( reader.BaseStream );
        reader.Close();

        foreach (Usuario item in usuario ) 
        {
            print (item.login);
        }
    }




   
}
*/