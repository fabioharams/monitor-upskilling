using System;

namespace Polling.Service.V1.Model
{
    /// <summary>
    /// For more information about the access_token check https://tools.ietf.org/html/rfc6749#section-4.2.2
    /// https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-v2-protocols-oauth-code#request-an-access-token
    /// 
    ///  When requested a token will expire by the time it was generated plus the number os seconds in the properties expires_in
    /// 
    /// </summary>
    public class Token
    {
        public Token()
        {
            generated_in = DateTime.Now;
        }

        public DateTime generated_in { get; private set; }
        public DateTime expiration_date
        {
            get
            {
                return generated_in.AddSeconds(expires_in - 60);
            }
        }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public int ext_expires_in { get; set; }
        public int expires_on { get; set; }
        public int not_before { get; set; }
        public string resource { get; set; }
        public string access_token { get; set; }

        /// <summary>
        /// Checks if the Token is already expired by comparing the current datetime with expiration.
        /// </summary>
        /// <returns></returns>
        public bool IsTokenExperied()
        {

            if (DateTime.Now.CompareTo(expiration_date) > 0)
                return true;
            else
                return false;

        }

    }
}
