using CPM.Data.Entities;
using CPM.Data.Wallet;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data
{
    public class EnsureSeedData
    {
        private UserManager<ClientEntity> _userManager;

        public EnsureSeedData(UserManager<ClientEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task EnsureClientSeedDataAsync(string seedFilePath)
        {
            string email1 = "user1@someplace.io";
            if (await _userManager.FindByEmailAsync(email1) == null)
            {
                //Add the user
            }
        }


        public void EnsureSeedWalletData(string filePath)
        {
            WalletContext walletContext = new WalletContext();
            if (!walletContext.Wallets.Any())
            {
                dynamic jsonData = ReadJsonFile(filePath);
                if (jsonData != null)
                {
                    foreach (dynamic d in jsonData)
                    {
                        walletContext.Wallets.Add(new WalletEntity()
                        {
                            ClientId = d.ClientId,
                            Name = d.Name,
                            Balance = d.Balance,
                            IsLocked = d.IsLocked,
                            Currency = d.Currency,
                            DateCreated = d.DateCreated,
                            DateModified = d.DateModified
                        });
                    }
                    walletContext.SaveChanges();
                }
            }
        }

        public void EnsureWalletTypeSeedData(string filePath)
        {
            WalletContext walletContext = new WalletContext();
            if (!walletContext.WalletTypes.Any())
            {
                dynamic jsonData = ReadJsonFile(filePath);
                if (jsonData != null)
                {
                    foreach (dynamic d in jsonData)
                    {
                        walletContext.WalletTypes.Add(new WalletTypeEntity()
                        {
                            Id = d.Id,
                            Name = d.Name,
                            Category = d.Category,
                            Description = d.Description
                        });
                    }
                }
            }
        }

        private static dynamic ReadJsonFile(string filePath)
        {
            //Read seed json file
            JArray jarray = JArray.Parse(File.ReadAllText(filePath)) as JArray;
            if (jarray != null)
            {
                dynamic jsonData = jarray;
                return jsonData;
            }
            return new JArray();
        }
    }
}