using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;
using Urho.Gui;

namespace FormsSample
{
    public class HelloWorld : Application
    {
        public HelloWorld(ApplicationOptions options) : 
            base(options)
        {
        }
        Text helloText;
        float r = 0;
        protected override void OnUpdate(float timeStep)
        {
            base.OnUpdate(timeStep);
            helloText.SetColor(new Color(r, 0, 0, 1));
            r += (0.1f * timeStep);
            if (r >= 1.0f)
                r = 0;
        }

        protected override void Start()
        {
            var cache = ResourceCache;
            helloText = new Text()
            {
                Value = "Hello World from UrhoSharp",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            helloText.SetColor(new Color(0f, 1f, 0f));
            helloText.SetFont(font: cache.GetFont("Fonts/Anonymous Pro.ttf"), size: 30);
            UI.Root.AddChild(helloText);
        
            //Graphics.SetWindowIcon(cache.GetImage("Textures/UrhoIcon.png"));
            Graphics.WindowTitle = "UrhoSharp Sample";

            // Subscribe to Esc key:
            Input.SubscribeToKeyDown(args => { if (args.Key == Key.Esc) Exit(); });
        }
    }
}
