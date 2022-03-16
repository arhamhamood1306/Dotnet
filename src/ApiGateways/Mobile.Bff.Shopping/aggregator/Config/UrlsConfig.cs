using System.Collections.Generic;

namespace AKD.AKDTrading.Mobile.HttpAggregator.Config
{
    public class UrlsConfig
    {
        public class IdentityOperations
        {
            public static string GetUserById(int id) => $"/api/v1/identity/users/{id}";

            public static string GetUsersById(IEnumerable<int> ids) => $"/api/v1/identity/users?ids={string.Join(',', ids)}";
        }

        public class FinanceOperations
        {
        }

        public class PSXOperations
        {
        }

        public string Identity { get; set; }

        public string Finance { get; set; }

        public string PSX { get; set; }
    }
}
