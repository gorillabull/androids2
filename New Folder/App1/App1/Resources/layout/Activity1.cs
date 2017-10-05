using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1.Resources.layout
{
    [Activity(Label = "Activity1")]
    public class Activity1 : Activity
    {
        Button b1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
          //  base.OnCreate(savedInstanceState);
            b1 = FindViewById<Button>(Resource.Id.button2);



            // Create your application here
        }
    }
}