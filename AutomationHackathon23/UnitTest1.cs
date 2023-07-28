using OpenQA.Selenium.Interactions;
using SixLabors.ImageSharp.Formats;
using Size = System.Drawing.Size;

namespace AutomationHackathon23
{
    public class Tests
    {
        ChromeDriver ChromeDriver { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeDriver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
            ChromeDriver.Dispose();
        }

        [Test]
        public void Test1()
        {
            ChromeDriver.Navigate().GoToUrl("http://www.google.com");

            var acceptButton = ChromeDriver.FindElement(By.XPath(".//button[.//div[normalize-space()='Priimti viską']]"));
            acceptButton.Click();

            var searchInput = ChromeDriver.FindElement(By.Name("q"));
            searchInput.SendKeys("devbridge");
            Thread.Sleep(500);
            searchInput.SendKeys(Keys.Enter);
            Thread.Sleep(500);

            var searchResults = ChromeDriver.FindElements(By.XPath(".//div[@class='g']"));
            var searchResult = searchResults[0];
            var link = searchResult.FindElement(By.CssSelector("a"));

            Assert.True(link.GetAttribute("href").Contains("devbridge.com"));
        }

        [Test]

        public void Task1()
        {
            ChromeDriver.Navigate().GoToUrl("https://www.lutanho.net/play/frogs.html");

            var rupuzes = GetRupuziokus();

            var varles = GetVarlikes();
            

            var rupuziuskaicius = rupuzes.Count();

            var varliuskaicius = varles.Count();


            if (rupuziuskaicius > varliuskaicius)

            {

                try

                {

                    ClickRupuziokus(GetRupuziokus(), 1);

                    ClickVarlikes(GetVarlikes(), 2);

                    ClickRupuziokus(GetRupuziokus(), 3);

                    ClickVarlikes(GetVarlikes(), 4);

                    ClickRupuziokus(GetRupuziokus(), 4);

                    ClickVarlikes(GetVarlikes(), 4);

                    ClickRupuziokus(GetRupuziokus(), 4);

                    ClickVarlikes(GetVarlikes(), 4);

                    ClickRupuziokus(GetRupuziokus(), 4);

                    ClickVarlikes(GetVarlikes(), 4);

                    ClickRupuziokus(GetRupuziokus(), 4);

                }

                catch

                {

                    //nothinggg

                }

 

            }

            else

            {

                try

                {

                    ClickVarlikes(GetVarlikes(), 1);

                    ClickRupuziokus(GetRupuziokus(), 2);

                    ClickVarlikes(GetVarlikes(), 3);

                    ClickRupuziokus(GetRupuziokus(), 4);

                    ClickVarlikes(GetVarlikes(), 4);

                    ClickRupuziokus(GetRupuziokus(), 4);

                    ClickVarlikes(GetVarlikes(), 4);

                    ClickRupuziokus(GetRupuziokus(), 4);

                    ClickVarlikes(GetVarlikes(), 4);

                    ClickRupuziokus(GetRupuziokus(), 4);

                }

                catch

                {

                    // heheheh mey

                }

 

            }

 

            Thread.Sleep(3000);

        }

 

        public void ClickRupuziokus(IList<IWebElement> rupuziukai, int count)

        {

            try

            {

                int exactCount = count % rupuziukai.Count;

                exactCount = exactCount == 0 ? count : exactCount;


                for (int i = 0; i < count; i++)

                {

                    var index = rupuziukai.Count - 1 - i;

                    rupuziukai[index].Click();

                    Thread.Sleep(200);

                }

            }

            catch

            {

                // nieko nedarom

            }



        }

 



        public void ClickVarlikes(IList<IWebElement> varlikes, int count)

        {

            try

            {

                int exactCount = count % varlikes.Count;

                exactCount = exactCount == 0 ? count : exactCount;

                for (int i = 0; i < count; i++)

                {

                    varlikes[i].Click();

                    Thread.Sleep(200);

                }

            }
            catch

            {

                // niekoooooz

            }

        }

 



        public IList<IWebElement> GetRupuziokus()

        {

            return ChromeDriver.FindElements(By.XPath(".//*[contains(@src,'https://www.lutanho.net/play/frog1.gif')]")).ToList();

        }

 

        public IList<IWebElement> GetVarlikes()

        {

            return ChromeDriver.FindElements(By.XPath(".//*[contains(@src,'https://www.lutanho.net/play/frog2.gif')]")).ToList();

        }

        [Test]
        public void Task2()
        {
        }

        [Test]
        public void Task3()
        {
        }

        [Test]
        public void Task4()
        {
            ChromeDriver.Navigate().GoToUrl("https://jacksonpollock.org/");
            ChromeDriver.Manage().Window.Size = new Size(1000, 1000);;
            var h = ChromeDriver.Manage().Window.Size.Height;
            var w = ChromeDriver.Manage().Window.Size.Width;
            var a = ChromeDriver.FindElement(By.TagName("body"));
            
            for (int i = 0; i < 50; i++)
            {
                var x = new Random().Next(200);
                var y = new Random().Next(-200, 0);
                ChromeDriver.meu(a, x, y);
            }
            
            for (int i = 0; i < 75; i++)
            {
                var x = new Random().Next(500);
                var y = new Random().Next(0, 400);
                ChromeDriver.meu(a, x, y);
            }

            var sc = ChromeDriver.GetScreenshot();
            using var screenshotStream = new MemoryStream(sc.AsByteArray);
            var image = Image.Load<Rgba32>(new DecoderOptions(), screenshotStream);
            var image2 = image.Clone();
            image2.Mutate(context => context.Flip(FlipMode.Horizontal));

            using (Image<Rgba32> image12 = new Image<Rgba32>(image.Width * 2, image.Height))
            {
                image12.Mutate(o => o
                    .DrawImage(image2, new Point(0, 0), 1f)
                    .DrawImage(image, new Point(image.Width, 0), 1f) 
                );

                image12.SaveAsPng("C://output.png");

                // var image34 = image12.Clone();
                // image34.Mutate(context => context.Flip(FlipMode.Vertical));
                //
                //
                // using (Image<Rgba32> outputImage = new Image<Rgba32>(image12.Width, image12.Height * 2))
                // {
                //     outputImage.Mutate(o => o
                //         .DrawImage(image34, new Point(0, 0), 1f)
                //         .DrawImage(image12, new Point(0, image12.Height), 1f) 
                //     );
                //
                //     outputImage.SaveAsPng("C://output.png");
                // }
            }

        }

        [Test]
        public void Task5()
        {
        }

        [Test]
        public void Task6()
        {
            ChromeDriver.Navigate().GoToUrl("https://web.itu.edu.tr/~msilgu/tetris/tetris.html");
            ChromeDriver.Manage().Window.Maximize();

            ChromeDriver.FindElement(By.Id("tetris-menu-start")).Click();

            var actions = new Actions(ChromeDriver);

            List<(string, int)> meu = new List<(string, int)>(){
                (Keys.ArrowLeft, 5),
                (Keys.ArrowLeft, 2),
                (Keys.ArrowRight, 1),
                (Keys.ArrowRight, 4),
            };

            var index = 0;
            try
            {
                for (int ii = 0; ii < 30; ii++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        var pair = meu[index % meu.Count];
                        for (int j = 0; j < pair.Item2; j++)
                        {
                            actions.SendKeys(pair.Item1);
                            Thread.Sleep(500);
                        }
                        actions.SendKeys(Keys.Space).Perform();
                        Thread.Sleep(200);
                        index++;
                    }
                }
            }
            catch
            {
                Thread.Sleep(5000);
                var a = ChromeDriver.FindElement(By.XPath(".//td[@class='score']/following-sibling::*"));
                Console.WriteLine($"Score: {a.Text}");
            }

            Thread.Sleep(5000);
        }

        [Test]
        public void Task7()
        {
            ChromeDriver.Navigate().GoToUrl("https://ttt-gediminas.onrender.com/online-game/TestAutomation12345678");
            ChromeDriver.Manage().Window.Maximize();
            
            //
            // ChromeDriver.Navigate().GoToUrl("https://ttt-gediminas.onrender.com/local-game");
            // ChromeDriver.FindElement(By.Id("difficulty")).Click();
            // ChromeDriver.FindElement(By.XPath(".//option[@value='1']")).Click();
            // ChromeDriver.FindElement(By.Id("new-game")).Click();
            //
            // ChromeDriver.FindElement(By.Id("first")).Click();
            // ChromeDriver.FindElement(By.XPath(".//select/option[@value='computer']")).Click();
            
            Thread.Sleep(5000);
            var a = GetYourSign();
            if (a < 0)
            {
                Thread.Sleep(10000);
            }
            for (int i = 0; i < 100; i++)
            {
                var didWin = false;
                foreach (var board in GetBoards())
                {
                    if (CanWin(board, a))
                    {
                        ClickWinningCell(board, a);
                        didWin = true;
                        break;
                    }
                }

                if (!didWin)
                {
                    ClickRandomCell();
                }
                Thread.Sleep(1000);
            }


        }

        public int GetYourSign()
        {
            var meu = ChromeDriver.FindElement(By.Id("player-display"));
            if (meu.Text.Contains("X"))
            {
                return 1;
            }
            else
            {
                return -1;
            }
            
        }
        
        public IList<IWebElement> GetBoards()
        {
            return ChromeDriver.FindElements(
                By.XPath(".//td[contains(@class, 'enabled') and contains(@class, 'smallBoard')]")).ToList();
        }

        public bool CanWin(IWebElement board, int a)
        {
            var nium = meumeu(board, a);

            if (nium[0] + nium[1] + nium[2] == 2 ||
                nium[0] + nium[3] + nium[6] == 2 ||
                nium[0] + nium[4] + nium[8] == 2 ||
                nium[3] + nium[4] + nium[5] == 2 ||
                nium[1] + nium[4] + nium[7] == 2 ||
                nium[2] + nium[4] + nium[6] == 2 ||
                nium[6] + nium[7] + nium[8] == 2 ||
                nium[2] + nium[5] + nium[8] == 2)
            {
                return true;
            }

            return false;
        }

        public void ClickWinningCell(IWebElement board, int a)
        {
            var meu = board.FindElements(By.TagName("td"));

            var nium = meumeu(board, a);
            if (nium[0] + nium[1] + nium[2] == 2)
            {
                try { meu[0].Click(); } catch {}
                try {meu[1].Click();} catch {}
                    try {meu[2].Click();} catch {}
            } 
            if (nium[0] + nium[3] + nium[6] == 2)
            {
                try {meu[0].Click();} catch {}
                    try {meu[3].Click();} catch {}
                        try {meu[6].Click();} catch {}
            }
            if (nium[0] + nium[4] + nium[8] == 2)
            {
                try {meu[0].Click();} catch {}
                    try { meu[4].Click();} catch {}
                        try {meu[8].Click();} catch {}
            }
            if (nium[3] + nium[4] + nium[5] == 2)
            {
                try {meu[3].Click();} catch {}
                    try {meu[4].Click();} catch {}
                        try {meu[5].Click();} catch {}
            }
            if (nium[1] + nium[4] + nium[7] == 2)
            {
                try { meu[1].Click();} catch {}
                    try {meu[4].Click();} catch {}
                        try { meu[7].Click();} catch {}
            }
            if (nium[2] + nium[4] + nium[6] == 2)
            {
                try { meu[2].Click();} catch {}
                    try { meu[4].Click();} catch {}
                        try { meu[6].Click();} catch {}
            }
            if (nium[6] + nium[7] + nium[8] == 2)
            {
                try { meu[6].Click();} catch {}
                    try { meu[7].Click();} catch {}
                        try { meu[8].Click();} catch {}
            }
            if (nium[2] + nium[5] + nium[8] == 2)
            {
                try { meu[2].Click();} catch {}
                    try { meu[5].Click();} catch {}
                        try {  meu[8].Click();} catch {}
            }
        }

        public List<int> meumeu(IWebElement board, int a)
        {
            List<int> nium = new List<int>() {0, 0, 0, 0, 0, 0, 0, 0, 0};
            int i = 0;
            var meu = board.FindElements(By.TagName("td"));
            foreach (var cell in meu)
            {
                if (cell.Text == "X")
                {
                    nium[i] = 1*a;
                }
                if (cell.Text == "O")
                {
                    nium[i] = -1*a;
                }

                i++;
            }
            
            return nium;
        }
        
            
        public void ClickRandomCell()
        {
            var b = By.XPath(".//td[contains(@class, 'enabled') and contains(@class, 'cell')]");

            var aaa = ChromeDriver.FindElements(b).ToList();
            var index = new Random().Next(aaa.Count);
            aaa[index].Click();
            Thread.Sleep(1000);
        }
    }

}