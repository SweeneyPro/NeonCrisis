using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Enemy_Prefab_Creator : EditorWindow
{

    string ship_name = "";
    string path = "Assets/Resources/Prefabs/Enemies";
    string folder_path;
    Sprite ship_sprite;
    float collider_radius;
    Color ship_tint = Color.white;

    [MenuItem("Tools/Enemy Prefab Creator")]
    static void Init()
    {
        Enemy_Prefab_Creator prefab_creator = (Enemy_Prefab_Creator)EditorWindow.GetWindow(typeof(Enemy_Prefab_Creator));
        prefab_creator.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Enemy Prefab Creator", EditorStyles.boldLabel);
        ship_name = EditorGUILayout.TextField("Enemy Name", ship_name);
        ship_sprite = (Sprite)EditorGUILayout.ObjectField("Ship Image", ship_sprite, typeof(Sprite), false);
        ship_tint = EditorGUILayout.ColorField("Ship Tint", ship_tint);
        collider_radius = EditorGUILayout.Slider("Circle Collider Radius", collider_radius, 0.25f, 5f);
        

        if (GUILayout.Button("Generate Enemy"))
        {
            Generate_Enemy();
        }
    }
    
    void Generate_Enemy()
    {
        string full_path = path + "/" + ship_name;
        if (ship_name == string.Empty)
        {
            EditorUtility.DisplayDialog("Enemy Creator Error", "Please select a name for the ship.", "OK");
        }
        else
        {
            //if folder using ship name does not exist
            if(!AssetDatabase.IsValidFolder(full_path))
            {
                AssetDatabase.CreateFolder(path, ship_name); //create folder
                if(ship_sprite == null) //if ship sprite has not been set
                {
                    EditorUtility.DisplayDialog("Enemy Creator Error", "No sprite selected.", "OK");
                }
                else //if ship sprite has been set
                {
                    GameObject ship_object = new GameObject(ship_name); //create object
                    //add components
                    SpriteRenderer renderer = ship_object.AddComponent<SpriteRenderer>(); //add sprite renderer to display ship
                    CircleCollider2D collider = ship_object.AddComponent<CircleCollider2D>(); //add collider to allow collision
                    Rigidbody2D rigidbody = ship_object.AddComponent<Rigidbody2D>(); //@NOTE this may not be necesarry

                    renderer.sprite = ship_sprite; //set ship sprite
                    renderer.color = ship_tint;
                    collider.radius = collider_radius; //set collider size
                    rigidbody.freezeRotation = true; //stop ship rotating when colliding

                    PrefabUtility.CreatePrefab(full_path + "/" + ship_name + ".prefab", ship_object); //create prefab
                    //create animation controller
                    UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath(full_path + "/" + ship_name + "_Animation_Controller.controller");
                    DestroyImmediate(ship_object);

                }
            }
            else //if folder using ship name exists
            {
                EditorUtility.DisplayDialog("Enemy Creator Error", "Ship name in use, choose another name.", "OK");
            }
        }

        
    }
        
}
