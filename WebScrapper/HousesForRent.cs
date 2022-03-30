using HtmlAgilityPack;
using Telegram.Bot;

namespace WebScrapper
{
    public class HousesForRent
    {
        public HousesForRent()
        {

        }

        static string _SourceUrl = "https://vivepropiedadraiz.com.co/es/apartamento-en-arriendo/el-retiro";
        static string _SourceHeader = "https://vivepropiedadraiz.com.co";
        public static void LookForItems()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(_SourceUrl);

            var HeaderNames = doc.DocumentNode.SelectNodes("//div[@class='card-body-copy']");

            foreach (var item in HeaderNames)
            {
                var urlapto = item.SelectSingleNode("//div[@class='card-title']");
                var chNode = urlapto.ChildNodes["a"];
                var aptoUrl = $"{_SourceHeader}{chNode.GetAttributeValue("href", string.Empty)}";

                new TelegramBot().SendMessage("Encontré una nueva propiedad: \n" + aptoUrl);
                return;
            }
        }
    }

    public class TelegramBot
    {
        private static string ApiKey = "TELEGRAM_API_KEY";

        public void SendMessage(string msj)
        {
            string chatId = "yourChatId";

            var bot = new TelegramBotClient(ApiKey);
            var result = bot.SendTextMessageAsync(new Telegram.Bot.Types.ChatId(chatId), msj).Result;
        }
    }
}
