using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace SnappingUICollectionView.iOS.SnappingCollection
{
    public class SnappingCollectionViewDataSource : UICollectionViewSource
    {
        private readonly List<string> _items;

        public SnappingCollectionViewDataSource()
        {
            _items = Enumerable.Range(1, 10).Select(x => $"Item #{x}").ToList();
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (SnappingCollectionItemViewCell)collectionView.DequeueReusableCell(
                SnappingCollectionItemViewCell.CellId,
                indexPath);

            var item = _items[indexPath.Row];

            cell.Title = item;

            return cell;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return _items.Count;
        }
    }
}
