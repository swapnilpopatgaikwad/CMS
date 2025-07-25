﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services
{
    public static class HandlerService
    {
        private static IServiceProvider Current =>
#if WINDOWS10_0_17763_0_OR_GREATER
        MauiWinUIApplication.Current.Services;
#elif ANDROID
        MauiApplication.Current.Services;
#elif IOS || MACCATALYST
        MauiUIApplicationDelegate.Current.Services;
#else
		throw new NotImplementedException();
#endif

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="T">The type of service.</typeparam>
        /// <returns>The service.</returns>
        public static T GetService<T>()
            where T : notnull
            => Current.GetRequiredService<T>();
    }
}
