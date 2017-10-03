using Android.App;
using Android.Widget;
using Android.OS;
using Android.Net.Http;

using System.Net.Http;
using System.IO;
using Android.Graphics;
using System.Json;




namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        TextView txtv1;
        TextView txtv2;
        Button b2;
        ImageView view1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            HttpClient client = new HttpClient();





            //init UI 
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
            txtv1 = FindViewById<TextView>(Resource.Id.textView1);
            txtv2 = FindViewById<TextView>(Resource.Id.textView2);
            b2 = FindViewById<Button>(Resource.Id.button1);
            view1 = FindViewById<ImageView>(Resource.Id.imageView1);


            var t = 5;
            t++;


            //variables
            Stream stream;
            Bitmap bmp1;
            JsonValue value = JsonValue.Parse(
                       "{" +
                               "\"Library\" : \"System.Json for .NET\"," +
                               "\"Author\" : { " +
                                            "\"Name\" : \"Bourassi Mohamed\"," +
                                            "\"Age\" : 24," +
                                            "\"Blog\" : \"bourassi_med89@yahoo\"" +
                             "}," +
                               "\"Date\" : \"31/07/2013\"," +
                               "\"Tags\" : [\"Json\",\"C#\",\".NET\"]" +
                               "}"

                    );

 /*
             "{" +
                               "\"Library\" : \"System.Json for .NET\"," +
                               "\"Author\" : { " +
                                            "\"Name\" : \"Bourassi Mohamed\"," +
                                            "\"Age\" : 24," +
                                            "\"Blog\" : \"bourassi_med89@yahoo\"" +
                             "}," +
                               "\"Date\" : \"31/07/2013\"," +
                               "\"Tags\" : [\"Json\",\"C#\",\".NET\"]" +
                               "}"
                               
             
             */


            if (value.ContainsKey("Library"))
            {
                txtv1.Text = "field found ";

            }



            //runnable code 
            stream = client.GetStreamAsync("https://i.imgur.com/OVXxVoA.jpg").Result;
            bmp1 = BitmapFactory.DecodeStream(stream);
            view1.SetImageBitmap(bmp1);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            b2.Click += B2_Click;
        }

        private void B2_Click(object sender, System.EventArgs e)
        {
            txtv1.Text += " moar";
        }
    }
}

