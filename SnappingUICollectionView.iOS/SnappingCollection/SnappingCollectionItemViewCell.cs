using System;
using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace SnappingUICollectionView.iOS.SnappingCollection
{
    public class SnappingCollectionItemViewCell : UICollectionViewCell
    {
        private SnappingCollectionItemView ItemView { get; set; }

        public SnappingCollectionItemViewCell(IntPtr handle) : base(handle)
        {
            LoadView();
        }

        public static string CellId { get; } = nameof(SnappingCollectionItemViewCell);

        public string Title
        {
            get => ItemView?.TitleLabel?.Text;
            set => ItemView.TitleLabel.Text = value;
        }

        private void LoadView()
        {
            ItemView = new SnappingCollectionItemView();

            ContentView.AddSubview(ItemView);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentView.AddConstraints(ItemView.FullSizeOf(ContentView));
        }
    }
}
