using System.Collections;
using System.Collections.Generic;
using Hirame.Minerva;
using UnityEngine;

public class ShowGlobal : MonoBehaviour
{
   public GlobalValueBase Global;
   public TMPro.TMP_Text Text;
   
   private void Update ()
   {
      Text.text = Global.ToString ();
   }
}
