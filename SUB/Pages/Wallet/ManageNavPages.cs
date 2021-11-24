using System;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace SUB.Pages.Wallet
{
    public static class ManageNavPages
    {
        public static string Payment => "Payment";

        public static string Payoff => "Payoff";

        public static string History => "History";

        public static string PaymentNavClass(ViewContext viewContext) => PageNavClass(viewContext, Payment);

        public static string PayoffNavClass(ViewContext viewContext) => PageNavClass(viewContext, Payoff);

        public static string HistoryNavClass(ViewContext viewContext) => PageNavClass(viewContext, History);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
