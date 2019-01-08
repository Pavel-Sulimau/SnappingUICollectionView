using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace SnappingUICollectionView.iOS.SnappingCollection
{
    public class SnappingCollectionItemView : UIView
    {
        public SnappingCollectionItemView()
        {
            SetupSubviews();
            SetupLayout();
            SetupLayoutConstraints();
        }

        public UILabel TitleLabel { get; set; }

        private void SetupSubviews()
        {
            BackgroundColor = UIColor.Green;

            TitleLabel = new UILabel
            {
                TextColor = UIColor.Black,
                Font = UIFont.BoldSystemFontOfSize(16)
            };
        }

        private void SetupLayout()
        {
            AddSubview(TitleLabel);
        }

        private void SetupLayoutConstraints()
        {
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            this.AddConstraints(
                TitleLabel.WithSameCenterX(this),
                TitleLabel.WithSameCenterY(this));
        }
    }
}
