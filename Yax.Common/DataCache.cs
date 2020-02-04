using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace Yax.Common
{
	/// <summary>
	/// ������صĲ�����
	/// </summary>
	public class DataCache
	{
		/// <summary>
		/// ��ȡ��ǰӦ�ó���ָ��CacheKey��Cacheֵ
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <returns></returns>
		public static object GetCache(string CacheKey)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			return objCache[CacheKey];
		}

		/// <summary>
		/// ���õ�ǰӦ�ó���ָ��CacheKey��Cacheֵ
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public static void SetCache(string CacheKey, object objObject)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			objCache.Insert(CacheKey, objObject);
		}

		/// <summary>
		/// ���õ�ǰӦ�ó���ָ��CacheKey��Cacheֵ
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration,TimeSpan slidingExpiration )
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			objCache.Insert(CacheKey, objObject,null,absoluteExpiration,slidingExpiration);
		}

        /// <summary>
		/// ���õ�ǰӦ�ó���ָ��CacheKey��Cacheֵ
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject, int CacheMin)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, DateTime.Now.AddMinutes(CacheMin), TimeSpan.Zero);
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="CacheKey"></param>
        public static void RemoveCache(string CacheKey)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Remove(CacheKey);
        }
        public static void RemoveAllCache()
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            IDictionaryEnumerator CacheEnum = cache.GetEnumerator();
            ArrayList al = new ArrayList();
            while (CacheEnum.MoveNext())
            {
                al.Add(CacheEnum.Key);
            }
            foreach (string key in al)
            {
                cache.Remove(key);
            }
        }

	}
}
