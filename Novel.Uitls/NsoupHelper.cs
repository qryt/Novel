using NSoup;
using NSoup.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovelPlay.Utils
{
    public static class NsoupHelper
    {
        /// <summary>
        /// 初始化连接
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static IConnection InitConnect(string url)
        {
            return NSoupClient.Connect(url);
        }

        /// <summary>
        /// 初始化分析
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Document InitParse(string url)
        {
            return NSoupClient.Parse(url);
        }

        /// <summary>
        /// 初始化post连接
        /// </summary>
        /// <param name="url"></param>
        /// <param name="userAgent"></param>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public static Document InitConnectPost(string url, string userAgent, Dictionary<string, string> cookies)
        {
            var conn = InitConnect(url);
            if (!string.IsNullOrWhiteSpace(userAgent))
            {
                conn = conn.UserAgent(userAgent);
            }
            else if (cookies != null)
            {
                conn = conn.Cookies(cookies);
            }
            return conn.Post();
        }

        /// <summary>
        /// 初始化get连接
        /// </summary>
        /// <param name="url"></param>
        /// <param name="userAgent"></param>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public static Document InitConnectGet(string url, string userAgent, Dictionary<string, string> cookies)
        {
            var conn = InitConnect(url);
            if (!string.IsNullOrWhiteSpace(userAgent))
            {
                conn = conn.UserAgent(userAgent);
            }
            else if (cookies != null)
            {
                conn = conn.Cookies(cookies);
            }
            return conn.Get();
        }

    }
}
