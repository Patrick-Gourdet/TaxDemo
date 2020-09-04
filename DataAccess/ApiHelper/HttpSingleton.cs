// Patrick Gourdet Iron Financials LLC 08/27/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TaxJar.Microservice.DataAccess.ApiHelper
{
    /// <summary>
    /// Http Singleton class 
    /// </summary>
    class HttpClientSingleton : IDisposable
    {
        private HttpClientSingleton() { }
        private static readonly object Lock = new object();
        private static HttpClient _localClient = new HttpClient();
        private static SocketsHttpHandler socketHandler;
        /// <summary>
        /// handle socket pooling and timeouts 
        /// </summary>
        /// <returns></returns>
        static SocketsHttpHandler GetScoketHandler()
        {
            return socketHandler = new SocketsHttpHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                PooledConnectionLifetime = TimeSpan.FromMinutes(5),
                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(2),
                MaxConnectionsPerServer = 20
            };
        }
        /// <summary>
        /// Set header over load function using api key and api secret
        /// </summary>
        /// <param name="apiKeyTitle"></param>
        /// <param name="internalKey"></param>
        /// <param name="apiSecretTitle"></param>
        /// <param name="apiSecret"></param>
        public static void SetHeaders(string apiKeyTitle, string internalKey, string apiSecretTitle, string apiSecret)
        {
            _localClient.DefaultRequestHeaders.TryGetValues(internalKey, out var value);
            if (value == null) _localClient.DefaultRequestHeaders.Add(apiKeyTitle, internalKey);
            _localClient.DefaultRequestHeaders.TryGetValues(apiSecretTitle, out var value2);
            if (value2 == null) _localClient.DefaultRequestHeaders.Add(apiSecretTitle, apiSecret);
        }
        /// <summary>
        /// Set header overload for simplistic header addition
        /// </summary>
        /// <param name="apiKeyTitle"></param>
        /// <param name="internalKey"></param>
        public static void SetHeaders(string apiKeyTitle, string internalKey)
        {
            _localClient.DefaultRequestHeaders.TryGetValues(apiKeyTitle,out var value);
            if (value == null) _localClient.DefaultRequestHeaders.Add(apiKeyTitle, internalKey);
            
        }
        /// <summary>
        /// Set Header Overload 
        /// </summary>
        /// <param name="key"></param>
        public static void SetHeadersAccept( string key)
        {
            _localClient.DefaultRequestHeaders.TryGetValues(key, out var value);
            if (value == null) _localClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(key));

        }
        /// <summary>
        /// Set header override using a predefined dictionary key value pairs
        /// </summary>
        /// <param name="headers"></param>
        public static void SetHeaders(Dictionary<string,string> headers)
        {
            foreach (var head in headers)
            {
                _localClient.DefaultRequestHeaders.TryGetValues(head.Key, out var value);
                if (value == null) _localClient.DefaultRequestHeaders.Add(head.Key, head.Value);
            }
        }
        /// <summary>
        /// Remove header needed for authentication calls this is mainly for security reasons
        /// </summary>
        /// <param name="headers"></param>
        public static void RemoveHeaders(Dictionary<string,string> headers)
        {
            foreach (var head in headers)
            {
                _localClient.DefaultRequestHeaders.TryGetValues(head.Key, out var value);
                if (value != null) _localClient.DefaultRequestHeaders.Remove(head.Key);
            }
        }
        /// <summary>
        /// Remove header function override to accomodate the same format as the set header function set
        /// </summary>
        /// <param name="apiKeyTitle"></param>
        /// <param name="apiKey"></param>
        /// <param name="apiSecretTitle"></param>
        /// <param name="apiSecret"></param>
        public static void RemoveHeaders(string apiKeyTitle, string apiKey, string apiSecretTitle, string apiSecret)
        {
            _localClient.DefaultRequestHeaders.TryGetValues(apiKey, out var value);
            if (value != null) _localClient.DefaultRequestHeaders.Remove(apiKeyTitle);
            _localClient.DefaultRequestHeaders.TryGetValues(apiSecretTitle, out var value2);
            if (value2 != null) _localClient.DefaultRequestHeaders.Remove(apiSecretTitle);
        }
        /// <summary>
        /// Remove header overload function 
        /// </summary>
        /// <param name="apiKeyTitle"></param>
        /// <param name="apiKey"></param>
        public static void RemoveHeaders(string apiKeyTitle, string apiKey)
        {
            _localClient.DefaultRequestHeaders.TryGetValues(apiKeyTitle,out var value);
            if (value != null) _localClient.DefaultRequestHeaders.Add(apiKeyTitle, apiKey);
            
        }
        /// <summary>
        /// Remove header overload function
        /// </summary>
        /// <param name="apiKey"></param>
        public static void RemoveHeadersAccept( string apiKey)
        {
            _localClient.DefaultRequestHeaders.TryGetValues(apiKey, out var value);
            if (value != null) _localClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(apiKey));

        }
        /// <summary>
        /// Public accessor for the HttpClient 
        /// </summary>
        public static HttpClient TaxClient
        {
            get
            {
                lock (Lock)
                {
                    if (_localClient is null) return _localClient = new HttpClient(GetScoketHandler());
                    return _localClient;
                }
            }
        }
        /// <summary>
        /// dispose method for the Socket handler method 
        /// </summary>
        public void Dispose()
        {
            socketHandler?.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose method to call if there is an error or memory issues
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_localClient != null)
                {
                    _localClient.Dispose();
                }
                _localClient = null!;
                GC.SuppressFinalize(this);
            }
        }
    }
}
