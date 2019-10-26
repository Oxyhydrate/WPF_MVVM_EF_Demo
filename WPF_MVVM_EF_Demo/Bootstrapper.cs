using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Demo.UI.ViewModels;
using Caliburn.Micro;
using Demo.UI.Input;
using System.Windows.Input;

namespace Demo.UI
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
        }
        protected override void Configure()
        {
            var defaultCreateTrigger = Parser.CreateTrigger;

            Parser.CreateTrigger = (target, triggerText) =>
            {
                if (triggerText == null)
                {
                    return defaultCreateTrigger(target, null);
                }

                var triggerDetail = triggerText
                    .Replace("[", string.Empty)
                    .Replace("]", string.Empty);

                var splits = triggerDetail.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

                switch (splits[0])
                {
                    case "Key":
                        var key = (Key)Enum.Parse(typeof(Key), splits[1], true);
                        return new KeyTrigger { Key = key };

                    case "Gesture":
                        var mkg = (MultiKeyGesture)(new MultiKeyGestureConverter()).ConvertFrom(splits[1]);
                        return new KeyTrigger { Modifiers = mkg.KeySequences[0].Modifiers, Key = mkg.KeySequences[0].Keys[0] };
                }

                return defaultCreateTrigger(target, triggerText);
            };
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
