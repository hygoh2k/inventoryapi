using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryWebapi.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string AssetCode { get; set; }
        public string AssetOwner { get; set; }
        public string AssetHolder { get; set; }

    }

    public class AssetRepo
    {
        private List<Asset> _repo;
        public AssetRepo()
        {
            _repo = new List<Asset>();
            _repo.Add( new Asset() { Id=1, AssetCode="uc1", AssetOwner="uid123", AssetHolder="uid123" });
            _repo.Add(new Asset() { Id = 2, AssetCode = "uc2", AssetOwner = "uid123", AssetHolder = "uid123" });
            _repo.Add(new Asset() { Id = 3, AssetCode = "uc3", AssetOwner = "uid123", AssetHolder = "uid123" });
        }

        public Asset[] Asset
        {
            get { return _repo.ToArray(); }
        }

        public Asset CreateAndAdd(Asset asset)
        {
            Asset newAsset = new Asset();
            newAsset.AssetCode = asset.AssetCode;
            newAsset.AssetHolder = asset.AssetHolder;
            newAsset.AssetOwner = asset.AssetOwner;
            newAsset.Description = asset.Description;

            return newAsset;
        }

        public void Remove(int assetId)
        {
            var found = _repo.FirstOrDefault(x => x.Id == assetId);
            if(found != null)
            {
                _repo.Remove(found);
            }
        }
    }

}