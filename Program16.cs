using System.Runtime.InteropServices.JavaScript;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Newtonsoft.Json.Linq;



namespace TelegramBotPD422
{
    internal class Program
    {

        private static readonly string BotToken = "8184050550:AAEgzsbJtXvSlEYtcfItW2V23EDFIYcCQew";
        private static TelegramBotClient botClient;
        private static readonly HttpClient httpClient = new HttpClient();
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;


            botClient = new TelegramBotClient(BotToken);
            var me = botClient.GetMeAsync();
            Console.WriteLine($"Bot name : {me.Result.Username} has started work");

            using var cst = new CancellationTokenSource();
            botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync, cancellationToken: cst.Token);


            Console.WriteLine("Push enter to stop the bot");
            Console.ReadLine();
            cst.Cancel();
        }
        private static async Task HandleTextMessage(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            var text = message.Text;
            var chatId = message.Chat.Id;
            Random random = new Random();
            string[] sticker =
            {
                "😊",
                "😂",
                "🤣",
                "❤️",
                "😍",
                "😒",
                "👌",
                "😘",
                "💕",
                "😁",
                "👍",
                "🙌",
                "🎶",
                "😶‍🌫️",
                "🙄",
                "😏",
                "😣",
                "😥"
            };
            int randomsteaker = random.Next(sticker.Length);

            Console.WriteLine($"Get message {text}");
            switch (text.ToLower())
            {
                case "/start":
                    var replyKeyboard = new ReplyKeyboardMarkup(new[]
                    {
                        new KeyboardButton[]{"weather", "photo"},
                        new KeyboardButton[]{"inline button" },
                    })
                    {
                        ResizeKeyboard = true
                    };
                    await botClient.SendTextMessageAsync(chatId, "Choose the menu item: ",replyMarkup: replyKeyboard, cancellationToken: cancellationToken);
                    break;
                case "/help":
                    await botClient.SendTextMessageAsync(chatId, "OK, I can halp you: \n[1] - /start if you can`t start bot; \n[2] - /menu show all commands; \n[3] - /about tell about bot; \n[5] - /contact - show infornation about creater; \n[6] - /joke - random joke; \n[6] - /end ended program", cancellationToken: cancellationToken);
                    break;
                case "/menu":
                    await botClient.SendTextMessageAsync(chatId, "All commands: \n[1] - /menu - Menu with all commands; \n[2] - /start - Started program; \n[3] - /help - Can help with your problem; \n[4] - /about - About bot; \n[5] - /contact - show infornation about creater; \n[6] - /joke - random joke; \n[7] - /end - End program;", cancellationToken: cancellationToken);
                    break;
                case "/about":
                    await botClient.SendTextMessageAsync(chatId, "This bot called Panikowskij, it is personal bot by Dima Yefimchuk with PD422 group", cancellationToken: cancellationToken);
                    break;
                case "/end":
                    await botClient.SendTextMessageAsync(chatId, "Thank you for work. Bye", cancellationToken: cancellationToken);
                    break;
                case "/contact":
                    await botClient.SendTextMessageAsync(chatId, "Creater - Dmytro Yefimchuk, student IT Step Academy, phone number: +380*********", cancellationToken: cancellationToken);
                    break;
                case "/joke":
                    RandomeJoke(botClient, message, cancellationToken: cancellationToken);
                    break;
                case "weather":
                    await SendWeather(chatId, cancellationToken);
                    break;
                case "photo":
                    break;
                case "inline button":
                    var inlineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Дізнатись погоду", "weather"),
                        InlineKeyboardButton.WithCallbackData("Get Photo", "photo"),
                    });
                    await botClient.SendTextMessageAsync(chatId, "Choose option : ", replyMarkup: inlineKeyboard, cancellationToken: cancellationToken);
                    break;
                default:
                    await botClient.SendTextMessageAsync(chatId, $"{sticker[randomsteaker]} {text}", cancellationToken: cancellationToken);
                    break;
            }
        }

        private static async Task SendWeather(long chatId, CancellationToken cancellationToken)
        {
            string apiKey = "80d898572346c65322b3ab62fb134590";
           
            string city = "Rivne";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            
            var response = await httpClient.GetStringAsync(url);
            var weatherdata = JObject.Parse(response);
            string description = weatherdata["weather"][0]["description"].ToString();
            string temp = weatherdata["main"]["temp"].ToString();

            await botClient.SendTextMessageAsync(chatId, $"The weather int {city}: {description}, tempetature: {temp}", cancellationToken: cancellationToken);
        }
        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message)
            {
                var message = update.Message;
                var chatId = message.Chat.Id;


                switch (message.Type)
                {
                    case MessageType.Text:
                        await HandleTextMessage(botClient, message, cancellationToken);
                        break;
                    case MessageType.Photo:
                        await botClient.SendTextMessageAsync(chatId, "Good photo.", cancellationToken: cancellationToken);
                        break;
                    case MessageType.Sticker:
                        await botClient.SendTextMessageAsync(chatId, "Good sticker", cancellationToken: cancellationToken);
                        break;
                    default:
                        await botClient.SendTextMessageAsync(chatId, "Unkown type", cancellationToken: cancellationToken);
                        break;
                }
            }
            else if(update.Type == UpdateType.CallbackQuery)
            {
                await HandleCallbackQuery(botClient, update.CallbackQuery, cancellationToken);
            }
        }

        private static async void RandomeJoke(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            var chatId = message.Chat.Id;
            Random rnd = new Random();
            string[] joke =
            {
                "Як визначити забобонного пірата? По запльованому папузі на лівому плечі.",
                "Дівчина після аварії дзвонить до поліції і каже: Алло 102, вітаю тепер вас 101",
                "В таксі сідає бабця з автоматом, і таксист питає:\n Що ж ви бабцю з автоматом ходите? \nТа от часи такі гвалтують - каже бабця \nТа хто ж вас таку стару гвалтувати буде?\n *Бабця наводить ствол на таксиста і каже* \n А от ти і будеш.",
                "Їду в автобусі. Стало скучно і згадав старий прикол. Почав дивитись на дівчину, довго роздивляюсь її. Далі, беру телефон і говорю: 'Шеф, я знайшов її'. А та особа не розгубившись хватає свій телефон і говорить: 'Я спалилась, потребую евакуаціх'. Я в шоці. Весь автобув сміється",
                "Чому ти нічого не відповідаєш на лекціях? \nЯслухаю але не засуджую.",
                "Кращий захист це напад. Купили бус та пакуєм ТЦК",
                "Життя потрібно прожити так щоб в честь тебе назвали для людей з ДЦП. Леонардо Да Вінчі",
                "Чому дунув вовк, а дах понесло у поросят?",
                "Салат 'Металург': Три чайні ложки та дві столові",
                "Тренер втішує програвшого боксера:\n Ну в третьому раунді ти його канешно налякав. \nЧим? \nВін думав що вбив тебе.",
                "Та не був я вчора п'яний!!! \nНу да, а хто кричав: Офіціант, принеси мені двері, я хочу вийти!",
                "- Дівчино, а як ти сьи називаш? \n-Свєта. \n-То які? Різдвєні чи Великодні?",
                "Закодований чоловік прибігає додому і кричить до жінки. \n-Жінко дзвони в поліцію мене взламали!!!",
                "-Вибачте, а у вас вогнику не знайдеться? \n-Та пішов ти - відказав Прометей орлу",
                "Поліцейськи зупиняє наркомана в зоопарку. \n-Коловся? \n-Ні \n-Зараз це ми і перевіремо! \n-Що це за звір?(показує на клітку з кенгуру)\n-Заєць років так 40-45",
                "Два грузина сіли грати в шахмати. Обоє грати не всіють. Один поставив на центр дошки королеву і каже: \n-Мат!! \n А інший поставив свою поряд і відповідає: \n-Отець",
                "Тренер камікадзе говорить: \n-Дивись показую один раз",
                "Забухали якось Холмс і Ватсон. Ватсон пішов в туалет. Повертається і говорить: \n-Дивний у вас туалет Холмс. Відкриваю двері світло вмикається, закриваю світло гасне. \n-Щось моя дедукція подказує Ватсон що ви нагадили в холодильник",
                "Що буде якщо в рис додати два гриба? \nХіросіма і Нагасакі",
                "Коли тато сказав 'Краще вдома чим десь в переулках' і дав 3 ножових",
                "Він бігав за кожною юбкою. І все б нічого якби це не було в Шотландії",
                "Відбери в міліонера гроші, і він заробить більше. Відбери в художника роботу і він захокить пів світу.",
                "Якби моя бабуся дізналась, скільки я зекономив на її похороні - вона б перевернулась в канаві",
                "Три патологоанатома роблять розтин, двоє препарують, третій читає висновок токсикологічної експертизи. Двоє такі - О! Шлунок! Розрізаааємо... Що тут у нас... О! Гречка! З тушонкою! Толян (до третього), будеш? Той - Та нє, поки почитаю. Ті знизують плечима, дістають ложки з кишень халатів і починають наминати кашу прямо зі шлунка. Майже доїли, а третій задумливо каже - Народ, здається, він від цієї каші копита і відкинув... Двоє, що їли, одразу по два пальці в рот, вивертають ту кашу назад в шлунок і біжать по активоване вугілля до аптечки. Третій, з посмішкою, дістаючи ложку - Та не переживайте, я пожартував! Я просто підігріте люблю!",
                "В чому різниця між портсигаром і сиротою? Портсигар без папірос, а сирота і без папи рос і без мами рос",
                "Знайомиться дівчина з хлопцем а він єврей пішли вони на побачення ну побачення закінчилося дівчина йому й каже дай свій номер а він на неї дивиться й каже ми вже ім'ями користуємося",
                "Як називається карлик у кінці шеренги? Коротке замикання"
            };
            int randomnumb = rnd.Next(joke.Length);
            await botClient.SendTextMessageAsync(chatId, joke[randomnumb], cancellationToken: cancellationToken);
        }

        private static async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery, CancellationToken cancellationToken)
        {
            if(callbackQuery.Data == "weather")
            {
                await SendWeather(callbackQuery.Message.Chat.Id,cancellationToken);
            }
            else if(callbackQuery.Data == "photo")
            {

            }
        }

        private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Error : {exception.Message}");
            return Task.CompletedTask;
        }
    }
}
