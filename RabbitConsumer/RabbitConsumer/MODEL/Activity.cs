using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RabbitConsumer.MODEL
{
    public class Activity
    {
        public int id { get; set; }
        public string activity { get; set; }
        public string type { get; set; }
        public int participants { get; set; }
        public float price { get; set; }
        public string link { get; set; }
        public string key { get; set; }
        public double accessibility { get; set; }

        public void ShowActivity(Activity activity)
        {
            Console.WriteLine(
                "activity: " + activity.activity + Environment.NewLine +
                "type: " + activity.type + Environment.NewLine +
                "participants: " + activity.participants + Environment.NewLine +
                "price: " + activity.price + Environment.NewLine +
                "link: " + activity.link + Environment.NewLine +
                "key: " + activity.key + Environment.NewLine +
                "accessibility: " + activity.accessibility + Environment.NewLine
                );
        }
    }
}
