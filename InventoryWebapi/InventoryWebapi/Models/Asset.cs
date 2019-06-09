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
        public string LastClaimed { get; set; }

    }

    public class AssetRepo
    {
        private static AssetRepo _instance;

        public static AssetRepo Instance
        {
            get {
                _instance = _instance == null ? new AssetRepo() : _instance;
                return _instance;
            }
        }


        private List<Asset> _repo;
        private AssetRepo()
        {
            _repo = new List<Asset>();
            _repo.Add( new Asset() { Id=1, AssetCode="uc1", AssetOwner="uid123", LastClaimed="uid123" });
            _repo.Add(new Asset() { Id = 2, AssetCode = "uc2", AssetOwner = "uid123", LastClaimed = "uid123" });
            _repo.Add(new Asset() { Id = 3, AssetCode = "uc3", AssetOwner = "uid123", LastClaimed = "uid123" });
        }

        public Asset[] Asset
        {
            get { return _repo.ToArray(); }
        }

        public Asset CreateAndAdd(Asset asset)
        {
            if (_repo.Any(x => x.AssetCode == asset.AssetCode))
            {
                return null;
            }
            else
            {
                Asset newAsset = new Asset();
                newAsset.Id = _repo.Count()+1;
                newAsset.AssetCode = asset.AssetCode;
                newAsset.LastClaimed = asset.LastClaimed;
                newAsset.AssetOwner = asset.AssetOwner;
                newAsset.Description = asset.Description;
                newAsset.Name = asset.Name;

                _repo.Add(newAsset);
                return newAsset;
            }
        }

        public Asset Update(int id, Asset assetInfo, bool isPatch = false)
        {
            var found = _repo.FirstOrDefault(x => x.Id == id);
            if(found != null && assetInfo != null)
            {
                if (isPatch)
                {
                    //replace not null
                    found.AssetCode = assetInfo.AssetCode ?? found.AssetCode;
                    found.LastClaimed = assetInfo.LastClaimed ?? found.LastClaimed;
                    found.AssetOwner = assetInfo.AssetOwner ?? found.AssetOwner;
                    found.Description = assetInfo.Description ?? found.Description;
                    found.Name = assetInfo.Name ?? found.Name;
                }
                else
                {
                    //replace all
                    found.AssetCode = assetInfo.AssetCode;
                    found.LastClaimed = assetInfo.LastClaimed;
                    found.AssetOwner = assetInfo.AssetOwner;
                    found.Description = assetInfo.Description;
                    found.Name = assetInfo.Name;
                }
                return found;
            }
            return null;
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