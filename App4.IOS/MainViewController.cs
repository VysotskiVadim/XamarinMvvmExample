using System;
using System.Collections.Generic;
using System.Text;
using App4.Core.ViewModels;
using Cirrious.FluentLayouts.Touch;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.Unity;
using UIKit;

namespace App4.IOS
{
    public class MainViewController : UIViewController
    {

        private Binding _textBindig;

        protected ViewModel ViewModel { get; }

        protected UILabel Text { get; set; }

        protected UIButton Button { get; set; }


        public MainViewController()
        {
            ViewModel = ServiceLocator.Container.Resolve<ViewModel>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitViews();
            InitConstraints();
            SetBindings();
        }


        private void InitViews()
        {
            Text = new UILabel
            {
                TextColor = UIColor.Red,
                Font = UIFont.SystemFontOfSize(100),
                TextAlignment = UITextAlignment.Center,
                Text = "0"
            };
            Text.SizeToFit();

            Button = new UIButton(UIButtonType.System)
            {
                Font = UIFont.SystemFontOfSize(30)
            };
            Button.SetTitle("Start", UIControlState.Normal);
            View.BackgroundColor = UIColor.White;
            View.AddSubviews(Text, Button);
        }

        private void InitConstraints()
        {
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            View.AddConstraints(
                Button.CenterX().EqualTo().CenterXOf(View),
                Button.Top().EqualTo().CenterYOf(View).Plus(10),
                
                Text.AtLeftOf(View),
                Text.AtRightOf(View),
                Text.Bottom().EqualTo().CenterYOf(View).Minus(10)
                );
        }

        private void SetBindings()
        {
            Button.SetCommand("TouchUpInside", ViewModel.StartCommand);
            _textBindig = this.SetBinding(() => ViewModel.Number, () => Text.Text).ConvertSourceToTarget(i => i.ToString());
        }
    }
}
