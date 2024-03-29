﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WaterProject.Infrastucture
{
    //this I believe makes it so that we can pass a basket into a session. 
    public static class SessionExtensions
    {
        public static void SetJson (this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T GetJson<T> (this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default ( T ) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
