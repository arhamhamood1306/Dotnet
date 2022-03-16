using System.Collections.Generic;

namespace AKD.AKDTrading.Web.HttpAggregator.Config
{

    public class UrlsConfig
    {
        public class OrdersOperations
        {
            public static string GetOrderDraft() => "/api/v1/orders/draft";
        }

        public string Orders { get; set; }
    }

}
