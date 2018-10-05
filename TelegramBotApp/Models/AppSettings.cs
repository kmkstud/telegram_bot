
//ngrok http -host-header=rewrite localhost:4827
namespace TelegramBotApp.Models
{
    public static class AppSettings
    {
        public static string Url { get; set; }  = "https://de6d8415.ngrok.io/{0}";

        public static string Name { get; set; } = "KmkStudBot";

        public static string Key { get; set; }  = "658397239:AAELQlzArU36IRF6VZvUVTECzzID14DLxBg";

    }
}