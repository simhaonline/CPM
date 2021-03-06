﻿using CPM.Business.Currency;
using CPM.Business.Global.Account;
using CPM.Business.Offer;
using CPM.Business.Wallet;
using CPM.Data.Global.Account;
using CPM.Web.Common.Account;
using CPM.Web.Common.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPM.Web
{
    public class DependecyInjection
    {
        public static void Configure(IServiceCollection services)
        {
            #region  " Framework "
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();            
            #endregion

            #region " Global "
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ISessionHelper, SessionHelper>();
            services.AddScoped<IHasher, Hasher>();
            #endregion

            #region " CPMUser "
            services.AddScoped<CPMUserContext, CPMUserContext>();
            #endregion

            #region " Wallet "
            services.AddScoped<IWalletService, WalletService>();            
            #endregion

            #region " Offer "         
            services.AddScoped<IOfferService, OfferService>();
            #endregion

            #region " Currency " 
            services.AddScoped<ICurrencySerivce, CurrencyService>();
            services.AddScoped<IPriceTickerService, PriceTickerService>();
            #endregion

        }
    }
}
