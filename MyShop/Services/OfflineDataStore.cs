﻿using Lotz.Xam.Messaging;
using MyShop.Services;
using Newtonsoft.Json;
using PCLStorage;
using Plugin.EmbeddedResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

//[assembly: Dependency(typeof(OfflineDataStore))]
namespace MyShop.Services
{
    public class OfflineDataStore : IDataStore
    {

        public async Task<IEnumerable<Store>> GetStoresAsync()
        {
            var rootFolder = FileSystem.Current.LocalStorage;
            var json = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("MyShop")), "stores.json");
            return JsonConvert.DeserializeObject<List<Store>>(json);
        }

        public async Task<Feedback> AddFeedbackAsync(Feedback feedback)
        {
            var emailTask = MessagingPlugin.EmailMessenger;
            if(emailTask.CanSendEmail)
            {
                emailTask.SendEmail("james.montemagno@xamarin.com", "My Shop Feedback", feedback.ToString());
            }
            return feedback;
        }

        public async Task<Store> AddStoreAsync(Store store)
        {
            return store;
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackAsync()
        {
            return new List<Feedback>();
        }


        public Task Init()
        {
            return Task.Run(() => { });
        }

        public async Task<bool> RemoveFeedbackAsync(Feedback feedback)
        {
            return true;
        }

        public async Task<bool> RemoveStoreAsync(Store store)
        {
            return true;
        }

        public Task SyncFeedbacksAsync()
        {
            return Task.Run(() => { });
        }

        public Task SyncStoresAsync()
        {
            return Task.Run(() => { });
        }

        public async Task<Store> UpdateStoreAsync(Store store)
        {
            return store;
        }
    }
}
