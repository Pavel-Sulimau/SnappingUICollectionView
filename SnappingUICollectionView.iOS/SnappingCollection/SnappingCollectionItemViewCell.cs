using System;
using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace SnappingUICollectionView.iOS.SnappingCollection
{
    public class SnappingCollectionItemViewCell : UICollectionViewCell
    {
        private SnappingCollectionItemView View { get; set; }

        public SnappingCollectionItemViewCell(IntPtr handle) : base(handle)
        {
            LoadView();
        }

        public static string CellId { get; } = nameof(SnappingCollectionItemViewCell);

        public string Title
        {
            get => View?.TitleLabel?.Text;
            set => View.TitleLabel.Text = value;
        }

        private void LoadView()
        {
            View = new SnappingCollectionItemView();

            ContentView.AddSubview(View);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentView.AddConstraints(View.FullSizeOf(ContentView));
        }
    }
}
