using Android.App;
using Android.Widget;
using Android.OS;
using Android.Net.Http;

using System.Net.Http;
using System.IO;
using Android.Graphics;
using System.Json;

using OxyPlot;
using OxyPlot.Xamarin.Android;

/*...*/
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
/*...*/
using System.Threading.Tasks;

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
        PlotModel pm1;


        
        
        private PlotModel CreatePlotModel()
        {
            var plotModel = new PlotModel { Title = "OxyPlot Demo" };

            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            series1.Points.Add(new DataPoint(0.0, 6.0));
            series1.Points.Add(new DataPoint(1.4, 2.1));
            series1.Points.Add(new DataPoint(2.0, 4.2));
            series1.Points.Add(new DataPoint(3.3, 2.3));
            series1.Points.Add(new DataPoint(4.7, 7.4));
            series1.Points.Add(new DataPoint(6.0, 6.2));
            series1.Points.Add(new DataPoint(8.9, 8.9));

            plotModel.Series.Add(series1);

            return plotModel;
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            HttpClient client = new HttpClient();
            PlotView view = FindViewById<PlotView>(Resource.Id.plot_view);
            view = FindViewById<PlotView>(Resource.Id.plotView1);
            


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
            var dostuff = Task.Factory.StartNew(() => { txtv1.Text = "from thread"; });

            view.Model = CreatePlotModel();


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

