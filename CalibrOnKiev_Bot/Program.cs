using Domain.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CalibrOnKiev_Bot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var botClient = new TelegramBotClient("5938561401:AAGd7NYKud8DLONubiCkrm1V7BZV2rHz04I");
            using CancellationTokenSource cts = new();

            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            botClient.StartReceiving(updateHandler: HandleUpdateAsync, pollingErrorHandler: HandlePollingErrorAsync, receiverOptions: receiverOptions, cancellationToken: cts.Token);

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"я тебя слушаю {me.Username}");
            Console.ReadLine();

            cts.Cancel();

        }

        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message)
                return;
            if (message.Text is not { } messageText)
                return;

            KeyboardButton[][] KeyBoard = new KeyboardButton[][] {
                    new KeyboardButton[]{
                    new KeyboardButton("Привет"),
                    new KeyboardButton("Пикча") },
                    new KeyboardButton[] {
                    new KeyboardButton("Видео от Гази Гаджиева"),
                    new KeyboardButton("Стикер кинь пж")}};

            var chatId = message.Chat.Id;

            Console.WriteLine($"Возьми трубку, '{chatId}' на связи. {messageText}");

            if (message.Text == "Иншала")
            {
                await botClient.SendTextMessageAsync(chatId: chatId, text: "Молчать, чурка", cancellationToken: cancellationToken);
            }
            if (message.Text == "Привет")
            {
                await botClient.SendTextMessageAsync(chatId: chatId, text: $"Здарова {message.Chat.FirstName}", cancellationToken: cancellationToken);
            }
            if (message.Text == "Пикча")
            {
                await botClient.SendPhotoAsync(chatId: chatId
                    , photo: "https://sun1.userapi.com/sun1-55/impg/Mu6Qxzms82WIf4-EjIybHE2d5y_Nf9202f58ww/I8QiD4ED21Y.jpg?size=600x327&quality=95&sign=424b467ee718e423e43b254eda4857cd&type=album"
                    , caption: "<a href=\"https://vk.com/surs_pls\">Who knows...</a>"
                    , parseMode: ParseMode.Html
                    , cancellationToken: cancellationToken);
            }
            if (message.Text == "Видео от Гази Гаджиева")
            {
                await botClient.SendVideoAsync(chatId: chatId
                    , video: "https://rr11---sn-n8v7znzl.googlevideo.com/videoplayback?expire=1683292786&ei=Eq5UZOmTFJC6kwabtoaQDA&ip=154.16.105.71&id=o-AOT_jp0sKUFHaBSX5KAvgc8pDvb2-T92j83lsTr4Uwy4&itag=18&source=youtube&requiressl=yes&spc=qEK7B70pynILmCr6liWgoavWZorJi84pu2XDIpLJdg&vprv=1&svpuc=1&mime=video%2Fmp4&ns=Yvi6Hr1pGeFpb4tIp1RO7d4N&gir=yes&clen=264821&ratebypass=yes&dur=6.919&lmt=1667424887993137&fexp=24007246&c=WEB&txp=5319224&n=z9hUXK1kM1JwYw&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cspc%2Cvprv%2Csvpuc%2Cmime%2Cns%2Cgir%2Cclen%2Cratebypass%2Cdur%2Clmt&sig=AOq0QJ8wRQIgdsn1x7jeFRMIzC9JTrScTdzmLeaFVc5c4NbrHEMaRFICIQCDgojwPoCGOdl7bZFTUVs4Jalp8JcbuaCooyYdgxoVpw%3D%3D&rm=sn-a5myk7z&req_id=ea38ec1409e0a3ee&cm2rm=sn-jvhnu5g-c35s7z,sn-jvhnu5g-n8vy7z&redirect_counter=3&cms_redirect=yes&cmsv=e&ipbypass=yes&mh=S5&mip=94.29.124.119&mm=30&mn=sn-n8v7znzl&ms=nxu&mt=1683270760&mv=m&mvi=11&pl=18&lsparams=ipbypass,mh,mip,mm,mn,ms,mv,mvi,pl&lsig=AG3C_xAwRAIgOH_qKluCyXnbJLm9YEyvWzTuPQJ4Y0IHBD6hlAySoTMCIDapG2AvP6L1lucgGZtXVKdlDbzm3dQdzqYGQn83pNtU"
                    , thumb: "https://sun9-west.userapi.com/sun9-53/impg/ljgBYhESZy84FdzHhleucNbemcNQeTW6pPl8gg/-r0orxBsLFs.jpg?size=1080x614&quality=95&sign=2baa50b21d327d1b3ba30fbd3d259a7c&type=album"
                    , parseMode: ParseMode.Html
                    , supportsStreaming: true
                    , cancellationToken: cancellationToken);
            }
            if (message.Text == "Стикер кинь пж")
            {
                string sticker_fileid = "CAACAgIAAxkBAAEgq8BkVLRmzROSaj7sUFUtlj4_cBEhfgACzxMAAp_XyEuZRS5m3ynUVS8E";
                await botClient.SendStickerAsync(chatId: chatId
                    , sticker: sticker_fileid
                    , cancellationToken: cancellationToken);
            }

            if (message.Text == "/start")
            {
                try
                {
                    Good[] goods = await GetGoods();

                    List<List<KeyboardButton>> GoodcategoriesKeyboard = goods.
                        Select(p=>p.Category).Distinct().Select(p => new List<KeyboardButton> { new KeyboardButton(p) }).Take(5).ToList();


                    await botClient.SendTextMessageAsync(chatId: chatId
                        , text: $"Привет {message.Chat.FirstName}"
                        , replyMarkup: new ReplyKeyboardMarkup(GoodcategoriesKeyboard) { ResizeKeyboard = true }
                    );
                }
                catch
                {
                    await botClient.SendTextMessageAsync(chatId: chatId
                        , text: $"Ошибка получения категорий товаров");
                }
            }

            if (((Good[])(await GetGoods())).Select(p => p.Category).Contains(message.Text))
            {
                try
                {
                    Good[] goods = await GetGoods();

                    List<List<InlineKeyboardButton>> Good_Keyboard = goods.Where(p => p.Category == message.Text).Select(p => p.Title).
                        Select(p => new List<InlineKeyboardButton> { InlineKeyboardButton.WithCallbackData(p) }).Take(5).ToList();

                    await botClient.SendTextMessageAsync(chatId: chatId
                    , text: $"Товары категории {message.Text}"
                    , replyMarkup: new InlineKeyboardMarkup(Good_Keyboard));
                }
                catch
                {

                    await botClient.SendTextMessageAsync(chatId: chatId
                        , text: $"Ошибка получения товаров");
                }
            }

        }
    
        static async Task<Good[]> GetGoods()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("https://localhost:7103/api/GoodControl/good/all");

            var test = await result.Content.ReadAsStringAsync();

            Good[] goods = JsonConvert.DeserializeObject<Good[]>(test);
            return goods;
        }

        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch 
            { ApiRequestException apiRequestException 
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString() 
            };
            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}