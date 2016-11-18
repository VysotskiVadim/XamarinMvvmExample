using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using App4.Core.ViewModels;
using GalaSoft.MvvmLight.Helpers;
using Java.Lang;
using Microsoft.Practices.Unity;

namespace App4
{
    [Activity(Label = "App4", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private TextView _textView;
        private Button _button;
        private readonly List<Binding> _bindigs = new List<Binding>();

        public ViewModel ViewModel { get; private set; }

        public TextView TextView => _textView ?? (_textView = FindViewById<TextView>(Resource.Id.text));
        public TextView Button => _button ?? (_button = FindViewById<Button>(Resource.Id.button));

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            InitViewModel();

            AddBinding(
                ViewModel.SetBinding(() => ViewModel.Number, this, () => TextView.Text)
                .ConvertSourceToTarget(n => n.ToString()));

            Button.SetCommand("Click", ViewModel.StartCommand);
        }

        public override Object OnRetainNonConfigurationInstance()
        {
            return new StateKeeper { ViewModel = ViewModel };
        }

        private void InitViewModel()
        {
            var state = LastNonConfigurationInstance as StateKeeper;
            ViewModel = state != null ? state.ViewModel : ServiceLocator.Container.Resolve<ViewModel>();
        }

        private void AddBinding(Binding bindig)
        {
            _bindigs.Add(bindig);
        }
    }
}
