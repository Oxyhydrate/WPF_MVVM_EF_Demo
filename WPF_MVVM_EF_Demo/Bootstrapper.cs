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
using System.Diagnostics;
using Demo.UI.Helpers;
using System.Windows.Controls;
using System.Data.Entity;
using Demo.Data;

namespace Demo.UI
{
    public class Bootstrapper : BootstrapperBase
    {
        //caliburn micro контейнер 
        private readonly SimpleContainer _container = new SimpleContainer();

        public ShellViewModel ShellViewModel { get; set; }

        public Bootstrapper()
        {
            Initialize();
            ConventionManager.AddElementConvention<PasswordBox>(PasswordBoxHelper.BoundPasswordProperty,"Password","PasswordChanged");
            //HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize(); //ef profiler
            //DbConfiguration.SetConfiguration(EntityFrameworkConfiguration.Instance);
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            return _container.GetInstance(serviceType, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
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

            base.Configure();
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.Singleton<ShellViewModel>();

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(Type => Type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType));
           // _container.PerRequest<LoginDBViewModel>(); // Регистрирую вм окна аутентификации, выше зарегистрировал все вм
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            try
            {
                base.OnStartup(sender, e);
                DisplayRootViewFor<ShellViewModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
            
        }
    }
}
