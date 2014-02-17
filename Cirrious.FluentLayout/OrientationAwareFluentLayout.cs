using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace Cirrious.FluentLayouts.Touch
{
    public class OrientationAwareFluentLayout : FluentLayout
    {
        public OrientationAwareFluentLayout(
            UIView view,
            NSLayoutAttribute attribute,
            NSLayoutRelation relation,
            NSObject secondItem,
            NSLayoutAttribute secondAttribute,
            float portraitConstant,
            float landscapeConstant) : base(view, attribute, relation, secondItem, secondAttribute)
        {
            this.PortraitConstant = portraitConstant;
            this.LandscapeConstant = landscapeConstant;
        }

        internal static OrientationAwareFluentLayout FromFluentLayout(FluentLayout fluentLayout, float portrait, float landscape)
        {
            return new OrientationAwareFluentLayout(fluentLayout.View, fluentLayout.Attribute, fluentLayout.Relation, fluentLayout.SecondItem,
                fluentLayout.SecondAttribute, portrait, landscape);
        }

        public OrientationAwareFluentLayout(UIView view,
            NSLayoutAttribute attribute,
            NSLayoutRelation relation,
            float portraitConstant,
            float landscapeConstant) : base(view, attribute, relation, 0f)
        {
            this.PortraitConstant = portraitConstant;
            this.LandscapeConstant = landscapeConstant;
        }
            
        public float PortraitConstant { get; private set; }
        public float LandscapeConstant { get; private set; }

        public override IEnumerable<NSLayoutConstraint> ToLayoutConstraints()
        {
            yield return OrientationAwareLayoutConstraint.Create(
                View,
                Attribute,
                Relation,
                SecondItem,
                SecondAttribute,
                Multiplier,
                PortraitConstant,
                LandscapeConstant);
        }
    }
}

