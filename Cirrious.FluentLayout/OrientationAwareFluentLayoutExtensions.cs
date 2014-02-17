using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace Cirrious.FluentLayouts.Touch
{
    public static class OrientationAwareFluentLayoutExtensions
    {
        public static OrientationAwareFluentLayout EqualTo(this UIViewAndLayoutAttribute layoutAttribute, float portrait, float landscape)
        {
            return new OrientationAwareFluentLayout(layoutAttribute.View, layoutAttribute.Attribute, NSLayoutRelation.Equal, portrait, landscape);
        }

        public static OrientationAwareFluentLayout GreaterThanOrEqualTo(this UIViewAndLayoutAttribute layoutAttribute, float portrait, float landscape)
        {
            return new OrientationAwareFluentLayout(layoutAttribute.View, layoutAttribute.Attribute, NSLayoutRelation.GreaterThanOrEqual, portrait, landscape);
        }

        public static OrientationAwareFluentLayout LessThanOrEqualTo(this UIViewAndLayoutAttribute layoutAttribute, float portrait, float landscape)
        {
            return new OrientationAwareFluentLayout(layoutAttribute.View, layoutAttribute.Attribute, NSLayoutRelation.LessThanOrEqual, portrait, landscape);
        }

        public static OrientationAwareFluentLayout Minus(this FluentLayout fluentLayout, float portrait, float landscape)
        {
            return OrientationAwareFluentLayout.FromFluentLayout(
                fluentLayout,
                fluentLayout.Constant - portrait,
                fluentLayout.Constant - landscape
            );
        }

        public static OrientationAwareFluentLayout Plus(this FluentLayout fluentLayout, float portrait, float landscape)
        {
            return OrientationAwareFluentLayout.FromFluentLayout(
                fluentLayout,
                fluentLayout.Constant + portrait,
                fluentLayout.Constant + landscape
            );
        }    
    }
}
