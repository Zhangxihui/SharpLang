using UnityEngine;
using System.Collections;
using System.IO;

public class CustomScriptTemplate : UnityEditor.AssetModificationProcessor
{
    /// <summary>  
    /// 此函数在asset被创建完，文件已经生成到磁盘上，但是没有生成.meta文件和import之前被调用  
    /// 需要编辑 Unity安装目录\Editor\Data\Resources\ScriptTemplates\81-C# Script-NewBehaviourScript.cs.txt
    /// </summary>  
    /// <param name="newFileMeta">newfilemeta 是由创建文件的path加上.meta组成的</param>  
    public static void OnWillCreateAsset(string newFileMeta)
    {
        string newFilePath = newFileMeta.Replace(".meta", "");
        string fileExt = Path.GetExtension(newFilePath);
        if (fileExt != ".cs")
        {
            return;
        }
        //注意，Application.datapath会根据使用平台不同而不同  
        string realPath = Application.dataPath.Replace("Assets", "") + newFilePath;
        string scriptContent = File.ReadAllText(realPath);

        //这里实现自定义的一些规则  
        scriptContent = scriptContent.Replace("_SCRIPTNAME", Path.GetFileName(newFilePath));
        scriptContent = scriptContent.Replace("_CompanyName", "HERO-CYYD");
        scriptContent = scriptContent.Replace("_Author", "xihui.zhang");
        scriptContent = scriptContent.Replace("_Version", "1.0");
        scriptContent = scriptContent.Replace("_UnityVersion", Application.unityVersion);
        scriptContent = scriptContent.Replace("_CreateTime", System.DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss"));

        File.WriteAllText(realPath, scriptContent);
    }
}

///****************************************************
// * FileName:		#SCRIPTNAME#
// * CompanyName:		#CompanyName#
// * Author:			#Author#
//  * CreateTime:		#CreateTime#
// * Version:			#Version#
// * UnityVersion:	#UnityVersion#
// * Description:		#手动添加#
// * 
//*****************************************************/
////using System.Collections;
////using System.Collections.Generic;
////using UnityEngine;

////public class #SCRIPTNAME# : MonoBehaviour
////{
////    // Start is called before the first frame update
////    void Start()
////{
////# NOTRIM#
////}

////// Update is called once per frame
////void Update()
////{
////# NOTRIM#
////}
////}
