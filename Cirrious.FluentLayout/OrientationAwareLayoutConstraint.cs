using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace Cirrious.FluentLayouts.Touch
{
    public class OrientationAwareLayoutConstraint : NSLayoutConstraint
    {
        UIInterfaceOrientation lastOrientation;

        public static OrientationAwareLayoutConstraint Create(NSObject firstItem, NSLayoutAttribute firstAttribute, NSLayoutRelation relation, 
            NSObject secondItem, NSLayoutAttribute secondAttribute, float multiplier, float portraitConstant, float landscapeConstant) 
        {
            var layout = NSLayoutConstraint.Create(firstItem, firstAttribute, relation, secondItem, secondAttribute, multiplier, 0f);
            return new OrientationAwareLayoutConstraint(layout.Handle, portraitConstant, landscapeConstant);
        }

        public OrientationAwareLayoutConstraint(IntPtr handle, float portraitConstant, float landscapeConstant) : base(handle)
        {
            _landscapeConstant = landscapeConstant;
            _portraitConstant = portraitConstant;
            SetOrientationConstant(UIApplication.SharedApplication.StatusBarOrientation);

            UIApplication.Notifications.ObserveWillChangeStatusBarOrientation(handleOrientationChange);
        }

        private float _landscapeConstant;
        public float LandscapeConstant
        {
            get
            {
                return _landscapeConstant;
            }

            set
            {
                _landscapeConstant = value;

                if (lastOrientation == UIInterfaceOrientation.LandscapeLeft || lastOrientation == UIInterfaceOrientation.LandscapeRight)
                {
                    this.Constant = value;

                    Console.WriteLine("Updated to LandscapeConstant: {0}", value);
                }
            }
        }

        private float _portraitConstant;
        public float PortraitConstant
        {
            get
            {
                return _portraitConstant;
            }

            set
            {
                _portraitConstant = value;

                if (lastOrientation == UIInterfaceOrientation.Portrait || lastOrientation == UIInterfaceOrientation.PortraitUpsideDown)
                {
                    this.Constant = value;

                    Console.WriteLine("Updated to PortraitConstant: {0}", value);
                }
            }
        }

        void handleOrientationChange(object sender, NSNotificationEventArgs e)
        {
            Console.WriteLine("handleOrientationChange");

            NSNumber orientationNumber = (NSNumber) e.Notification.UserInfo[UIApplication.StatusBarOrientationUserInfoKey];
            var orientation = (UIInterfaceOrientation) orientationNumber.Int32Value;

            if (orientation != lastOrientation)
            {
                SetOrientationConstant(orientation);
            }
        }

        void SetOrientationConstant(UIInterfaceOrientation newOrientation)
        {
            if (newOrientation == UIInterfaceOrientation.LandscapeLeft
                || newOrientation == UIInterfaceOrientation.LandscapeRight)
            {
                this.Constant = _landscapeConstant;
            }
            else
            {
                this.Constant = _portraitConstant;
            }

            lastOrientation = newOrientation;
        }
    }

}
